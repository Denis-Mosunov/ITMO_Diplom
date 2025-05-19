using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalibrationCertificates.Forms
{
    partial class MenuForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btnUpdateData;
        private System.Windows.Forms.Button btnCertificate;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.btnUpdateData = new System.Windows.Forms.Button();
            this.btnCertificate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnUpdateData
            // 
            this.btnUpdateData.Location = new System.Drawing.Point(50, 30);
            this.btnUpdateData.Size = new System.Drawing.Size(200, 40);
            this.btnUpdateData.Text = "Добавить прибор/эталон";
            this.btnUpdateData.Click += new System.EventHandler(this.btnUpdateData_Click);
            // 
            // btnCertificate
            // 
            this.btnCertificate.Location = new System.Drawing.Point(50, 90);
            this.btnCertificate.Size = new System.Drawing.Size(200, 40);
            this.btnCertificate.Text = "Создать сертификат";
            this.btnCertificate.Click += new System.EventHandler(this.btnCertificate_Click);
            // 
            // MenuForm
            // 
            this.ClientSize = new System.Drawing.Size(300, 160);
            this.Controls.Add(this.btnUpdateData);
            this.Controls.Add(this.btnCertificate);
            this.Name = "MenuForm";
            this.Text = "Главное меню";
            this.ResumeLayout(false);
        }
    }
}
