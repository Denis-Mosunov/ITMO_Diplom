using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using CalibrationCertificates.Database;
using CalibrationCertificates.Models;
using CalibrationCertificates.Utils;

namespace CalibrationCertificates.Forms
{
    public class GenerateCertificateForm : Form
    {
        private ComboBox deviceSelector, standardSelector, calibratorSelector, chiefMetrologistSelector;
        private TextBox tempBox, humidityBox, pressureBox, voltageBox, previewBox;
        private Button saveButton, backButton;

        private List<Device> devices;
        private List<Standard> standards;
        private List<User> calibrators;
        private List<User> chiefs;

        public GenerateCertificateForm()
        {
            this.Text = "Создать сертификат";
            this.Width = 900;
            this.Height = 700;

            InitializeControls();
            LoadData();
        }

        private void InitializeControls()
        {
            int top = 20;

            Controls.Add(new Label { Text = "Прибор:", Left = 20, Top = top });
            deviceSelector = new ComboBox { Left = 150, Top = top, Width = 300 };
            deviceSelector.SelectedIndexChanged += UpdatePreview;
            Controls.Add(deviceSelector);
            top += 40;

            Controls.Add(new Label { Text = "Эталон:", Left = 20, Top = top });
            standardSelector = new ComboBox { Left = 150, Top = top, Width = 300 };
            standardSelector.SelectedIndexChanged += UpdatePreview;
            Controls.Add(standardSelector);
            top += 40;

            Controls.Add(new Label { Text = "Калибровщик:", Left = 20, Top = top });
            calibratorSelector = new ComboBox { Left = 150, Top = top, Width = 300 };
            calibratorSelector.SelectedIndexChanged += UpdatePreview;
            Controls.Add(calibratorSelector);
            top += 40;

            Controls.Add(new Label { Text = "Главный метролог:", Left = 20, Top = top });
            chiefMetrologistSelector = new ComboBox { Left = 150, Top = top, Width = 300 };
            chiefMetrologistSelector.SelectedIndexChanged += UpdatePreview;
            Controls.Add(chiefMetrologistSelector);
            top += 40;

            Controls.Add(new Label { Text = "Температура (°C):", Left = 20, Top = top });
            tempBox = new TextBox { Left = 150, Top = top, Width = 100 };
            tempBox.TextChanged += UpdatePreview;
            Controls.Add(tempBox);
            top += 40;

            Controls.Add(new Label { Text = "Влажность (%):", Left = 20, Top = top });
            humidityBox = new TextBox { Left = 150, Top = top, Width = 100 };
            humidityBox.TextChanged += UpdatePreview;
            Controls.Add(humidityBox);
            top += 40;

            Controls.Add(new Label { Text = "Давление (кПа):", Left = 20, Top = top });
            pressureBox = new TextBox { Left = 150, Top = top, Width = 100 };
            pressureBox.TextChanged += UpdatePreview;
            Controls.Add(pressureBox);
            top += 40;

            Controls.Add(new Label { Text = "Напряжение (В):", Left = 20, Top = top });
            voltageBox = new TextBox { Left = 150, Top = top, Width = 100 };
            voltageBox.TextChanged += UpdatePreview;
            Controls.Add(voltageBox);
            top += 40;

            previewBox = new TextBox
            {
                Left = 500,
                Top = 20,
                Width = 350,
                Height = 500,
                Multiline = true,
                ReadOnly = true,
                ScrollBars = ScrollBars.Vertical
            };
            Controls.Add(previewBox);

            saveButton = new Button { Text = "Сохранить сертификат", Left = 20, Top = top + 40, Width = 200 };
            backButton = new Button { Text = "Назад", Left = 240, Top = top + 40, Width = 150 };

            saveButton.Click += SaveButton_Click;
            backButton.Click += (s, e) => { this.Close(); };

            Controls.Add(saveButton);
            Controls.Add(backButton);
        }

        private void LoadData()
        {
            devices = DatabaseManager.GetDevices();
            standards = DatabaseManager.GetStandards();
            calibrators = DatabaseManager.GetUsersByRole("калибровщик");
            chiefs = DatabaseManager.GetUsersByRole("главный метролог");

            foreach (var d in devices)
                deviceSelector.Items.Add($"{d.DeviceName} (Зав. № {d.FactoryNumber})");

            foreach (var s in standards)
                standardSelector.Items.Add($"{s.StandardName} (Зав. № {s.FactoryNumber})");

            foreach (var u in calibrators)
                calibratorSelector.Items.Add(u.Username);

            foreach (var c in chiefs)
                chiefMetrologistSelector.Items.Add(c.Username);
        }

        private void UpdatePreview(object sender, EventArgs e)
        {
            if (deviceSelector.SelectedIndex == -1 || standardSelector.SelectedIndex == -1 ||
                calibratorSelector.SelectedIndex == -1 || chiefMetrologistSelector.SelectedIndex == -1)
                return;

            previewBox.Text = $@"
АО НПК «Северная заря»

СЕРТИФИКАТ О КАЛИБРОВКЕ

Прибор: {devices[deviceSelector.SelectedIndex].DeviceName}
Эталон: {standards[standardSelector.SelectedIndex].StandardName}
Калибровщик: {calibrators[calibratorSelector.SelectedIndex].Username}
Главный метролог: {chiefs[chiefMetrologistSelector.SelectedIndex].Username}

Факторы окружающей среды:
Температура: {tempBox.Text} °C
Влажность: {humidityBox.Text} %
Давление: {pressureBox.Text} кПа
Напряжение: {voltageBox.Text} В

Дата калибровки: {DateTime.Now:dd.MM.yyyy}
";
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                var cert = new Certificate
                {
                    DeviceId = devices[deviceSelector.SelectedIndex].Id,
                    StandardId = standards[standardSelector.SelectedIndex].Id,
                    CalibratorId = calibrators[calibratorSelector.SelectedIndex].Id,
                    ChiefMetrologistId = chiefs[chiefMetrologistSelector.SelectedIndex].Id,
                    Temperature = double.Parse(tempBox.Text),
                    Humidity = double.Parse(humidityBox.Text),
                    Pressure = double.Parse(pressureBox.Text),
                    Voltage = double.Parse(voltageBox.Text),
                    CalibrationDate = DateTime.Now
                };

                // Сохраняем в базу данных
                DatabaseManager.InsertCertificate(cert);

                // Готовим подстановку для шаблона
                var replacements = new Dictionary<string, string>
{
    { "{Device}", devices[deviceSelector.SelectedIndex].DeviceName },
    { "{Standard}", standards[standardSelector.SelectedIndex].StandardName },
    { "{Calibrator}", calibrators[calibratorSelector.SelectedIndex].Username },
    { "{ChiefMetrologist}", chiefs[chiefMetrologistSelector.SelectedIndex].Username },
    { "{Temperature}", tempBox.Text },
    { "{Humidity}", humidityBox.Text },
    { "{Pressure}", pressureBox.Text },
    { "{Voltage}", voltageBox.Text },
    { "{CalibrationDate}", DateTime.Now.ToString("dd.MM.yyyy") }
};

                string savePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"Certificate_{DateTime.Now:yyyyMMdd_HHmmss}.docx");
                CertificateDocxGenerator.GenerateCertificateDocx(replacements, savePath);


                CertificateDocxGenerator.GenerateCertificateDocx(replacements, savePath);

                MessageBox.Show($"Сертификат успешно сохранён в файл:\n{savePath}");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении: {ex.Message}");
            }
        }
    }
}
