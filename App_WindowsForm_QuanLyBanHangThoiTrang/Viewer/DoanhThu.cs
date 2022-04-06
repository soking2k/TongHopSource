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
    public partial class DoanhThu : Form
    {
        public DoanhThu()
        {
            InitializeComponent();
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            radioButton1.Checked = true;
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "MM/yyyy";
            dateTimePicker3.Format = DateTimePickerFormat.Custom;
            dateTimePicker3.CustomFormat = "dd/MM/yyyy";
            dateTimePicker4.Format = DateTimePickerFormat.Custom;
            dateTimePicker4.CustomFormat = "dd/MM/yyyy";
            //  this.reportViewer1.Visible = true;
        }

        private void DoanhThu_Load(object sender, EventArgs e)
        {
            
       
        }
        ControllerDoanhThu ctr = new ControllerDoanhThu();

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                this.reportViewer1.LocalReport.DataSources.Clear(); //clear
                string theDate = dateTimePicker1.Value.ToShortDateString();
                this.reportViewer1.Visible = true;
                ReportDataSource rds = new ReportDataSource();
                rds = ctr.DoanhThuNgay(theDate);
                this.reportViewer1.LocalReport.ReportEmbeddedResource = "Viewer.ReportDoanhThu.rdlc";
                this.reportViewer1.LocalReport.DataSources.Clear(); //clear
                this.reportViewer1.LocalReport.DataSources.Add(rds);
                this.reportViewer1.RefreshReport(); 
            }
            else if (radioButton2.Checked)
            {
                this.reportViewer1.LocalReport.DataSources.Clear(); //clear
                var thang = dateTimePicker2.Value.Month.ToString();
                string nam = dateTimePicker2.Value.Year.ToString();
                this.reportViewer1.Visible = true;
                ReportDataSource rds = new ReportDataSource();
                rds = ctr.DoanhThuThang(thang,nam);
                this.reportViewer1.LocalReport.ReportEmbeddedResource = "Viewer.ReportDoanhThu.rdlc";
                this.reportViewer1.LocalReport.DataSources.Clear(); //clear
                this.reportViewer1.LocalReport.DataSources.Add(rds);
                this.reportViewer1.RefreshReport();
            }
            else if (radioButton3.Checked)
            {
                string theDate1 = dateTimePicker3.Value.ToShortDateString();
                string theDate2 = dateTimePicker4.Value.ToShortDateString();
                this.reportViewer1.Visible = true;
                ReportDataSource rds = new ReportDataSource();
                rds = ctr.DoanhThuKhoang(theDate1, theDate2);
                this.reportViewer1.LocalReport.ReportEmbeddedResource = "Viewer.ReportDoanhThu.rdlc";
                this.reportViewer1.LocalReport.DataSources.Clear(); //clear
                this.reportViewer1.LocalReport.DataSources.Add(rds);
                this.reportViewer1.RefreshReport();
            }
                /*
                this.reportViewer1.Visible = true;
                ControllerAccount ctr = new ControllerAccount();
                ReportDataSource rds = new ReportDataSource();
                rds = ctr.LayDS1();
                this.reportViewer1.LocalReport.ReportEmbeddedResource = "Viewer.ReportDoanhThu.rdlc";
                //  ReportParameter dthu = new ReportParameter("DoanhThu","1");
                //   this.reportViewer1.LocalReport.SetParameters(dthu);
                this.reportViewer1.LocalReport.DataSources.Clear(); //clear
                this.reportViewer1.LocalReport.DataSources.Add(rds);
                this.reportViewer1.RefreshReport();*/
            }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            dateTimePicker1.Enabled = true;
            dateTimePicker2.Enabled = false;
            dateTimePicker3.Enabled = false;
            dateTimePicker4.Enabled = false;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            dateTimePicker1.Enabled = false;
            dateTimePicker2.Enabled = true;
            dateTimePicker3.Enabled = false;
            dateTimePicker4.Enabled = false;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            dateTimePicker1.Enabled = false;
            dateTimePicker2.Enabled = false;
            dateTimePicker3.Enabled = true;
            dateTimePicker4.Enabled = true;
        }
    }
}
