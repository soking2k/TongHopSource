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
    public partial class ShowBill : Form
    {
        string x;
        public ShowBill(string MaHD)
        {
             x = MaHD;
            // MessageBox.Show(MaHD);

            InitializeComponent();
        }
       public void xuatHD(string MaHD)
        {
            ControllerAccount ctr = new ControllerAccount();
            ReportDataSource rds = new ReportDataSource();
            rds = ctr.ShowBill(MaHD);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Viewer.ShowBill.rdlc";
            this.reportViewer1.LocalReport.DataSources.Clear(); //clear
            this.reportViewer1.LocalReport.DataSources.Add(rds);
            this.reportViewer1.RefreshReport();
            this.reportViewer1.RefreshReport();
        }
        private void ShowBill_Load(object sender, EventArgs e)
        {
            xuatHD(x);
        }
    }
}
