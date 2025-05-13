using System;
using System.Windows.Forms;

namespace CalibrationCertificates.Forms
{
    public partial class MenuForm : Form
    {
        Button buttonUpdateData;
        Button buttonGenerateCertificate;

        public MenuForm()
        {
            this.Text = "Menu";

            buttonUpdateData = new Button { Text = "Обновить данные", Top = 30, Left = 30, Width = 150 };
            buttonGenerateCertificate = new Button { Text = "Сформировать сертификат", Top = 80, Left = 30, Width = 200 };

            buttonUpdateData.Click += (s, e) => { new UpdateDataForm().Show(); };
            buttonGenerateCertificate.Click += (s, e) => { new GenerateCertificateForm().Show(); };

            Controls.Add(buttonUpdateData);
            Controls.Add(buttonGenerateCertificate);
        }
    }
}
