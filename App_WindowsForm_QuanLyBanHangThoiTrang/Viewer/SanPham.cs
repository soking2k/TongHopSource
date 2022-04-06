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
    public partial class SanPham : Form
    {
        public SanPham()
        {
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;

            InitializeComponent();
        }
        ConTrollerSanPham da1 = new ConTrollerSanPham();
        public void refreshbang()
        {
            DataTable dt = new DataTable();
            dt = da1.DSSanPham();
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
                dataGridView1.Rows[n].Cells[3].Value = item[3];
                dataGridView1.Rows[n].Cells[4].Value = item[4];
                dataGridView1.Rows[n].Cells[5].Value = item[5].ToString();
                dataGridView1.Rows[n].Cells[6].Value = item[6].ToString();

            }
            dataGridView1.Columns[3].DefaultCellStyle.Format = "0";
            dataGridView1.Columns[4].DefaultCellStyle.Format = "0";



        }
        void LoadComBoBox()
        {
            DataTable dt = new DataTable();
            dt = da1.LoadNhaCungCap();
            comboBox1.DisplayMember = "NhaCungCap";
            comboBox1.DataSource = dt;

        }
        private void SanPham_Load(object sender, EventArgs e)
        {
            LoadComBoBox();
            refreshbang();

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
                txtID.Text = a.ToString();
                txtMasp.Text = b.ToString();
                txtTensp.Text = c.ToString();
                txtGiamua.Text = d.ToString();
                txtGiaban.Text = e.ToString();
                comboBox1.Text = f.ToString();
            }
            catch (Exception ex)
            {

            }
        }

        private void btnThemSua_Click(object sender, EventArgs e)
        {
            string MaSP = txtMasp.Text;
            string TenSP = txtTensp.Text;
            string GiaMua = txtGiamua.Text;
            string GiaBan = txtGiaban.Text;
            string NhaCungCap = comboBox1.Text;
            if (da1.Checksanpham(MaSP, TenSP, GiaMua, GiaBan, NhaCungCap) == false)
            {
                if (da1.ThemSanPham(MaSP, TenSP, GiaMua, GiaBan, NhaCungCap) == true)
                {
                    MessageBox.Show("Thêm Sản Phẩm Thành Công !!!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridView1.Rows.Clear();
                    refreshbang();
                }
                else
                {
                    MessageBox.Show("Thêm Sản Phẩm Thất Bại !!!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Sản Phẩm này đã tồn tại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string id = txtID.Text;
            string MaSP = txtMasp.Text;
            string TenSP = txtTensp.Text;
            string GiaMua = txtGiamua.Text;
            string GiaBan = txtGiaban.Text;
            string NhaCungCap = comboBox1.Text;
            if (da1.SuaSanPham(id,MaSP, TenSP, GiaMua, GiaBan, NhaCungCap) == true)
            {
                MessageBox.Show("Sửa Sản Phẩm Thành Công !!!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridView1.Rows.Clear();
                refreshbang();
            }
            else
            {
                MessageBox.Show("Sửa Sản Phẩm Thất Bại !!!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string id = txtID.Text;
            string MaSP = txtMasp.Text;
            string TenSP = txtTensp.Text;
            string GiaMua = txtGiamua.Text;
            string GiaBan = txtGiaban.Text;
            string NhaCungCap = comboBox1.Text;
            if (da1.XoaSanPham(id, MaSP, TenSP, GiaMua, GiaBan, NhaCungCap) == true)
            {
                MessageBox.Show("Xóa Sản Phẩm Thành Công !!!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridView1.Rows.Clear();
                refreshbang();
            }
            else
            {
                MessageBox.Show("Xóa Sản Phẩm Thất Bại !!!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
