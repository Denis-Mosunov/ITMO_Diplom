namespace CalibrationCertificates.Forms
{
    partial class GenerateCertificateForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ComboBox cmbDevice;
        private System.Windows.Forms.ComboBox cmbStandard;
        private System.Windows.Forms.ComboBox cmbCalibrator;
        private System.Windows.Forms.ComboBox cmbChief;
        private System.Windows.Forms.TextBox txtTemp;
        private System.Windows.Forms.TextBox txtHumidity;
        private System.Windows.Forms.TextBox txtPressure;
        private System.Windows.Forms.TextBox txtVoltage;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.WebBrowser webPreview;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            cmbDevice = new ComboBox();
            cmbStandard = new ComboBox();
            cmbCalibrator = new ComboBox();
            cmbChief = new ComboBox();
            txtTemp = new TextBox();
            txtHumidity = new TextBox();
            txtPressure = new TextBox();
            txtVoltage = new TextBox();
            btnGenerate = new Button();
            webPreview = new WebBrowser();
            txtPreview = new TextBox();
            SuspendLayout();
            // 
            // cmbDevice
            // 
            cmbDevice.FormattingEnabled = true;
            cmbDevice.Location = new Point(30, 20);
            cmbDevice.Name = "cmbDevice";
            cmbDevice.Size = new Size(250, 23);
            cmbDevice.TabIndex = 0;
            // 
            // cmbStandard
            // 
            cmbStandard.FormattingEnabled = true;
            cmbStandard.Location = new Point(30, 60);
            cmbStandard.Name = "cmbStandard";
            cmbStandard.Size = new Size(250, 23);
            cmbStandard.TabIndex = 1;
            // 
            // cmbCalibrator
            // 
            cmbCalibrator.FormattingEnabled = true;
            cmbCalibrator.Location = new Point(30, 100);
            cmbCalibrator.Name = "cmbCalibrator";
            cmbCalibrator.Size = new Size(250, 23);
            cmbCalibrator.TabIndex = 2;
            // 
            // cmbChief
            // 
            cmbChief.FormattingEnabled = true;
            cmbChief.Location = new Point(30, 140);
            cmbChief.Name = "cmbChief";
            cmbChief.Size = new Size(250, 23);
            cmbChief.TabIndex = 3;
            // 
            // txtTemp
            // 
            txtTemp.Location = new Point(30, 180);
            txtTemp.Name = "txtTemp";
            txtTemp.PlaceholderText = "Температура (°C)";
            txtTemp.Size = new Size(250, 23);
            txtTemp.TabIndex = 4;
            // 
            // txtHumidity
            // 
            txtHumidity.Location = new Point(30, 220);
            txtHumidity.Name = "txtHumidity";
            txtHumidity.PlaceholderText = "Влажность (%)";
            txtHumidity.Size = new Size(250, 23);
            txtHumidity.TabIndex = 5;
            // 
            // txtPressure
            // 
            txtPressure.Location = new Point(30, 260);
            txtPressure.Name = "txtPressure";
            txtPressure.PlaceholderText = "Давление (мм рт. ст.)";
            txtPressure.Size = new Size(250, 23);
            txtPressure.TabIndex = 6;
            // 
            // txtVoltage
            // 
            txtVoltage.Location = new Point(30, 300);
            txtVoltage.Name = "txtVoltage";
            txtVoltage.PlaceholderText = "Напряжение (В)";
            txtVoltage.Size = new Size(250, 23);
            txtVoltage.TabIndex = 7;
            // 
            // btnGenerate
            // 
            btnGenerate.Location = new Point(30, 340);
            btnGenerate.Name = "btnGenerate";
            btnGenerate.Size = new Size(250, 35);
            btnGenerate.TabIndex = 8;
            btnGenerate.Text = "Сформировать сертификат";
            btnGenerate.UseVisualStyleBackColor = true;
            btnGenerate.Click += btnGenerate_Click;
            // 
            // webPreview
            // 
            webPreview.Location = new Point(320, 20);
            webPreview.MinimumSize = new Size(20, 20);
            webPreview.Name = "webPreview";
            webPreview.Size = new Size(400, 360);
            webPreview.TabIndex = 10;
            // 
            // txtPreview
            // 
            txtPreview.Font = new Font("Segoe UI", 10F);
            txtPreview.Location = new Point(751, 20);
            txtPreview.Multiline = true;
            txtPreview.Name = "txtPreview";
            txtPreview.ReadOnly = true;
            txtPreview.ScrollBars = ScrollBars.Vertical;
            txtPreview.Size = new Size(350, 360);
            txtPreview.TabIndex = 9;
            // 
            // GenerateCertificateForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1148, 400);
            Controls.Add(cmbDevice);
            Controls.Add(cmbStandard);
            Controls.Add(cmbCalibrator);
            Controls.Add(cmbChief);
            Controls.Add(txtTemp);
            Controls.Add(txtHumidity);
            Controls.Add(txtPressure);
            Controls.Add(txtVoltage);
            Controls.Add(btnGenerate);
            Controls.Add(txtPreview);
            Controls.Add(webPreview);
            Name = "GenerateCertificateForm";
            Text = "Создание сертификата";
            Load += GenerateCertificateForm_Load;
            ResumeLayout(false);
            PerformLayout();

        }
        private TextBox txtPreview;
    }
}

