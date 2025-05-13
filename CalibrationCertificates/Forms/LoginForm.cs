using System;
using System.Windows.Forms;
using CalibrationCertificates.Database;

namespace CalibrationCertificates.Forms
{
    public partial class LoginForm : Form
    {
        TextBox textBoxUsername;
        TextBox textBoxPassword;
        Button buttonLogin;

        public LoginForm()
        {
            this.Text = "Login";

            Label labelUsername = new Label { Text = "Username:", Top = 20, Left = 20 };
            Label labelPassword = new Label { Text = "Password:", Top = 60, Left = 20 };

            textBoxUsername = new TextBox { Top = 20, Left = 100, Width = 150 };
            textBoxPassword = new TextBox { Top = 60, Left = 100, Width = 150, PasswordChar = '*' };

            buttonLogin = new Button { Text = "Login", Top = 100, Left = 100 };
            buttonLogin.Click += ButtonLogin_Click;

            Controls.Add(labelUsername);
            Controls.Add(textBoxUsername);
            Controls.Add(labelPassword);
            Controls.Add(textBoxPassword);
            Controls.Add(buttonLogin);
        }

        private void ButtonLogin_Click(object sender, EventArgs e)
        {
            if (DatabaseManager.CheckLogin(textBoxUsername.Text, textBoxPassword.Text))
            {
                MessageBox.Show("Вход выполнен успешно!");
                this.Hide();
                new MenuForm().Show();
            }
            else
            {
                MessageBox.Show("Неверное имя пользователя или пароль.");
            }
        }
    }
}

