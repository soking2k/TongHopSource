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
    public partial class admincp : Form
    {

        admintaikhoan tk = new admintaikhoan();
        adminchotbill cp = new adminchotbill();
        adminLuongNV lnv = new adminLuongNV();

        public admincp(string username)
        {
            InitializeComponent();
            label1.Text = username;
            MaximizeBox = false;
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

        private void btnThoat_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            login c = new login();
            c.Show();
        }

        private void btnTaikhoan_Click(object sender, EventArgs e)
        {
            CallToChildForm(tk);

        }

        private void btnChotBill_Click(object sender, EventArgs e)
        {
            CallToChildForm(cp);

        }

        private void btnLuongNV_Click(object sender, EventArgs e)
        {
            CallToChildForm(lnv);

        }

        private void admincp_Resize(object sender, EventArgs e)
        {
           // pnMain.Height = Convert.ToInt32(0.8 * this.Height);
           // panel2.Width = Convert.ToInt32(0.8 * this.Width);

            // pnMain.Width = Convert.ToInt32(0.9 * this.Width);
        }

        private void admincp_Load(object sender, EventArgs e)
        {

        }
    }
}
