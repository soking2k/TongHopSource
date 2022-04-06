using System;
using Controller;
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
    public partial class admintaikhoan : Form
    {
        public admintaikhoan()
        {
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            InitializeComponent();
        }
        ControlAdminTaiKhoan da1 = new ControlAdminTaiKhoan();
        ControllerAccount da2 = new ControllerAccount();

        private void admintaikhoan_Load(object sender, EventArgs e)
        {
            refeshtaikhoan();
        }
        public void refeshtaikhoan()
        {
            DataTable dt = new DataTable();
            dt = da1.DSTaiKhoan();
            foreach (DataRow item in dt.Rows)
            {
                int n = dataGridView1.Rows.Add();
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    dataGridView1.Rows[i].Cells[0].Value = i + 1;
                }
               // dataGridView1.Rows[n].Cells[0].Value = item[0].ToString();
                dataGridView1.Rows[n].Cells[1].Value = item[1].ToString();
                dataGridView1.Rows[n].Cells[2].Value = item[2].ToString();
                dataGridView1.Rows[n].Cells[3].Value = item[3].ToString();
                dataGridView1.Rows[n].Cells[4].Value = item[4].ToString();
                dataGridView1.Rows[n].Cells[5].Value = item[5].ToString();
                dataGridView1.Rows[n].Cells[6].Value = item[6].ToString();

            }

        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs n)
        {
            try
            {
                DataGridViewRow row = new DataGridViewRow();
                row = dataGridView1.Rows[n.RowIndex];
                string a = row.Cells[0].Value.ToString();
                string b = row.Cells[1].Value.ToString();
                string c = row.Cells[2].Value.ToString();
                string d = row.Cells[3].Value.ToString();
                string e = row.Cells[4].Value.ToString();
                string f = row.Cells[5].Value.ToString();
                string g = row.Cells[6].Value.ToString();
                
                txtTaikhoan.Text = b.ToString();
                txtMatKhau.Text = c.ToString();
                txtEmail.Text = d.ToString();
                txtHoVaTen.Text = e.ToString();
                txtSoDienThoai.Text = f.ToString();
                txtHoatDong.Text = g.ToString();

            }
            catch (Exception ex)
            {

            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string TaiKhoan = txtTaikhoan.Text;
            string MatKhau = txtMatKhau.Text;
            string MatKhauMH = da2.md5(txtMatKhau.Text);
            string Email = txtEmail.Text;
            string HoVaTen = txtHoVaTen.Text;
            string SoDienThoai = txtSoDienThoai.Text;
            string Activity = txtHoatDong.Text;

            if (da1.SuaTaiKhoan(TaiKhoan,MatKhau,MatKhauMH,Email,HoVaTen,SoDienThoai) == true)
            {
                MessageBox.Show("Thêm Thành Công !!!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridView1.Rows.Clear();
                refeshtaikhoan();
            }
            else
            {
                MessageBox.Show("Thêm Thất Bại !!!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDuyet_Click(object sender, EventArgs e)
        {
            string TaiKhoan = txtTaikhoan.Text;          
            string Activity = txtHoatDong.Text;

            if (da1.DuyetTK(TaiKhoan, Activity) == true)
            {
                MessageBox.Show("Thêm Thành Công !!!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridView1.Rows.Clear();
                refeshtaikhoan();
            }
            else
            {
                MessageBox.Show("Thêm Thất Bại !!!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnKhoa_Click(object sender, EventArgs e)
        {
            string TaiKhoan = txtTaikhoan.Text;
            string Activity = txtHoatDong.Text;

            if (da1.KhoaTK(TaiKhoan, Activity) == true)
            {
                MessageBox.Show("Khóa Tài Khoản Thành Công !!!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridView1.Rows.Clear();
                refeshtaikhoan();
            }
            else
            {
                MessageBox.Show("Thêm Thất Bại !!!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void admintaikhoan_Resize(object sender, EventArgs e)
        {
  
          //  txtTaikhoan.Width = Convert.ToInt32(0.2 * this.Width);
         //   txtEmail.Width = Convert.ToInt32(0.2 * this.Width);
         //   txtHoVaTen.Width = Convert.ToInt32(0.2 * this.Width);
         //   txtHoatDong.Width = Convert.ToInt32(0.2 * this.Width);
         //   txtMatKhau.Width = Convert.ToInt32(0.2 * this.Width);
         //   txtSoDienThoai.Width = Convert.ToInt32(0.2 * this.Width);

        }
    }
}

