using System;
using System.Windows.Forms;

namespace CalibrationCertificates.Forms
{
    public partial class SplashForm : Form
    {
        private System.Windows.Forms.Timer timer;
        private int progress = 0;

        public SplashForm()
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
            this.Width = 500;
            this.Height = 300;

            Label titleLabel = new Label
            {
                Text = "Calibration Certificates",
                ForeColor = System.Drawing.Color.White,
                Font = new System.Drawing.Font("Segoe UI", 18, System.Drawing.FontStyle.Bold),
                AutoSize = false,
                Width = 500,
                TextAlign = System.Drawing.ContentAlignment.MiddleCenter,
                Top = 80
            };

            ProgressBar progressBar = new ProgressBar
            {
                Style = ProgressBarStyle.Continuous,
                Width = 400,
                Height = 20,
                Top = 200,
                Left = 50,
                Maximum = 100
            };

            this.Controls.Add(titleLabel);
            this.Controls.Add(progressBar);

            timer = new System.Windows.Forms.Timer();
            timer.Interval = 30;
            timer.Tick += (s, e) =>
            {
                progress += 1;
                progressBar.Value = progress;
                if (progress >= 100)
                {
                    timer.Stop();
                    this.Hide();
                    new LoginForm().Show(); // Запуск формы входа
                }
            };
            timer.Start();
        }
    }
}
