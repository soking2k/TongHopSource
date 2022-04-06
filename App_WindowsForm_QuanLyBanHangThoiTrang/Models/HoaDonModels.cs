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
    public class HoaDonModels : DatabaseSerivce
    {
        DatabaseSerivce account = new DatabaseSerivce();

        public DataTable DSHoaDon()
        {
            var sql = " Select MaHD,NgayDat,NgayGiao,NhanVien from HoaDon";
            SqlDataAdapter Adapter = new SqlDataAdapter(sql, connection);
            DataTable dt = new DataTable();
            Adapter.Fill(dt);
            return dt;
        }
        public DataTable DSCTHoaDon(string maxuathd)
        {
            var sql = " Select MaHD,MaSP,TenSP,DonGia,SoLuong from ChiTietHoaDon where MaHD ='" + maxuathd + "'";
            SqlDataAdapter Adapter = new SqlDataAdapter(sql, connection);
            DataTable dt = new DataTable();
            Adapter.Fill(dt);
            return dt;
        }
        public bool CheckHoaDon(String MaHD, String NgayDat, String NgayGiao)
        {
            bool kq = false;
            try
            {
                var sql = "Select * From HoaDon Where MaHD=@MaHD and NgayDat=@NgayDat and NgayGiao=@NgayGiao";
                SqlParameter parMaHD = new SqlParameter("@MaHD", System.Data.SqlDbType.VarChar);
                parMaHD.Value = MaHD;
                SqlParameter parNgayDat = new SqlParameter("@NgayDat", System.Data.SqlDbType.NVarChar);
                parNgayDat.Value = NgayDat;
                SqlParameter parNgayGiao = new SqlParameter("@NgayGiao", System.Data.SqlDbType.NVarChar);
                parNgayGiao.Value = NgayGiao;
                SqlDataReader reader = ReadDataPars(sql, new[] { parMaHD, parNgayDat, parNgayGiao });
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
        public bool ThemHoaDon(String MaHD, String NgayDat, String NgayGiao, string nv)
        {
            bool kq = false;
            try
            {
                var sql = "Insert into HoaDon ( MaHD,NgayDat,NgayGiao,NhanVien) values (@MaHD,@NgayDat,@NgayGiao,@nv)";
                SqlParameter parMaHD = new SqlParameter("@MaHD", System.Data.SqlDbType.VarChar);
                parMaHD.Value = MaHD;
                SqlParameter parNgayDat = new SqlParameter("@NgayDat", System.Data.SqlDbType.NVarChar);
                parNgayDat.Value = NgayDat;
                SqlParameter parNgayGiao = new SqlParameter("@NgayGiao", System.Data.SqlDbType.NVarChar);
                parNgayGiao.Value = NgayGiao;
                SqlParameter parnv = new SqlParameter("@nv", System.Data.SqlDbType.VarChar);
                parnv.Value = nv;
                account.Excute(sql, new[] { parMaHD, parNgayDat, parNgayGiao, parnv });
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
        public DataTable LoadMaSanPham(string MaLoai)
        {
            var sql = " Select * from SanPham where LoaiSP = '" + MaLoai + "' ";
            SqlDataAdapter Adapter = new SqlDataAdapter(sql, connection);
            DataTable dt = new DataTable();
            Adapter.Fill(dt);
            return dt;
        }
        public DataTable LoadMaHoaDon()
        {
            var sql = " Select * from HoaDon";
            SqlDataAdapter Adapter = new SqlDataAdapter(sql, connection);
            DataTable dt = new DataTable();
            Adapter.Fill(dt);
            return dt;
        }
        public bool SuaHoaDon(String MaHD, String NgayDat, String NgayGiao)
        {
            bool kq = false;
            try
            {
                var sql = "UPDATE HoaDon SET NgayDat=@NgayDat,NgayGiao=@NgayGiao where MaHD=@MaHD";
                SqlParameter parMaHD = new SqlParameter("@MaHD", System.Data.SqlDbType.VarChar);
                parMaHD.Value = MaHD;
                SqlParameter parNgayDat = new SqlParameter("@NgayDat", System.Data.SqlDbType.NVarChar);
                parNgayDat.Value = NgayDat;
                SqlParameter parNgayGiao = new SqlParameter("@NgayGiao", System.Data.SqlDbType.NVarChar);
                parNgayGiao.Value = NgayGiao;
                account.Excute(sql, new[] { parNgayDat, parNgayGiao, parMaHD });
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

        public bool XoaHoaDon(String MaHD, String NgayDat, String NgayGiao)
        {
            bool kq = false;
            try
            {
                var sql = "Delete From HoaDon Where MaHD=@MaHD and NgayDat=@NgayDat and NgayGiao=@NgayGiao";
                SqlParameter parMaHD = new SqlParameter("@MaHD", System.Data.SqlDbType.VarChar);
                parMaHD.Value = MaHD;
                SqlParameter parNgayDat = new SqlParameter("@NgayDat", System.Data.SqlDbType.NVarChar);
                parNgayDat.Value = NgayDat;
                SqlParameter parNgayGiao = new SqlParameter("@NgayGiao", System.Data.SqlDbType.NVarChar);
                parNgayGiao.Value = NgayGiao;
                account.Excute(sql, new[] { parNgayDat, parNgayGiao, parMaHD });
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
        public bool CheckCTHoaDon(String MaHD, String MaSP, String TenSP, String DonGia, String SoLuong)
        {
            bool kq = false;
            try
            {
                var sql = "Select * From ChiTietHoaDon Where MaHD=@MaHD and MaSP=@MaSP and TenSP=@TenSP";
                SqlParameter parMaHD = new SqlParameter("@MaHD", System.Data.SqlDbType.VarChar);
                parMaHD.Value = MaHD;
                SqlParameter parMaSP = new SqlParameter("@MaSP", System.Data.SqlDbType.NVarChar);
                parMaSP.Value = MaSP;
                SqlParameter parTenSP = new SqlParameter("@TenSP", System.Data.SqlDbType.NVarChar);
                parTenSP.Value = TenSP;
                SqlParameter parDonGia = new SqlParameter("@DonGia", System.Data.SqlDbType.NVarChar);
                parDonGia.Value = DonGia;
                SqlParameter parSoLuong = new SqlParameter("@SoLuong", System.Data.SqlDbType.NVarChar);
                parSoLuong.Value = SoLuong;
                SqlDataReader reader = ReadDataPars(sql, new[] { parMaHD, parMaSP, parTenSP, parDonGia, parSoLuong });
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
        public bool XoaCTHoaDon(String MaHD, String MaSP, String TenSP, String DonGia, String SoLuong)
        {
            bool kq = false;
            try
            {
                var sql = "Delete From ChiTietHoaDon Where MaHD=@MaHD and MaSP=@MaSP and TenSP=@TenSP and DonGia=@DonGia and SoLuong=@SoLuong";
                SqlParameter parMaHD = new SqlParameter("@MaHD", System.Data.SqlDbType.VarChar);
                parMaHD.Value = MaHD;
                SqlParameter parMaSP = new SqlParameter("@MaSP", System.Data.SqlDbType.NVarChar);
                parMaSP.Value = MaSP;
                SqlParameter parTenSP = new SqlParameter("@TenSP", System.Data.SqlDbType.NVarChar);
                parTenSP.Value = TenSP;
                SqlParameter parDonGia = new SqlParameter("@DonGia", System.Data.SqlDbType.NVarChar);
                parDonGia.Value = DonGia;
                SqlParameter parSoLuong = new SqlParameter("@SoLuong", System.Data.SqlDbType.NVarChar);
                parSoLuong.Value = SoLuong;
                account.Excute(sql, new[] { parMaHD, parMaSP, parTenSP, parDonGia, parSoLuong });
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
        public bool ThemCTHoaDon(String MaHD, String MaSP, String TenSP, String DonGia, String SoLuong)
        {
            bool kq = false;
            try
            {
                var sql = "Insert into ChiTietHoaDon ( MaHD,MaSP,TenSP,DonGia,SoLuong) values (@MaHD,@MaSP,@TenSP,@DonGia,@SoLuong)";
                SqlParameter parMaHD = new SqlParameter("@MaHD", System.Data.SqlDbType.VarChar);
                parMaHD.Value = MaHD;
                SqlParameter parMaSP = new SqlParameter("@MaSP", System.Data.SqlDbType.NVarChar);
                parMaSP.Value = MaSP;
                SqlParameter parTenSP = new SqlParameter("@TenSP", System.Data.SqlDbType.NVarChar);
                parTenSP.Value = TenSP;
                SqlParameter parDonGia = new SqlParameter("@DonGia", System.Data.SqlDbType.NVarChar);
                parDonGia.Value = DonGia;
                SqlParameter parSoLuong = new SqlParameter("@SoLuong", System.Data.SqlDbType.NVarChar);
                parSoLuong.Value = SoLuong;
                account.Excute(sql, new[] { parMaHD, parMaSP, parTenSP, parDonGia, parSoLuong });
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

        public DataTable LoadLoaiSP()
        {
            var sql = " Select * from LoaiSP";
            SqlDataAdapter Adapter = new SqlDataAdapter(sql, connection);
            DataTable dt = new DataTable();
            Adapter.Fill(dt);
            return dt;
        }
    }
}
