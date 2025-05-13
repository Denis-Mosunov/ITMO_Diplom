using System;
using System.Windows.Forms;

namespace CalibrationCertificates.Forms
{
    public class UpdateDataForm : Form
    {
        TextBox periodicityTextBox, departmentTextBox, certificateNumberTextBox,
                factoryNumberTextBox, inventoryNumberTextBox, documentTextBox,
                standardsTextBox, factorsTextBox, chiefMetrologistTextBox, calibratorTextBox;

        Button addButton, deleteButton, backButton;

        public UpdateDataForm()
        {
            this.Text = "Обновить данные";
            this.Width = 600;
            this.Height = 550;

            int top = 20;
            int leftLabel = 20;
            int leftTextBox = 220;

            // Поля
            CreateLabelAndTextBox("Периодичность (мес):", ref periodicityTextBox, top, leftLabel, leftTextBox); top += 40;
            CreateLabelAndTextBox("Принадлежит (отдел №):", ref departmentTextBox, top, leftLabel, leftTextBox); top += 40;
            CreateLabelAndTextBox("Сертификат №:", ref certificateNumberTextBox, top, leftLabel, leftTextBox); top += 40;
            CreateLabelAndTextBox("Заводской номер:", ref factoryNumberTextBox, top, leftLabel, leftTextBox); top += 40;
            CreateLabelAndTextBox("Инвентарный номер:", ref inventoryNumberTextBox, top, leftLabel, leftTextBox); top += 40;
            CreateLabelAndTextBox("Документ:", ref documentTextBox, top, leftLabel, leftTextBox); top += 40;
            CreateLabelAndTextBox("Эталоны:", ref standardsTextBox, top, leftLabel, leftTextBox); top += 40;
            CreateLabelAndTextBox("Факторы влияния:", ref factorsTextBox, top, leftLabel, leftTextBox); top += 40;
            CreateLabelAndTextBox("Главный метролог:", ref chiefMetrologistTextBox, top, leftLabel, leftTextBox); top += 40;
            CreateLabelAndTextBox("Калибровщик:", ref calibratorTextBox, top, leftLabel, leftTextBox); top += 40;

            // Кнопки
            addButton = new Button { Text = "Добавить", Top = top, Left = leftLabel, Width = 120 };
            deleteButton = new Button { Text = "Удалить", Top = top, Left = leftLabel + 140, Width = 120 };
            backButton = new Button { Text = "Назад", Top = top, Left = leftLabel + 280, Width = 120 };

            addButton.Click += AddButton_Click;
            deleteButton.Click += DeleteButton_Click;
            backButton.Click += BackButton_Click;

            Controls.Add(addButton);
            Controls.Add(deleteButton);
            Controls.Add(backButton);
        }

        private void CreateLabelAndTextBox(string labelText, ref TextBox textBox, int top, int leftLabel, int leftTextBox)
        {
            var label = new Label { Text = labelText, Top = top, Left = leftLabel, Width = 200 };
            textBox = new TextBox { Top = top, Left = leftTextBox, Width = 300 };
            Controls.Add(label);
            Controls.Add(textBox);
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Добавить запись (пока заглушка)");
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Удалить запись (пока заглушка)");
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

