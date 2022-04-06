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
    public partial class adminLuongNV : Form
    {
        public adminLuongNV()
        {

            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;

            InitializeComponent();
        }
        ControllerLuongNV da1 = new ControllerLuongNV();
        public void refreshLuongNV()
        {
            DataTable dt = new DataTable();
            dt = da1.DSLuongNV();
            foreach (DataRow item in dt.Rows)
            {
                int n = dataGridView1.Rows.Add();
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    dataGridView1.Rows[i].Cells[0].Value = i + 1;
                }
                dataGridView1.Rows[n].Cells[1].Value = item[0].ToString();
                dataGridView1.Rows[n].Cells[2].Value = item[1];
                dataGridView1.Rows[n].Cells[3].Value = item[2].ToString();
                dataGridView1.Rows[n].Cells[4].Value = item[3].ToString();


            }
            dataGridView1.Columns[1].DefaultCellStyle.Format = "0";

        }
        void LoadAccount()
        {
            DataTable dt = new DataTable();
            dt = da1.LoadAccount();
            comboBox1.DisplayMember = "username";
            comboBox1.DataSource = dt;

        }
        private void adminLuongNV_Load(object sender, EventArgs e)
        {
            LoadAccount();
            refreshLuongNV();
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy/MM/dd";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string taikhoan = comboBox1.Text;
            string luong = txtLuong.Text;
            string thoigian = dateTimePicker1.Text;
            string ghichu = txtghichu.Text;
            if (da1.CheckLuongNV(taikhoan, luong, thoigian, ghichu) == false)
            {
                if (da1.ThemLuongNV(taikhoan, luong, thoigian, ghichu) == true)
                {
                    MessageBox.Show("Thêm Thành Công !!!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridView1.Rows.Clear();
                    refreshLuongNV();
                }
                else
                {
                    MessageBox.Show("Thêm Thất Bại !!!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show(" đã tồn tại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs n)
        {
            try
            {
                DataGridViewRow row = new DataGridViewRow();
                row = dataGridView1.Rows[n.RowIndex];
                string a = row.Cells[1].Value.ToString();
                string b = row.Cells[2].Value.ToString();
                string c = row.Cells[3].Value.ToString();
                string d = row.Cells[4].Value.ToString();


                comboBox1.Text = a.ToString();
                txtLuong.Text = b.ToString();
                dateTimePicker1.Text = c.ToString();
                txtghichu.Text = d.ToString();

            }
            catch (Exception ex)
            {

            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string taikhoan = comboBox1.Text;
            string luong = txtLuong.Text;
            string thoigian = dateTimePicker1.Text;
            string ghichu = txtghichu.Text;
            if (da1.SuaLuongNV(taikhoan, luong, thoigian, ghichu) == true)
            {
                MessageBox.Show("Sửa Thành Công !!!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridView1.Rows.Clear();
                refreshLuongNV();
            }
            else
            {
                MessageBox.Show("Thêm Thất Bại !!!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string taikhoan = comboBox1.Text;
            string luong = txtLuong.Text;
            string thoigian = dateTimePicker1.Text;
            string ghichu = txtghichu.Text;
            if (da1.XoaLuongNV(taikhoan, luong, thoigian, ghichu) == true)
            {
                MessageBox.Show("Xóa Thành Công !!!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridView1.Rows.Clear();
                refreshLuongNV();
            }
            else
            {
                MessageBox.Show("Thêm Thất Bại !!!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
