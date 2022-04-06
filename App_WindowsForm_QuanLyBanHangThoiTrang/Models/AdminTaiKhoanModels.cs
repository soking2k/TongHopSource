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
    public class AdminTaiKhoanModels : DatabaseSerivce
    {
        DatabaseSerivce account = new DatabaseSerivce();
        public DataTable DSTaiKhoan()
        {
            var sql = " Select id,username,Password_hint,Email,FullName,Phone,Activity from Account";
            SqlDataAdapter Adapter = new SqlDataAdapter(sql, connection);
            DataTable dt = new DataTable();
            Adapter.Fill(dt);
            return dt;
        }
        public bool SuaTaiKhoan(string TaiKhoan, string MatKhau, string MatKhauMH, string Email, string HoVaTen, string SoDienThoai)
        {
            bool kq = false;
            try
            {
                var sql = "UPDATE Account SET PassWord_hint=@MatKhau,PassWord=@MatKhauMH,Email=@Email,FullName=@HoVaTen,Phone=@SoDienThoai where username=@TaiKhoan";
                SqlParameter parTaiKhoan = new SqlParameter("@TaiKhoan", System.Data.SqlDbType.VarChar);
                parTaiKhoan.Value = TaiKhoan;
                SqlParameter parMatKhau = new SqlParameter("@MatKhau", System.Data.SqlDbType.NVarChar);
                parMatKhau.Value = MatKhau;
                SqlParameter parMatKhauMH = new SqlParameter("@MatKhauMH", System.Data.SqlDbType.NVarChar);
                parMatKhauMH.Value = MatKhauMH;
                SqlParameter parEmail = new SqlParameter("@Email", System.Data.SqlDbType.NVarChar);
                parEmail.Value = Email;
                SqlParameter parHoVaTen = new SqlParameter("@HoVaTen", System.Data.SqlDbType.NVarChar);
                parHoVaTen.Value = HoVaTen;
                SqlParameter parSoDienThoai = new SqlParameter("@SoDienThoai", System.Data.SqlDbType.NVarChar);
                parSoDienThoai.Value = SoDienThoai;

                account.Excute(sql, new[] { parMatKhau, parMatKhauMH, parEmail, parHoVaTen, parSoDienThoai, parTaiKhoan });
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

        public bool DuyetTK(string TaiKhoan, string Activity)
        {
            bool kq = false;
            try
            {
                var sql = "UPDATE Account SET Activity='1' where username=@TaiKhoan";
                SqlParameter parTaiKhoan = new SqlParameter("@TaiKhoan", System.Data.SqlDbType.VarChar);
                parTaiKhoan.Value = TaiKhoan;
                SqlParameter parActivity = new SqlParameter("@Activity", System.Data.SqlDbType.NVarChar);
                parActivity.Value = Activity;
                account.Excute(sql, new[] { parTaiKhoan, parActivity });
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
        public bool KhoaTK(string TaiKhoan, string Activity)
        {
            bool kq = false;
            try
            {
                var sql = "UPDATE Account SET Activity='0' where username=@TaiKhoan";
                SqlParameter parTaiKhoan = new SqlParameter("@TaiKhoan", System.Data.SqlDbType.VarChar);
                parTaiKhoan.Value = TaiKhoan;
                SqlParameter parActivity = new SqlParameter("@Activity", System.Data.SqlDbType.NVarChar);
                parActivity.Value = Activity;
                account.Excute(sql, new[] { parTaiKhoan, parActivity });
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
