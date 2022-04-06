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
using Microsoft.Reporting.WinForms;
using Models;

namespace Viewer
{
    public partial class adminchotbill : Form
    {
        ConTrolChotBill ctr = new ConTrolChotBill();
        public adminchotbill()
        {
            InitializeComponent();
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "MM/yyyy";
            LoadAccount();
            this.reportViewer1.Visible = false;
        }

        void LoadAccount()
        {
            DataTable dt = new DataTable();
            dt = ctr.LoadAccount();
            comboBox1.DisplayMember = "username";
            comboBox1.DataSource = dt;

        }
        private void btnThongKe_Click(object sender, EventArgs e)
        {

            this.reportViewer1.LocalReport.DataSources.Clear(); //clear
            var thang = dateTimePicker2.Value.Month.ToString();
            string nam = dateTimePicker2.Value.Year.ToString();
            string taikhoan = comboBox1.Text;
            this.reportViewer1.Visible = true;
            ReportDataSource rds = new ReportDataSource();
            rds = ctr.DSChotBIll(thang,nam,taikhoan);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Viewer.adminchotbill.rdlc";
            this.reportViewer1.LocalReport.DataSources.Clear(); //clear
            this.reportViewer1.LocalReport.DataSources.Add(rds);
            this.reportViewer1.RefreshReport();
        }

        private void adminchotbill_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }
    }
}
