using System;
using System.Windows.Forms;

namespace CalibrationCertificates.Forms
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text == "admin" && txtPassword.Text == "1234")
            {
                this.Hide();
                new MenuForm().Show();
            }
            else
            {
                lblError.Visible = true;
            }
        }
    }
}

