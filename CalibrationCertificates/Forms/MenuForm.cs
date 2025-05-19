using System;
using System.Windows.Forms;

namespace CalibrationCertificates.Forms
{
    public partial class MenuForm : Form
    {
        public MenuForm()
        {
            InitializeComponent(); // вызываем, но не определяем!
        }

        private void btnUpdateData_Click(object sender, EventArgs e)
        {
            new UpdateDataForm().Show();
        }

        private void btnCertificate_Click(object sender, EventArgs e)
        {
            new GenerateCertificateForm().Show(); // или CertificateForm, если переименовано
        }
    }
}
