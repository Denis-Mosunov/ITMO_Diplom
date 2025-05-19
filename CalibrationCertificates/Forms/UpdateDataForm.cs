using System;
using System.Windows.Forms;

namespace CalibrationCertificates.Forms
{
    public partial class UpdateDataForm : Form
    {
        public UpdateDataForm()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Логика сохранения данных
            MessageBox.Show("Данные сохранены успешно!");
        }
    }
}

