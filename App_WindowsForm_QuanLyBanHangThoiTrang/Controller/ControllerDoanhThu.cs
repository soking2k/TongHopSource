using BTO;
using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Microsoft.Reporting.WinForms;

namespace Controller
{

    public class ControllerDoanhThu
    {
        DoanhThuModels dt = new DoanhThuModels();
        public ReportDataSource DoanhThuNgay(string thedate)
        {
            return dt.DoanhThuNgay(thedate);

        }
        public ReportDataSource DoanhThuThang(string thang, string nam)
        {
            return dt.DoanhThuThang(thang, nam);

        }
        public ReportDataSource DoanhThuKhoang(string theDate1, string theDate2)
        {
            return dt.DoanhThuKhoang(theDate1, theDate2);

        }
    }
}
