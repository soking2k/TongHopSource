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
    public class AdminLuongNVModels : DatabaseSerivce
    {
        DatabaseSerivce account = new DatabaseSerivce();
        public DataTable DSLuongNV()
        {
            var sql = " Select username,Luong,ThoiGian,GhiChu from LuongNV";
            SqlDataAdapter Adapter = new SqlDataAdapter(sql, connection);
            DataTable dt = new DataTable();
            Adapter.Fill(dt);
            return dt;
        }
        public DataTable LoadAccount()
        {
            var sql = " Select * from account";
            SqlDataAdapter Adapter = new SqlDataAdapter(sql, connection);
            DataTable dt = new DataTable();
            Adapter.Fill(dt);
            return dt;
        }
        public bool CheckLuongNV(string taikhoan, string luong, string thoigian, string ghichu)
        {
            bool kq = false;
            try
            {
                var sql = "Select * From LuongNV Where username=@taikhoan and luong=@luong and thoigian=@thoigian";
                SqlParameter partaikhoan = new SqlParameter("@taikhoan", System.Data.SqlDbType.VarChar);
                partaikhoan.Value = taikhoan;
                SqlParameter parluong = new SqlParameter("@luong", System.Data.SqlDbType.NVarChar);
                parluong.Value = luong;
                SqlParameter parthoigian = new SqlParameter("@thoigian", System.Data.SqlDbType.NVarChar);
                parthoigian.Value = thoigian;
                SqlParameter parghichu = new SqlParameter("@ghichu", System.Data.SqlDbType.NVarChar);
                parghichu.Value = ghichu;
                SqlDataReader reader = ReadDataPars(sql, new[] { partaikhoan, parluong, parthoigian, parghichu });
                if (reader.Read())
                {
                    kq = true;
                }
                return kq;
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            finally
            {
                CloseConnection();
            }
            return kq;
        }
        public bool XoaLuongNV(string taikhoan, string luong, string thoigian, string ghichu)
        {
            bool kq = false;
            try
            {
                var sql = "Delete From LuongNV Where Luong=@Luong and ThoiGian=@thoigian and username=@TaiKhoan";
                SqlParameter partaikhoan = new SqlParameter("@taikhoan", System.Data.SqlDbType.VarChar);
                partaikhoan.Value = taikhoan;
                SqlParameter parluong = new SqlParameter("@luong", System.Data.SqlDbType.NVarChar);
                parluong.Value = luong;
                SqlParameter parthoigian = new SqlParameter("@thoigian", System.Data.SqlDbType.NVarChar);
                parthoigian.Value = thoigian;
                SqlParameter parghichu = new SqlParameter("@ghichu", System.Data.SqlDbType.NVarChar);
                parghichu.Value = ghichu;
                account.Excute(sql, new[] { parluong, parthoigian, parghichu, partaikhoan });
                kq = true;
                return kq;
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            finally
            {
                CloseConnection();
            }
            return kq;
        }
        public bool SuaLuongNV(string taikhoan, string luong, string thoigian, string ghichu)
        {
            bool kq = false;
            try
            {
                var sql = "UPDATE LuongNV SET Luong=@Luong, ThoiGian=@thoigian,ghichu=@ghichu where username=@TaiKhoan";
                SqlParameter partaikhoan = new SqlParameter("@taikhoan", System.Data.SqlDbType.VarChar);
                partaikhoan.Value = taikhoan;
                SqlParameter parluong = new SqlParameter("@luong", System.Data.SqlDbType.NVarChar);
                parluong.Value = luong;
                SqlParameter parthoigian = new SqlParameter("@thoigian", System.Data.SqlDbType.NVarChar);
                parthoigian.Value = thoigian;
                SqlParameter parghichu = new SqlParameter("@ghichu", System.Data.SqlDbType.NVarChar);
                parghichu.Value = ghichu;
                account.Excute(sql, new[] { parluong, parthoigian, parghichu, partaikhoan });
                kq = true;
                return kq;
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            finally
            {
                CloseConnection();
            }
            return kq;
        }
        public bool ThemLuongNV(string taikhoan, string luong, string thoigian, string ghichu)
        {
            bool kq = false;
            try
            {
                var sql = "Insert into LuongNV (username,Luong,ThoiGian,GhiChu) values (@taikhoan,@luong,@thoigian,@ghichu)";
                SqlParameter partaikhoan = new SqlParameter("@taikhoan", System.Data.SqlDbType.VarChar);
                partaikhoan.Value = taikhoan;
                SqlParameter parluong = new SqlParameter("@luong", System.Data.SqlDbType.NVarChar);
                parluong.Value = luong;
                SqlParameter parthoigian = new SqlParameter("@thoigian", System.Data.SqlDbType.NVarChar);
                parthoigian.Value = thoigian;
                SqlParameter parghichu = new SqlParameter("@ghichu", System.Data.SqlDbType.NVarChar);
                parghichu.Value = ghichu;
                account.Excute(sql, new[] { partaikhoan, parluong, parthoigian, parghichu });
                kq = true;
                return kq;
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            finally
            {
                CloseConnection();
            }
            return kq;
        }
    }
}
