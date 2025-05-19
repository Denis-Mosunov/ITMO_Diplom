namespace CalibrationCertificates.Forms
{
    partial class UpdateDataForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblDeviceName;
        private System.Windows.Forms.TextBox txtDeviceName;
        private System.Windows.Forms.Label lblDeviceType;
        private System.Windows.Forms.TextBox txtDeviceType;
        private System.Windows.Forms.Button btnSave;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblDeviceName = new System.Windows.Forms.Label();
            this.txtDeviceName = new System.Windows.Forms.TextBox();
            this.lblDeviceType = new System.Windows.Forms.Label();
            this.txtDeviceType = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblDeviceName
            // 
            this.lblDeviceName.Location = new System.Drawing.Point(30, 30);
            this.lblDeviceName.Name = "lblDeviceName";
            this.lblDeviceName.Size = new System.Drawing.Size(120, 23);
            this.lblDeviceName.Text = "Название прибора:";
            // 
            // txtDeviceName
            // 
            this.txtDeviceName.Location = new System.Drawing.Point(160, 30);
            this.txtDeviceName.Name = "txtDeviceName";
            this.txtDeviceName.Size = new System.Drawing.Size(200, 23);
            // 
            // lblDeviceType
            // 
            this.lblDeviceType.Location = new System.Drawing.Point(30, 70);
            this.lblDeviceType.Name = "lblDeviceType";
            this.lblDeviceType.Size = new System.Drawing.Size(120, 23);
            this.lblDeviceType.Text = "Тип прибора:";
            // 
            // txtDeviceType
            // 
            this.txtDeviceType.Location = new System.Drawing.Point(160, 70);
            this.txtDeviceType.Name = "txtDeviceType";
            this.txtDeviceType.Size = new System.Drawing.Size(200, 23);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(160, 110);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(200, 30);
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // UpdateDataForm
            // 
            this.ClientSize = new System.Drawing.Size(400, 180);
            this.Controls.Add(this.lblDeviceName);
            this.Controls.Add(this.txtDeviceName);
            this.Controls.Add(this.lblDeviceType);
            this.Controls.Add(this.txtDeviceType);
            this.Controls.Add(this.btnSave);
            this.Name = "UpdateDataForm";
            this.Text = "Добавление прибора";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
