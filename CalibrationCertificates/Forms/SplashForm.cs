using System;
using System.Windows.Forms;

namespace CalibrationCertificates.Forms
{
    public partial class SplashForm : Form
    {
        public SplashForm()
        {
            InitializeComponent();
        }

        private void timerSplash_Tick(object sender, EventArgs e)
        {
            timerSplash.Stop();
            this.Hide();
            new LoginForm().Show();
        }
        private void SplashForm_Load(object sender, EventArgs e)
        {
            timerSplash.Start(); // если нужно Ч запуск таймера
        }

    }
}
