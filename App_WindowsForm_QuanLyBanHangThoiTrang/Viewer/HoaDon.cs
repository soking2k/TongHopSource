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
using System.Data.SqlClient;

namespace Viewer
{
    public partial class HoaDon : Form
    {
        string getuser1;
        public HoaDon(string getuser)
        {
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            InitializeComponent();
            dateTimePicker1.CustomFormat = "yyyy/MM/dd";
            dateTimePicker2.CustomFormat = "yyyy/MM/dd";
            getuser1 = getuser;
        }
        ConTrollerHoaDon da1 = new ConTrollerHoaDon();

        public void refreshHoaDon()
        {
            DataTable dt = new DataTable();
            dt = da1.DSHoaDon();
           
            foreach (DataRow item in dt.Rows)
            {
                int n = dataGridView1.Rows.Add();              
                dataGridView1.Rows[n].Cells[0].Value = item[0].ToString();
                dataGridView1.Rows[n].Cells[1].Value = item[1];
                dataGridView1.Rows[n].Cells[2].Value = item[2];
                dataGridView1.Rows[n].Cells[3].Value = item[3].ToString();

            }
            dataGridView1.Columns[1].DefaultCellStyle.Format  = "yyyy/MM/dd";
            dataGridView1.Columns[2].DefaultCellStyle.Format = "yyyy/MM/dd";

        }
        public void refreshCTHoaDon(string maxuathd)
        {
            //string maxuathd = txtMaXuatHD.Text;

            DataTable dt = new DataTable();
            dt = da1.DSCTHoaDon(maxuathd);
            foreach (DataRow item in dt.Rows)
            {
                int n = dataGridView2.Rows.Add();
                dataGridView2.Rows[n].Cells[0].Value = item[0].ToString();
                dataGridView2.Rows[n].Cells[1].Value = item[1].ToString();
                dataGridView2.Rows[n].Cells[2].Value = item[2].ToString();
                dataGridView2.Rows[n].Cells[3].Value = item[3].ToString();
                dataGridView2.Rows[n].Cells[4].Value = item[4].ToString();

            }
        }

        private void HoaDon_Load(object sender, EventArgs e)
        {

            LoadMaHoaDon();
            LoadLoaiSP();
            refreshHoaDon();
          //  refreshCTHoaDon();
        }

        private void btnThemSua_Click(object sender, EventArgs e)
        {
            string nv = getuser1;
            string MaHD = txtMahoadon.Text;
            string NgayDat = dateTimePicker1.Text;
            string NgayGiao = dateTimePicker2.Text;

            if (da1.CheckHoaDon(MaHD, NgayDat, NgayGiao) == false)
            {
                if (da1.ThemHoaDon(MaHD, NgayDat, NgayGiao,nv) == true)
                {
                    MessageBox.Show("Thêm Thành Công !!!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridView1.Rows.Clear();
                    refreshHoaDon();
                }
                else
                {
                    MessageBox.Show("Thêm Thất Bại !!!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show(" này đã tồn tại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                comboBox1.Text = a.ToString();
                txtMahoadon.Text = a.ToString();
                dateTimePicker1.Text = b.ToString();
                dateTimePicker2.Text = c.ToString();
            }
            catch (Exception ex)
            {

            }
        }
  
        void LoadMaSanPham()
        {
            string MaLoai = comboBox4.Text;
            DataTable dt = new DataTable();
            dt = da1.LoadMaSanPham(MaLoai);
            comboBox3.DisplayMember = "MaSP";
            comboBox3.DataSource = dt;

        }
        void LoadTenSanPham()
        {
            string MaLoai = comboBox4.Text;
            DataTable dt = new DataTable();
            dt = da1.LoadMaSanPham(MaLoai);
            comboBox2.DisplayMember = "TenSP";
            comboBox2.DataSource = dt;

        }
        void LoadMaHoaDon()
        {
            DataTable dt = new DataTable();
            dt = da1.LoadMaHoaDon();
            comboBox1.DisplayMember = "MaHD";
            comboBox1.DataSource = dt;

        }
        void LoadLoaiSP()
        {
            DataTable dt = new DataTable();
            dt = da1.LoadLoaiSP();
            comboBox4.DisplayMember = "LoaiSP";
            comboBox4.DataSource = dt;
            LoadTenSanPham();
            LoadMaSanPham();
        }
        private void btnSua_Click(object sender, EventArgs e)
        {

            string MaHD = txtMahoadon.Text;
            string NgayDat = dateTimePicker1.Text;
            string NgayGiao = dateTimePicker2.Text;
            if (da1.SuaHoaDon(MaHD, NgayDat, NgayGiao) == true)
            {
                MessageBox.Show("Thêm Thành Công !!!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridView1.Rows.Clear();
                refreshHoaDon();
            }
            else
            {
                MessageBox.Show("Thêm Thất Bại !!!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string MaHD = txtMahoadon.Text;
            string NgayDat = dateTimePicker1.Text;
            string NgayGiao = dateTimePicker2.Text;
            if (da1.XoaHoaDon(MaHD, NgayDat, NgayGiao) == true)
            {
                MessageBox.Show("Thêm Thành Công !!!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridView1.Rows.Clear();
                refreshHoaDon();
            }
            else
            {
                MessageBox.Show("Thêm Thất Bại !!!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXuatHoaDon_Click(object sender, EventArgs e)
        {
            dataGridView2.Visible = true;
            dataGridView2.Rows.Clear();
            string maxuathd = comboBox1.Text;
            refreshCTHoaDon(maxuathd);

        }

        private void btnThemCTHD_Click(object sender, EventArgs e)
        {
            string MaHD = comboBox1.Text;
            string MaSP = comboBox3.Text;
            string TenSP = comboBox2.Text;
            string DonGia = txtDonGia.Text;
            string SoLuong = txtSoLuong.Text;

            if (da1.CheckCTHoaDon(MaHD, MaSP, TenSP, DonGia, SoLuong) == false)
            {
                if (da1.ThemCTHoaDon(MaHD, MaSP, TenSP, DonGia, SoLuong) == true)
                {
                    MessageBox.Show("Thêm Thành Công !!!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridView2.Rows.Clear();
                    refreshCTHoaDon(MaHD);
                }
                else
                {
                    MessageBox.Show("Thêm Thất Bại !!!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show(" này đã tồn tại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    

        private void btnXoaCTHD_Click(object sender, EventArgs e)
        {
            string MaHD = comboBox1.Text;
            string MaSP = comboBox3.Text;
            string TenSP = comboBox2.Text;
            string DonGia = txtDonGia.Text;
            string SoLuong = txtSoLuong.Text;
            if (da1.XoaCTHoaDon(MaHD, MaSP, TenSP, DonGia, SoLuong) == true)
            {
                MessageBox.Show("Thêm Thành Công !!!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridView2.Rows.Clear();
                refreshCTHoaDon(MaHD);
            }
            else
            {
                MessageBox.Show("Thêm Thất Bại !!!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void dataGridView2_CellMouseClick(object sender, DataGridViewCellMouseEventArgs n)
        {
            try
            {
                DataGridViewRow row = new DataGridViewRow();
                row = dataGridView2.Rows[n.RowIndex];
                string a = row.Cells[0].Value.ToString();
                string b = row.Cells[1].Value.ToString();
                string c = row.Cells[2].Value.ToString();
                string d = row.Cells[3].Value.ToString();
                string e = row.Cells[4].Value.ToString();
                comboBox1.Text = a.ToString();
                comboBox3.Text = b.ToString();
                comboBox2.Text = c.ToString();
                txtDonGia.Text = d.ToString();
                txtSoLuong.Text = e.ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show("noooooooo!!!");
            }
        }

        private void btnInHoaDon_Click(object sender, EventArgs e)
        {
            string MaHD = comboBox1.Text;

            ShowBill a = new ShowBill(MaHD);
            a.Show();
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadMaSanPham();
            LoadTenSanPham();

        }

        private void comboBox4_SelectedValueChanged(object sender, EventArgs e)
        {
            LoadMaSanPham();
            LoadTenSanPham();
        }
    }
}
