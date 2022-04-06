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
    public partial class ThanhToan : Form
    {
        public ThanhToan()
        {
            InitializeComponent();
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            refreshbang();
            LoadComBoBox();
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy/MM/dd hh:mm:ss";
        }
        ConTrollerThanhTOan da1 = new ConTrollerThanhTOan();
        public void refreshbang()
        {
            DataTable dt = new DataTable();
            dt = da1.DSThanhToan();
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
               // dataGridView1.Rows[n].Cells[7].Value = item[7].ToString();

            }
        }
        void LoadComBoBox()
        {
            DataTable dt = new DataTable();
            dt = da1.LoadHinhThucGD();
            comboBox1.DisplayMember = "HinhThuc";
            comboBox1.DataSource = dt;

        }
        public void ChangeInfoForm(string a, string b, string c, string d, string e, string f, string g, string h)
        {
            txtID.Text = a.ToString();
            txtFullName.Text = c.ToString();
            txtMagiaodich.Text = d.ToString();
            txtSotien.Text = e.ToString();
            comboBox1.Text = f.ToString();
            txtGhichu.Text = g.ToString();
            dateTimePicker1.Text = h.ToString();

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

                txtID.Text = a.ToString();
                txtFullName.Text = b.ToString();
                txtMagiaodich.Text = c.ToString();
                txtSotien.Text = d.ToString();
                comboBox1.Text = e.ToString();
                txtGhichu.Text = f.ToString();
                dateTimePicker1.Text =g.ToString();
            }
            catch (Exception ex)
            {

            }
        }

        private void btnThemSua_Click(object sender, EventArgs e)
        {
            string FullName = txtFullName.Text;
            string MaGiaoDich = txtMagiaodich.Text;
            string SoTien = txtSotien.Text;
            string HinhThuc = comboBox1.Text;
            string GhiChu = txtGhichu.Text;
            string date = dateTimePicker1.Text;
            if (da1.CheckThanhToan(FullName, MaGiaoDich, SoTien, HinhThuc, GhiChu, date) == false)
            {
                if (da1.ThemThanhToan(FullName, MaGiaoDich, SoTien, HinhThuc, GhiChu, date) == true)
                {
                    MessageBox.Show("Thêm Thanh Toán Thành Công !!!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridView1.Rows.Clear();
                    refreshbang();
                }
                else
                {
                    MessageBox.Show("Thêm Thanh Toán Thất Bại !!!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Thanh Toán này đã tồn tại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string id = txtID.Text;
            string FullName = txtFullName.Text;
            string MaGiaoDich = txtMagiaodich.Text;
            string SoTien = txtSotien.Text;
            string HinhThuc = comboBox1.Text;
            string GhiChu = txtGhichu.Text;
            string date = dateTimePicker1.Text;
        //    if (da1.SuaThanhToan(id,FullName, MaGiaoDich, SoTien, HinhThuc, GhiChu, date) == false)
          //  {
                if (da1.SuaThanhToan(id, FullName, MaGiaoDich, SoTien, HinhThuc, GhiChu, date) == true)
                {
                    MessageBox.Show("Cập Nhật Thanh Toán Thành Công !!!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridView1.Rows.Clear();
                    refreshbang();
                }
                else
                {
                    MessageBox.Show("Cập Nhật Thanh Toán Thất Bại !!!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
        //    }
           // else
          //  {
           //     MessageBox.Show("Thanh Toán này đã tồn tại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
          //  }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string id = txtID.Text;
            string FullName = txtFullName.Text;
            string MaGiaoDich = txtMagiaodich.Text;
            string SoTien = txtSotien.Text;
            string HinhThuc = comboBox1.Text;
            string GhiChu = txtGhichu.Text;
            string date = dateTimePicker1.Text;
            //    if (da1.SuaThanhToan(id,FullName, MaGiaoDich, SoTien, HinhThuc, GhiChu, date) == false)
            //  {
            if (da1.XoaThanhToan( FullName, MaGiaoDich, SoTien, HinhThuc, GhiChu, date) == true)
            {
                MessageBox.Show("Xóa Thanh Toán Thành Công !!!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridView1.Rows.Clear();
                refreshbang();
            }
            else
            {
                MessageBox.Show("Xóa Thanh Toán Thất Bại !!!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //    }
            // else
            //  {
            //     MessageBox.Show("Thanh Toán này đã tồn tại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //  }
        }
    }
}
