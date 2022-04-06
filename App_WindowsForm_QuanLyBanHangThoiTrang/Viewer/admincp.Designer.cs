namespace Viewer
{
    partial class admincp
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(admincp));
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnLuongNV = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnChotBill = new System.Windows.Forms.Button();
            this.btnTaikhoan = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.pnMain = new System.Windows.Forms.Panel();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.LightGray;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(1030, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 25);
            this.label2.TabIndex = 6;
            this.label2.Text = "Xin Chào:";
            // 
            // panel2
            // 
            this.panel2.BackgroundImage = global::Viewer.Properties.Resources.pngtree_g20_summit_simple_business_background_image_232743;
            this.panel2.Controls.Add(this.btnLuongNV);
            this.panel2.Controls.Add(this.btnChotBill);
            this.panel2.Controls.Add(this.btnTaikhoan);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1005, 99);
            this.panel2.TabIndex = 8;
            // 
            // btnLuongNV
            // 
            this.btnLuongNV.BackColor = System.Drawing.Color.Maroon;
            this.btnLuongNV.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuongNV.ForeColor = System.Drawing.Color.White;
            this.btnLuongNV.Image = global::Viewer.Properties.Resources.icon1;
            this.btnLuongNV.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLuongNV.Location = new System.Drawing.Point(413, 12);
            this.btnLuongNV.Name = "btnLuongNV";
            this.btnLuongNV.Size = new System.Drawing.Size(160, 78);
            this.btnLuongNV.TabIndex = 0;
            this.btnLuongNV.Text = "Lương NV";
            this.btnLuongNV.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLuongNV.UseVisualStyleBackColor = false;
            this.btnLuongNV.Click += new System.EventHandler(this.btnLuongNV_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.LightGray;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(1033, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 25);
            this.label1.TabIndex = 5;
            this.label1.Text = "<USER>";
            // 
            // btnChotBill
            // 
            this.btnChotBill.BackColor = System.Drawing.Color.Maroon;
            this.btnChotBill.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChotBill.ForeColor = System.Drawing.Color.White;
            this.btnChotBill.Image = global::Viewer.Properties.Resources.formICON_300x300;
            this.btnChotBill.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnChotBill.Location = new System.Drawing.Point(215, 9);
            this.btnChotBill.Name = "btnChotBill";
            this.btnChotBill.Size = new System.Drawing.Size(173, 78);
            this.btnChotBill.TabIndex = 0;
            this.btnChotBill.Text = "NV Đã Chốt Bill";
            this.btnChotBill.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnChotBill.UseVisualStyleBackColor = false;
            this.btnChotBill.Click += new System.EventHandler(this.btnChotBill_Click);
            // 
            // btnTaikhoan
            // 
            this.btnTaikhoan.BackColor = System.Drawing.Color.Maroon;
            this.btnTaikhoan.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTaikhoan.ForeColor = System.Drawing.Color.White;
            this.btnTaikhoan.Image = global::Viewer.Properties.Resources.multi_user_icon;
            this.btnTaikhoan.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTaikhoan.Location = new System.Drawing.Point(32, 9);
            this.btnTaikhoan.Name = "btnTaikhoan";
            this.btnTaikhoan.Size = new System.Drawing.Size(160, 78);
            this.btnTaikhoan.TabIndex = 0;
            this.btnTaikhoan.Text = "Tài Khoản";
            this.btnTaikhoan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTaikhoan.UseVisualStyleBackColor = false;
            this.btnTaikhoan.Click += new System.EventHandler(this.btnTaikhoan_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.BackColor = System.Drawing.Color.Aqua;
            this.btnThoat.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.ForeColor = System.Drawing.Color.Purple;
            this.btnThoat.Location = new System.Drawing.Point(1038, 60);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(91, 36);
            this.btnThoat.TabIndex = 9;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = false;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click_1);
            // 
            // pnMain
            // 
            this.pnMain.BackgroundImage = global::Viewer.Properties.Resources.login;
            this.pnMain.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnMain.Location = new System.Drawing.Point(0, 96);
            this.pnMain.Name = "pnMain";
            this.pnMain.Size = new System.Drawing.Size(1151, 592);
            this.pnMain.TabIndex = 7;
            // 
            // admincp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Viewer.Properties.Resources.login;
            this.ClientSize = new System.Drawing.Size(1151, 688);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pnMain);
            this.Controls.Add(this.btnThoat);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "admincp";
            this.Text = "admincp";
            this.Load += new System.EventHandler(this.admincp_Load);
            this.Resize += new System.EventHandler(this.admincp_Resize);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnTaikhoan;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnMain;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnChotBill;
        private System.Windows.Forms.Button btnLuongNV;
    }
}