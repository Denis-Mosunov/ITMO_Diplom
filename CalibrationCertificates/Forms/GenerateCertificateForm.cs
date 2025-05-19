using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using CalibrationCertificates.Database;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;

namespace CalibrationCertificates.Forms
{
    public partial class GenerateCertificateForm : Form
    {
        public GenerateCertificateForm()
        {
            InitializeComponent();
        }

        private void GenerateCertificateForm_Load(object sender, EventArgs e)
        {
            // Пример: загрузка данных из базы
            cmbDevice.DataSource = DatabaseManager.GetDevices();
            cmbDevice.DisplayMember = "DeviceName";
            cmbDevice.ValueMember = "Id";

            cmbStandard.DataSource = DatabaseManager.GetStandards();
            cmbStandard.DisplayMember = "StandardName";
            cmbStandard.ValueMember = "Id";

            cmbCalibrator.DataSource = DatabaseManager.GetUsersByRole("calibrator");
            cmbCalibrator.DisplayMember = "Username";
            cmbCalibrator.ValueMember = "Id";

            cmbChief.DataSource = DatabaseManager.GetUsersByRole("chief");
            cmbChief.DisplayMember = "Username";
            cmbChief.ValueMember = "Id";

            HookPreviewEvents();
        }

        private void HookPreviewEvents()
        {
            cmbDevice.SelectedIndexChanged += (s, e) => UpdatePreviewHtml();
            cmbStandard.SelectedIndexChanged += (s, e) => UpdatePreviewHtml();
            cmbCalibrator.SelectedIndexChanged += (s, e) => UpdatePreviewHtml();
            cmbChief.SelectedIndexChanged += (s, e) => UpdatePreviewHtml();

            txtTemp.TextChanged += (s, e) => UpdatePreviewHtml();
            txtHumidity.TextChanged += (s, e) => UpdatePreviewHtml();
            txtPressure.TextChanged += (s, e) => UpdatePreviewHtml();
            txtVoltage.TextChanged += (s, e) => UpdatePreviewHtml();
        }

        private void UpdatePreviewHtml()
        {
            string html = $@"
            <html><head><meta charset='utf-8'>
            <style>body{{font-family:Arial;padding:10px;}}</style></head><body>
            <h2>Сертификат калибровки</h2>
            <p><b>Прибор:</b> {cmbDevice.Text}</p>
            <p><b>Эталон:</b> {cmbStandard.Text}</p>
            <p><b>Калибровщик:</b> {cmbCalibrator.Text}</p>
            <p><b>Главный метролог:</b> {cmbChief.Text}</p>
            <p><b>Условия:</b> t={txtTemp.Text} °C, φ={txtHumidity.Text} %, ρ={txtPressure.Text} кПа, U={txtVoltage.Text} В</p>
            <p><b>Дата:</b> {DateTime.Now:dd.MM.yyyy}</p>
            </body></html>";

            webPreview.DocumentText = html;
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            try
            {
                string templatePath = Path.Combine(Application.StartupPath, "Шаблон.docx");

                if (!File.Exists(templatePath))
                {
                    MessageBox.Show("Файл шаблона не найден.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
                string outputPath = Path.Combine(desktopPath, $"Сертификат_{DateTime.Now:yyyyMMdd_HHmmss}.docx");

                File.Copy(templatePath, outputPath, true);

                var replacements = new Dictionary<string, string>
                {
                    ["{{DEVICE}}"] = cmbDevice.Text,
                    ["{{STANDARD}}"] = cmbStandard.Text,
                    ["{{CALIBRATOR}}"] = cmbCalibrator.Text,
                    ["{{CHIEF}}"] = cmbChief.Text,
                    ["{{TEMP}}"] = txtTemp.Text,
                    ["{{HUMIDITY}}"] = txtHumidity.Text,
                    ["{{PRESSURE}}"] = txtPressure.Text,
                    ["{{VOLTAGE}}"] = txtVoltage.Text,
                    ["{{DATE}}"] = DateTime.Now.ToString("dd.MM.yyyy")
                };

                ReplaceTextInDocument(outputPath, replacements);

                MessageBox.Show("Сертификат успешно сохранён на рабочем столе.", "Готово", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при сохранении сертификата:\n" + ex.Message);
            }
        }

        private void ReplaceTextInDocument(string filePath, Dictionary<string, string> replacements)
        {
            using var doc = WordprocessingDocument.Open(filePath, true);
            var texts = doc.MainDocumentPart.Document.Body.Descendants<Text>();

            foreach (var text in texts)
            {
                foreach (var pair in replacements)
                {
                    if (text.Text.Contains(pair.Key))
                    {
                        text.Text = text.Text.Replace(pair.Key, pair.Value);
                    }
                }
            }

            doc.MainDocumentPart.Document.Save();
        }
    }
}
