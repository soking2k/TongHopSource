using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Viewer
{
    public partial class ShowForm : Form
    {
        string getuser;
        DataKhach dtkhach = new DataKhach();
        DoanhThu dt = new DoanhThu();
        ThanhToan tt = new ThanhToan();
        SanPham sp = new SanPham();
        //HoaDon hd = new HoaDon();

        public ShowForm(string username)
        {
            InitializeComponent();
            label1.Text = username;
            MaximizeBox = false;
            getuser = username;

        }
        public void test(string username)
        {
        }


        public void CallToChildForm(Form ChildForm)
        {
            if (this.pnMain.Controls.Count > 0)
            {
                this.pnMain.Controls.RemoveAt(0);
            }
            Form fr = ChildForm as Form;
            fr.TopLevel = false;
            fr.Dock = DockStyle.Fill;
            this.pnMain.Controls.Add(fr);
            this.pnMain.Tag = fr;
            fr.Show();
        }
        private void btnDataKH_Click(object sender, EventArgs e)
        {
            // btnDataKH.BackColor = Color.Green;
            CallToChildForm(dtkhach);
        }

        private void btnDoanhThu_Click(object sender, EventArgs e)
        {
            CallToChildForm(dt);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Hide();
            login c = new login();
            c.Show();

        }

        private void btnGIaodich_Click(object sender, EventArgs e)
        {
            CallToChildForm(tt);
        }

        private void btnSanpham_Click(object sender, EventArgs e)
        {
            CallToChildForm(sp);

        }

        private void btnHoadon_Click(object sender, EventArgs e)
        {
            HoaDon hd = new HoaDon(getuser);

            CallToChildForm(hd);

        }

        private void pnMain_Resize(object sender, EventArgs e)
        {

        }

        private void ShowForm_Resize(object sender, EventArgs e)
        {
          //  pnMain.Height = Convert.ToInt32(0.16 * this.Height);
          //  pnMain.Width = Convert.ToInt32(0.8 * this.Height);
          //  btnDetail.Width = Convert.ToInt32(this.Width * 0.15);
           // btnSummary.Width = Convert.ToInt32(this.Width * 0.15);
        }
    }
}
