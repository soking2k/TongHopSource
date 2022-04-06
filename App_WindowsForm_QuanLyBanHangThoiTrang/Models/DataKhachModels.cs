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
   public class DataKhachModels : DatabaseSerivce
    {
        DatabaseSerivce account = new DatabaseSerivce();
        public DataTable Laydata()
        {
            var sql = " Select * from KhachHang";
            SqlDataAdapter Adapter = new SqlDataAdapter(sql, connection);
            DataTable dt = new DataTable();
            Adapter.Fill(dt);
            return dt;
        }
        public DataTable LoadGioiTinh()
        {
            var sql = " Select * from GioiTinh";
            SqlDataAdapter Adapter = new SqlDataAdapter(sql, connection);
            DataTable dt = new DataTable();
            Adapter.Fill(dt);
            return dt;
        }
        public bool CheckTonTai(string FullName, string GioiTinh, String DiaChi, String Email, String Phone, String NgheNghiep, String DanhGia)
        {
            bool kq = false;
            try
            {
                var sql = "Select * From KhachHang Where FullName=@FullName and GioiTinh=@GioiTinh and DiaChi=@DiaChi and EMAIL=@Email and Phone=@Phone and NgheNghiep=@NgheNghiep and DanhGia=@DanhGia";
                SqlParameter parFullName = new SqlParameter("@FullName", System.Data.SqlDbType.NVarChar);
                parFullName.Value = FullName;
                SqlParameter parGioiTinh = new SqlParameter("@GioiTinh", System.Data.SqlDbType.NVarChar);
                parGioiTinh.Value = GioiTinh;
                SqlParameter parPwdDiaChi = new SqlParameter("@DiaChi", System.Data.SqlDbType.NVarChar);
                parPwdDiaChi.Value = DiaChi;
                SqlParameter parEmail = new SqlParameter("@Email", System.Data.SqlDbType.VarChar);
                parEmail.Value = Email;
                SqlParameter parPhone = new SqlParameter("@Phone", System.Data.SqlDbType.VarChar);
                parPhone.Value = Phone;
                SqlParameter parNgheNghiep = new SqlParameter("@NgheNghiep", System.Data.SqlDbType.NVarChar);
                parNgheNghiep.Value = NgheNghiep;
                SqlParameter parDanhGia = new SqlParameter("@DanhGia", System.Data.SqlDbType.NVarChar);
                parDanhGia.Value = DanhGia;
                SqlDataReader reader = ReadDataPars(sql, new[] { parFullName, parGioiTinh, parPwdDiaChi, parEmail, parPhone, parNgheNghiep, parDanhGia });
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
        public bool SuaKH(string id, string FullName, string GioiTinh, String DiaChi, String Email, String Phone, String NgheNghiep, String DanhGia)
        {
            bool kq = false;
            try
            {
                var sql = "UPDATE KhachHang SET FullName = @FullName,GioiTinh=@GioiTinh,DiaChi=@DiaChi,EMAIL=@Email,Phone=@Phone,NgheNghiep=@NgheNghiep,DanhGia=@DanhGia where id=@id";
                // var sql = "Insert into KhachHang ( FullName,GioiTinh,DiaChi,EMAIL,Phone,NgheNghiep,DanhGia) values (@FullName,@GioiTinh,@DiaChi,@EMAIL,@Phone,@NgheNghiep,@DanhGia)";
                SqlParameter parID = new SqlParameter("@id", System.Data.SqlDbType.NVarChar);
                parID.Value = id;
                SqlParameter parFullName = new SqlParameter("@FullName", System.Data.SqlDbType.NVarChar);
                parFullName.Value = FullName;
                SqlParameter parGioiTinh = new SqlParameter("@GioiTinh", System.Data.SqlDbType.NVarChar);
                parGioiTinh.Value = GioiTinh;
                SqlParameter parPwdDiaChi = new SqlParameter("@DiaChi", System.Data.SqlDbType.NVarChar);
                parPwdDiaChi.Value = DiaChi;
                SqlParameter parEmail = new SqlParameter("@Email", System.Data.SqlDbType.VarChar);
                parEmail.Value = Email;
                SqlParameter parPhone = new SqlParameter("@Phone", System.Data.SqlDbType.VarChar);
                parPhone.Value = Phone;
                SqlParameter parNgheNghiep = new SqlParameter("@NgheNghiep", System.Data.SqlDbType.NVarChar);
                parNgheNghiep.Value = NgheNghiep;
                SqlParameter parDanhGia = new SqlParameter("@DanhGia", System.Data.SqlDbType.NVarChar);
                parDanhGia.Value = DanhGia;
                account.Excute(sql, new[] { parFullName, parGioiTinh, parPwdDiaChi, parEmail, parPhone, parNgheNghiep, parDanhGia, parID });
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
        public bool XoaKH(string FullName, string GioiTinh, String DiaChi, String Email, String Phone, String NgheNghiep, String DanhGia)
        {
            bool kq = false;
            try
            {
                var sql = "Delete From KhachHang Where FullName=@FullName and GioiTinh=@GioiTinh and DiaChi=@DiaChi and EMAIL=@Email and Phone=@Phone and NgheNghiep=@NgheNghiep and DanhGia=@DanhGia";
                SqlParameter parFullName = new SqlParameter("@FullName", System.Data.SqlDbType.NVarChar);
                parFullName.Value = FullName;
                SqlParameter parGioiTinh = new SqlParameter("@GioiTinh", System.Data.SqlDbType.NVarChar);
                parGioiTinh.Value = GioiTinh;
                SqlParameter parPwdDiaChi = new SqlParameter("@DiaChi", System.Data.SqlDbType.NVarChar);
                parPwdDiaChi.Value = DiaChi;
                SqlParameter parEmail = new SqlParameter("@Email", System.Data.SqlDbType.VarChar);
                parEmail.Value = Email;
                SqlParameter parPhone = new SqlParameter("@Phone", System.Data.SqlDbType.VarChar);
                parPhone.Value = Phone;
                SqlParameter parNgheNghiep = new SqlParameter("@NgheNghiep", System.Data.SqlDbType.NVarChar);
                parNgheNghiep.Value = NgheNghiep;
                SqlParameter parDanhGia = new SqlParameter("@DanhGia", System.Data.SqlDbType.NVarChar);
                parDanhGia.Value = DanhGia;
                account.Excute(sql, new[] { parFullName, parGioiTinh, parPwdDiaChi, parEmail, parPhone, parNgheNghiep, parDanhGia });
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
        public bool ThemKH(string FullName, string GioiTinh, String DiaChi, String Email, String Phone, String NgheNghiep, String DanhGia)
        {
            bool kq = false;
            try
            {
                var sql = "Insert into KhachHang ( FullName,GioiTinh,DiaChi,EMAIL,Phone,NgheNghiep,DanhGia) values (@FullName,@GioiTinh,@DiaChi,@EMAIL,@Phone,@NgheNghiep,@DanhGia)";
                SqlParameter parFullName = new SqlParameter("@FullName", System.Data.SqlDbType.NVarChar);
                parFullName.Value = FullName;
                SqlParameter parGioiTinh = new SqlParameter("@GioiTinh", System.Data.SqlDbType.NVarChar);
                parGioiTinh.Value = GioiTinh;
                SqlParameter parPwdDiaChi = new SqlParameter("@DiaChi", System.Data.SqlDbType.NVarChar);
                parPwdDiaChi.Value = DiaChi;
                SqlParameter parEmail = new SqlParameter("@Email", System.Data.SqlDbType.VarChar);
                parEmail.Value = Email;
                SqlParameter parPhone = new SqlParameter("@Phone", System.Data.SqlDbType.VarChar);
                parPhone.Value = Phone;
                SqlParameter parNgheNghiep = new SqlParameter("@NgheNghiep", System.Data.SqlDbType.NVarChar);
                parNgheNghiep.Value = NgheNghiep;
                SqlParameter parDanhGia = new SqlParameter("@DanhGia", System.Data.SqlDbType.NVarChar);
                parDanhGia.Value = DanhGia;
                account.Excute(sql, new[] { parFullName, parGioiTinh, parPwdDiaChi, parEmail, parPhone, parNgheNghiep, parDanhGia });
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
