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
    public class DoanhThuModels : DatabaseSerivce
    {
        // Xuất Doanh Thu Ngày
        public ReportDataSource DoanhThuNgay(string thedate)
        {
            //   const String connectionString = @"Data Source=(local);Initial Catalog=ProductOrder;User ID=sa;Password=123456";
            //  SqlConnection cn = new SqlConnection(connectionString);
            var sql = "select c.MaHD,c.MaSP,c.TenSP,c.DonGia,c.SoLuong,b.NgayGiao ,(select SUM(DonGia*SoLuong) from ChiTietHoaDon as a, HoaDon as b where a.MaHD = b.MaHD and b.NgayGiao='" + thedate + "') AS DoanhThu From HoaDon as b,ChiTietHoaDon as c  where b.MaHD = c.MaHD and b.NgayGiao='" + thedate + "'";
            DataSet2 m = new DataSet2();
            SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
            adapter.Fill(m, m.Tables[0].TableName);
            ReportDataSource dt1 = new ReportDataSource("DataSet1", m.Tables[0]);
            return dt1;
        }
        // Xuất Doanh Thu Tháng
        public ReportDataSource DoanhThuThang(string thang, string nam)
        {
            //   const String connectionString = @"Data Source=(local);Initial Catalog=ProductOrder;User ID=sa;Password=123456";
            //  SqlConnection cn = new SqlConnection(connectionString);
            var sql = "select c.MaHD,c.MaSP,c.TenSP,c.DonGia,c.SoLuong,b.NgayGiao ,(select Sum(DonGia*SoLuong) From HoaDon as b,ChiTietHoaDon as c  where b.MaHD = c.MaHD and SUBSTRING(CONVERT(VARCHAR(50), b.NgayGiao, 120), 1, 4) = '" + nam + "' AND SUBSTRING(CONVERT(VARCHAR(50), b.NgayGiao, 120), 6, 2) = '" + thang + "') AS DoanhThu From HoaDon as b,ChiTietHoaDon as c  where b.MaHD = c.MaHD and SUBSTRING(CONVERT(VARCHAR(50), b.NgayGiao, 120), 1, 4) = '" + nam + "' AND SUBSTRING(CONVERT(VARCHAR(50), b.NgayGiao, 120), 6, 2) = '" + thang + "'";
            DataSet2 m = new DataSet2();
            SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
            adapter.Fill(m, m.Tables[0].TableName);
            ReportDataSource dt1 = new ReportDataSource("DataSet1", m.Tables[0]);
            return dt1;
        }
        // Xuất Doanh Thu Khoảng
        public ReportDataSource DoanhThuKhoang(string theDate1, string theDate2)
        {
            //   const String connectionString = @"Data Source=(local);Initial Catalog=ProductOrder;User ID=sa;Password=123456";
            //  SqlConnection cn = new SqlConnection(connectionString);
            var sql = "select c.MaHD,c.MaSP,c.TenSP,c.DonGia,c.SoLuong,b.NgayGiao ,(select Sum(DonGia*SoLuong) From HoaDon as b,ChiTietHoaDon as c  where b.MaHD = c.MaHD and b.NgayGiao >='" + theDate1 + "' AND b.NgayGiao <= '" + theDate2 + "') AS DoanhThu From HoaDon as b,ChiTietHoaDon as c  where b.MaHD = c.MaHD and b.NgayGiao >='" + theDate1 + "' AND b.NgayGiao <= '" + theDate2 + "'";
            DataSet2 m = new DataSet2();
            SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
            adapter.Fill(m, m.Tables[0].TableName);
            ReportDataSource dt1 = new ReportDataSource("DataSet1", m.Tables[0]);
            return dt1;
        }
    }
}
