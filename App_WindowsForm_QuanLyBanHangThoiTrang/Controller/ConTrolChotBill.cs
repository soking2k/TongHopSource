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
    public class ConTrolChotBill
    {
        NVChotBillModels da1 = new NVChotBillModels();
        public DataTable LoadAccount()
        {
            return da1.LoadAccount();

        }
        public ReportDataSource DSChotBIll(string thang, string nam, string taikhoan)
        {
            return da1.DSChotBIll(thang, nam, taikhoan);

        }
    }
}
