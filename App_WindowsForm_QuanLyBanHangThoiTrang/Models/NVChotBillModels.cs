using BTO;
using System.Data;
using System.Data.SqlClient;
using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Reporting.WinForms;

namespace Models
{
    public class NVChotBillModels : DatabaseSerivce
    {
        DatabaseSerivce account = new DatabaseSerivce();
        public DataTable LoadAccount()
        {
            var sql = " Select * from account";
            SqlDataAdapter Adapter = new SqlDataAdapter(sql, connection);
            DataTable dt = new DataTable();
            Adapter.Fill(dt);
            return dt;
        }
        public ReportDataSource DSChotBIll(string thang, string nam, string taikhoan)
        {
            //   const String connectionString = @"Data Source=(local);Initial Catalog=ProductOrder;User ID=sa;Password=123456";
            //  SqlConnection cn = new SqlConnection(connectionString);
            var sql = "select c.MaHD,c.MaSP,c.TenSP,c.DonGia,c.SoLuong,b.NgayGiao,b.NhanVien ,(select Sum(DonGia*SoLuong) From HoaDon as b,ChiTietHoaDon as c  where b.MaHD = c.MaHD and SUBSTRING(CONVERT(VARCHAR(50), b.NgayGiao, 120), 1, 4) = '" + nam + "' AND SUBSTRING(CONVERT(VARCHAR(50), b.NgayGiao, 120), 6, 2) = '" + thang + "') AS TongCong From HoaDon as b,ChiTietHoaDon as c  where b.MaHD = c.MaHD and SUBSTRING(CONVERT(VARCHAR(50), b.NgayGiao, 120), 1, 4) = '" + nam + "' AND SUBSTRING(CONVERT(VARCHAR(50), b.NgayGiao, 120), 6, 2) = '" + thang + "' and NhanVien = '" + taikhoan + "'";
            DataSet1 m = new DataSet1();
            SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
            adapter.Fill(m, m.Tables[0].TableName);
            ReportDataSource dt1 = new ReportDataSource("DataSet1", m.Tables[0]);
            return dt1;
        }
    }
}
