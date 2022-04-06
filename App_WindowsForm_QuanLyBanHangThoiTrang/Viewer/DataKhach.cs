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
using System.Linq.Expressions;

namespace Viewer
{
    public partial class DataKhach : Form
    {
        public DataKhach()
        {
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
           // this.ControlBox = false;
            InitializeComponent();
        }
        ControlDataKhach da1 = new ControlDataKhach();

        private void DataKhach_Load(object sender, EventArgs e)
        {
            refreshbang();
            LoadGioiTinh();
        }
        void LoadGioiTinh()
        {
            DataTable dt = new DataTable();
            dt = da1.LoadGioiTinh();
            comboBox1.DisplayMember = "GioiTinh";
            comboBox1.DataSource = dt;

        }
        public void refreshbang()
        {
            DataTable dt = new DataTable();
            dt = da1.Laydata();
            foreach (DataRow item in dt.Rows)
            {
                int n = dataGridView1.Rows.Add();
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    dataGridView1.Rows[i].Cells[0].Value = i + 1;
                }
                //dataGridView1.Rows[n].Cells[0].Value = item[0].ToString();
                dataGridView1.Rows[n].Cells[1].Value = item[1].ToString();
                dataGridView1.Rows[n].Cells[2].Value = item[2].ToString();
                dataGridView1.Rows[n].Cells[3].Value = item[3].ToString();
                dataGridView1.Rows[n].Cells[4].Value = item[4].ToString();
                dataGridView1.Rows[n].Cells[5].Value = item[5].ToString();
                dataGridView1.Rows[n].Cells[6].Value = item[6].ToString();
                dataGridView1.Rows[n].Cells[7].Value = item[7].ToString();

            }
        }
        public void ChangeInfoForm(string a,string b, string c, string d, string e,string f, string g, string h)
        {
            txtID.Text = a.ToString();
            comboBox1.Text = b.ToString();
            txtFullName.Text = c.ToString();
            txtEmail.Text = d.ToString();
            txtPhone.Text = e.ToString();
            txtDiaChi.Text = f.ToString();
            txtNgheNghiep.Text = g.ToString();
            txtDanhGia.Text = h.ToString();

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnThemSua_Click(object sender, EventArgs e)
        {
           
            string FullName = txtFullName.Text;
            string GioiTinh = comboBox1.Text;
            string DiaChi = txtDiaChi.Text;
            string Email = txtEmail.Text;
            string Phone = txtPhone.Text;
            string NgheNghiep = txtNgheNghiep.Text;
            string DanhGia = txtDanhGia.Text;

            if (da1.CheckTonTai(FullName, GioiTinh, DiaChi, Email, Phone, NgheNghiep, DanhGia) == false)
            {
                if (da1.ThemKH(FullName, GioiTinh, DiaChi, Email, Phone, NgheNghiep, DanhGia) == true)
                {
                    MessageBox.Show("Thêm Khách Hàng Thành Công !!!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridView1.Rows.Clear();
                    refreshbang();
                }
                else
                {
                    MessageBox.Show("Thêm Khách Hàng Thất Bại !!!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Khách hàng đã tồn tại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            string id = txtID.Text;
            string FullName = txtFullName.Text;
            string GioiTinh = comboBox1.Text;
            string DiaChi = txtDiaChi.Text;
            string Email = txtEmail.Text;
            string Phone = txtPhone.Text;
            string NgheNghiep = txtNgheNghiep.Text;
            string DanhGia = txtDanhGia.Text;

           // if (da1.CheckTonTai(FullName, GioiTinh, DiaChi, Email, Phone, NgheNghiep, DanhGia) == true)
           // {
                if (da1.SuaKH(id,FullName, GioiTinh, DiaChi, Email, Phone, NgheNghiep, DanhGia) == true)
                {
                    MessageBox.Show("Cập nhật Khách Hàng Thành Công !!!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridView1.Rows.Clear();
                    refreshbang();
                }
                else
                {
                    MessageBox.Show("Cập nhật Khách Hàng Thất Bại !!!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
       //     }
          //  else
           // {
            //    MessageBox.Show("Khách hàng không tồn tại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
          //  }

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
                string h = row.Cells[7].Value.ToString();

                  txtID.Text = a;
                comboBox1.Text = c;
                txtFullName.Text = b;
                txtDiaChi.Text = d;
                txtEmail.Text = e;
                txtPhone.Text = f;
                txtNgheNghiep.Text = g;
                 txtDanhGia.Text = h;

            }
            catch(Exception ex)
            {

            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
           
            string FullName = txtFullName.Text;
            string GioiTinh = comboBox1.Text;
            string DiaChi = txtDiaChi.Text;
            string Email = txtEmail.Text;
            string Phone = txtPhone.Text;
            string NgheNghiep = txtNgheNghiep.Text;
            string DanhGia = txtDanhGia.Text;
         
            if (da1.XoaKH(FullName, GioiTinh, DiaChi, Email, Phone, NgheNghiep, DanhGia) == true)
            {
                MessageBox.Show("Xóa khách hàng thành công");
            
            }
            else
            {
                MessageBox.Show("Xóa Khách Hàng Thất Bại");
            }
            dataGridView1.Rows.Clear();
            refreshbang();
        }

    }
}
