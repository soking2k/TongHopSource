namespace Viewer
{
    partial class ShowForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShowForm));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pnMain = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnHoaDon = new System.Windows.Forms.Button();
            this.btnSanpham = new System.Windows.Forms.Button();
            this.btnGIaodich = new System.Windows.Forms.Button();
            this.btnDataKH = new System.Windows.Forms.Button();
            this.btnDoanhThu = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.LightGray;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(1014, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "<USER>";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.LightGray;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(1011, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Xin Chào:";
            // 
            // pnMain
            // 
            this.pnMain.BackgroundImage = global::Viewer.Properties.Resources.login;
            this.pnMain.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnMain.Location = new System.Drawing.Point(0, 101);
            this.pnMain.Name = "pnMain";
            this.pnMain.Size = new System.Drawing.Size(1196, 680);
            this.pnMain.TabIndex = 2;
            this.pnMain.Resize += new System.EventHandler(this.pnMain_Resize);
            // 
            // panel2
            // 
            this.panel2.BackgroundImage = global::Viewer.Properties.Resources.pngtree_g20_summit_simple_business_background_image_232743;
            this.panel2.Controls.Add(this.btnHoaDon);
            this.panel2.Controls.Add(this.btnSanpham);
            this.panel2.Controls.Add(this.btnGIaodich);
            this.panel2.Controls.Add(this.btnDataKH);
            this.panel2.Controls.Add(this.btnDoanhThu);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(982, 99);
            this.panel2.TabIndex = 3;
            // 
            // btnHoaDon
            // 
            this.btnHoaDon.BackColor = System.Drawing.Color.Maroon;
            this.btnHoaDon.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHoaDon.ForeColor = System.Drawing.Color.White;
            this.btnHoaDon.Image = global::Viewer.Properties.Resources.formICON_300x300;
            this.btnHoaDon.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnHoaDon.Location = new System.Drawing.Point(764, 18);
            this.btnHoaDon.Name = "btnHoaDon";
            this.btnHoaDon.Size = new System.Drawing.Size(140, 77);
            this.btnHoaDon.TabIndex = 1;
            this.btnHoaDon.Text = "Hóa Đơn";
            this.btnHoaDon.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHoaDon.UseVisualStyleBackColor = false;
            this.btnHoaDon.Click += new System.EventHandler(this.btnHoadon_Click);
            // 
            // btnSanpham
            // 
            this.btnSanpham.BackColor = System.Drawing.Color.Maroon;
            this.btnSanpham.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSanpham.ForeColor = System.Drawing.Color.White;
            this.btnSanpham.Image = global::Viewer.Properties.Resources.unnamed3;
            this.btnSanpham.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSanpham.Location = new System.Drawing.Point(575, 17);
            this.btnSanpham.Name = "btnSanpham";
            this.btnSanpham.Size = new System.Drawing.Size(158, 78);
            this.btnSanpham.TabIndex = 0;
            this.btnSanpham.Text = "Sản Phẩm";
            this.btnSanpham.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSanpham.UseVisualStyleBackColor = false;
            this.btnSanpham.Click += new System.EventHandler(this.btnSanpham_Click);
            // 
            // btnGIaodich
            // 
            this.btnGIaodich.BackColor = System.Drawing.Color.Maroon;
            this.btnGIaodich.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGIaodich.ForeColor = System.Drawing.Color.White;
            this.btnGIaodich.Image = global::Viewer.Properties.Resources.icon1;
            this.btnGIaodich.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGIaodich.Location = new System.Drawing.Point(391, 16);
            this.btnGIaodich.Name = "btnGIaodich";
            this.btnGIaodich.Size = new System.Drawing.Size(157, 80);
            this.btnGIaodich.TabIndex = 0;
            this.btnGIaodich.Text = "Thanh Toán";
            this.btnGIaodich.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGIaodich.UseVisualStyleBackColor = false;
            this.btnGIaodich.Click += new System.EventHandler(this.btnGIaodich_Click);
            // 
            // btnDataKH
            // 
            this.btnDataKH.BackColor = System.Drawing.Color.Maroon;
            this.btnDataKH.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDataKH.ForeColor = System.Drawing.Color.White;
            this.btnDataKH.Image = global::Viewer.Properties.Resources.multi_user_icon;
            this.btnDataKH.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDataKH.Location = new System.Drawing.Point(208, 18);
            this.btnDataKH.Name = "btnDataKH";
            this.btnDataKH.Size = new System.Drawing.Size(160, 78);
            this.btnDataKH.TabIndex = 0;
            this.btnDataKH.Text = "Data Khách";
            this.btnDataKH.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDataKH.UseVisualStyleBackColor = false;
            this.btnDataKH.Click += new System.EventHandler(this.btnDataKH_Click);
            // 
            // btnDoanhThu
            // 
            this.btnDoanhThu.BackColor = System.Drawing.Color.DarkRed;
            this.btnDoanhThu.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDoanhThu.ForeColor = System.Drawing.Color.White;
            this.btnDoanhThu.Image = global::Viewer.Properties.Resources.thongke;
            this.btnDoanhThu.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDoanhThu.Location = new System.Drawing.Point(32, 17);
            this.btnDoanhThu.Name = "btnDoanhThu";
            this.btnDoanhThu.Size = new System.Drawing.Size(159, 78);
            this.btnDoanhThu.TabIndex = 0;
            this.btnDoanhThu.Text = "Doanh Thu";
            this.btnDoanhThu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDoanhThu.UseVisualStyleBackColor = false;
            this.btnDoanhThu.Click += new System.EventHandler(this.btnDoanhThu_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.BackColor = System.Drawing.Color.Aqua;
            this.btnThoat.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.ForeColor = System.Drawing.Color.Purple;
            this.btnThoat.Location = new System.Drawing.Point(1019, 69);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(91, 36);
            this.btnThoat.TabIndex = 4;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = false;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // ShowForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Viewer.Properties.Resources.login;
            this.ClientSize = new System.Drawing.Size(1196, 781);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pnMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ShowForm";
            this.Text = "Cpanel";
            this.Resize += new System.EventHandler(this.ShowForm_Resize);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pnMain;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnSanpham;
        private System.Windows.Forms.Button btnGIaodich;
        private System.Windows.Forms.Button btnDataKH;
        private System.Windows.Forms.Button btnDoanhThu;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnHoaDon;
    }
}