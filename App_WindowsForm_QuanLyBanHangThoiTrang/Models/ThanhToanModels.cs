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
    public class ThanhToanModels : DatabaseSerivce
    {
        DatabaseSerivce account = new DatabaseSerivce();

        public DataTable DSThanhToan()
        {
            var sql = " Select * from ThanhToan";
            SqlDataAdapter Adapter = new SqlDataAdapter(sql, connection);
            DataTable dt = new DataTable();
            Adapter.Fill(dt);
            return dt;
        }
        public bool ThemThanhToan(string FullName, String MaGiaoDich, String SoTien, String HinhThuc, String GhiChu, String date)
        {
            bool kq = false;
            try
            {
                var sql = "Insert into ThanhToan ( FullName,MaGiaoDich,SoTien,HinhThuc,GhiChu,date) values (@FullName,@MaGiaoDich,@SoTien,@HinhThuc,@GhiChu,@date)";
                SqlParameter parFullName = new SqlParameter("@FullName", System.Data.SqlDbType.NVarChar);
                parFullName.Value = FullName;
                SqlParameter parMaGiaoDich = new SqlParameter("@MaGiaoDich", System.Data.SqlDbType.NVarChar);
                parMaGiaoDich.Value = MaGiaoDich;
                SqlParameter parPwdSoTien = new SqlParameter("@SoTien", System.Data.SqlDbType.NVarChar);
                parPwdSoTien.Value = SoTien;
                SqlParameter parHinhThuc = new SqlParameter("@HinhThuc", System.Data.SqlDbType.VarChar);
                parHinhThuc.Value = HinhThuc;
                SqlParameter parGhiChu = new SqlParameter("@GhiChu", System.Data.SqlDbType.VarChar);
                parGhiChu.Value = GhiChu;
                SqlParameter pardate = new SqlParameter("@date", System.Data.SqlDbType.NVarChar);
                pardate.Value = date;
                account.Excute(sql, new[] { parFullName, parMaGiaoDich, parPwdSoTien, parHinhThuc, parGhiChu, pardate });
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

        public DataTable LoadHinhThucGD()
        {
            var sql = " Select * from HinhThucGD";
            SqlDataAdapter Adapter = new SqlDataAdapter(sql, connection);
            DataTable dt = new DataTable();
            Adapter.Fill(dt);
            return dt;
        }
        public bool CheckThanhToan(String FullName, String MaGiaoDich, String SoTien, String HinhThuc, String GhiChu, String date)
        {
            bool kq = false;
            try
            {
                var sql = "Select * From ThanhToan Where FullName=@FullName and MaGiaoDich=@MaGiaoDich and SoTien=@SoTien and HinhThuc=@HinhThuc and date=@date";
                SqlParameter parFullName = new SqlParameter("@FullName", System.Data.SqlDbType.VarChar);
                parFullName.Value = FullName;
                SqlParameter parMaGiaoDich = new SqlParameter("@MaGiaoDich", System.Data.SqlDbType.NVarChar);
                parMaGiaoDich.Value = MaGiaoDich;
                SqlParameter parPwdSoTien = new SqlParameter("@SoTien", System.Data.SqlDbType.VarChar);
                parPwdSoTien.Value = SoTien;
                SqlParameter parHinhThuc = new SqlParameter("@HinhThuc", System.Data.SqlDbType.NVarChar);
                parHinhThuc.Value = HinhThuc;
                SqlParameter parGhiChu = new SqlParameter("@GhiChu", System.Data.SqlDbType.NText);
                parGhiChu.Value = GhiChu;
                SqlParameter pardate = new SqlParameter("@date", System.Data.SqlDbType.VarChar);
                pardate.Value = date;
                SqlDataReader reader = ReadDataPars(sql, new[] { parFullName, parMaGiaoDich, parPwdSoTien, parHinhThuc, parGhiChu, pardate });
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
        public bool SuaThanhToan(string id, string FullName, String MaGiaoDich, String SoTien, String HinhThuc, String GhiChu, String date)
        {
            bool kq = false;
            try
            {
                var sql = "UPDATE ThanhToan SET FullName = @FullName,MaGiaoDich=@MaGiaoDich,SoTien=@SoTien,HinhThuc=@HinhThuc,GhiChu=@GhiChu,date=@date where id=@id";
                // var sql = "Insert into KhachHang ( FullName,GioiTinh,DiaChi,EMAIL,Phone,NgheNghiep,DanhGia) values (@FullName,@GioiTinh,@DiaChi,@EMAIL,@Phone,@NgheNghiep,@DanhGia)";
                SqlParameter parid = new SqlParameter("@id", System.Data.SqlDbType.NVarChar);
                parid.Value = id;
                SqlParameter parFullName = new SqlParameter("@FullName", System.Data.SqlDbType.NVarChar);
                parFullName.Value = FullName;
                SqlParameter parMaGiaoDich = new SqlParameter("@MaGiaoDich", System.Data.SqlDbType.NVarChar);
                parMaGiaoDich.Value = MaGiaoDich;
                SqlParameter parPwdSoTien = new SqlParameter("@SoTien", System.Data.SqlDbType.NVarChar);
                parPwdSoTien.Value = SoTien;
                SqlParameter parHinhThuc = new SqlParameter("@HinhThuc", System.Data.SqlDbType.VarChar);
                parHinhThuc.Value = HinhThuc;
                SqlParameter parGhiChu = new SqlParameter("@GhiChu", System.Data.SqlDbType.NText);
                parGhiChu.Value = GhiChu;
                SqlParameter pardate = new SqlParameter("@date", System.Data.SqlDbType.NVarChar);
                pardate.Value = date;
                account.Excute(sql, new[] { parFullName, parMaGiaoDich, parPwdSoTien, parHinhThuc, parGhiChu, pardate, parid });
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
        public bool XoaThanhToan(string FullName, String MaGiaoDich, String SoTien, String HinhThuc, String GhiChu, String date)
        {
            bool kq = false;
            try
            {
                var sql = "Delete From ThanhToan Where FullName=@FullName and MaGiaoDich=@MaGiaoDich and SoTien=@SoTien and HinhThuc=@HinhThuc and date=@date";
                SqlParameter parFullName = new SqlParameter("@FullName", System.Data.SqlDbType.NVarChar);
                parFullName.Value = FullName;
                SqlParameter parMaGiaoDich = new SqlParameter("@MaGiaoDich", System.Data.SqlDbType.NVarChar);
                parMaGiaoDich.Value = MaGiaoDich;
                SqlParameter parPwdSoTien = new SqlParameter("@SoTien", System.Data.SqlDbType.NVarChar);
                parPwdSoTien.Value = SoTien;
                SqlParameter parHinhThuc = new SqlParameter("@HinhThuc", System.Data.SqlDbType.VarChar);
                parHinhThuc.Value = HinhThuc;
                SqlParameter parGhiChu = new SqlParameter("@GhiChu", System.Data.SqlDbType.NText);
                parGhiChu.Value = GhiChu;
                SqlParameter pardate = new SqlParameter("@date", System.Data.SqlDbType.NVarChar);
                pardate.Value = date;
                account.Excute(sql, new[] { parFullName, parMaGiaoDich, parPwdSoTien, parHinhThuc, parGhiChu, pardate });
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
