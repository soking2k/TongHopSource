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
    public class SanPhamModels : DatabaseSerivce
    {
        DatabaseSerivce account = new DatabaseSerivce();
        public DataTable DSSanPham()
        {
            var sql = " Select * from SanPham";
            SqlDataAdapter Adapter = new SqlDataAdapter(sql, connection);
            DataTable dt = new DataTable();
            Adapter.Fill(dt);
            return dt;
        }
        public DataTable LoadNhaCungCap()
        {
            var sql = "Select * from NhaCungCap";
            SqlDataAdapter Adapter = new SqlDataAdapter(sql, connection);
            DataTable dt = new DataTable();
            Adapter.Fill(dt);
            return dt;
        }
        public bool Checksanpham(String MaSP, String TenSP, String GiaMua, String GiaBan, String NhaCungCap)
        {
            bool kq = false;
            try
            {
                var sql = "Select * From SanPham Where MaSP=@MaSP and TenSP=@TenSP and GiaMua=@GiaMua and GiaBan=@GiaBan and NhaCungCap=@NhaCungCap";
                SqlParameter parMaSP = new SqlParameter("@MaSP", System.Data.SqlDbType.VarChar);
                parMaSP.Value = MaSP;
                SqlParameter parTenSP = new SqlParameter("@TenSP", System.Data.SqlDbType.NVarChar);
                parTenSP.Value = TenSP;
                SqlParameter parGiaMua = new SqlParameter("@GiaMua", System.Data.SqlDbType.NVarChar);
                parGiaMua.Value = GiaMua;
                SqlParameter parGiaBan = new SqlParameter("@GiaBan", System.Data.SqlDbType.VarChar);
                parGiaBan.Value = GiaBan;
                SqlParameter parNhaCungCap = new SqlParameter("@NhaCungCap", System.Data.SqlDbType.NVarChar);
                parNhaCungCap.Value = NhaCungCap;
                SqlDataReader reader = ReadDataPars(sql, new[] { parMaSP, parTenSP, parGiaMua, parGiaBan, parNhaCungCap });
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
        public bool ThemSanPham(String MaSP, String TenSP, String GiaMua, String GiaBan, String NhaCungCap)
        {
            bool kq = false;
            try
            {
                var sql = "Insert into SanPham ( MaSP,TenSP,GiaMua,GiaBan,NhaCungCap) values (@MaSP,@TenSP,@GiaMua,@GiaBan,@NhaCungCap)";
                SqlParameter parMaSP = new SqlParameter("@MaSP", System.Data.SqlDbType.VarChar);
                parMaSP.Value = MaSP;
                SqlParameter parTenSP = new SqlParameter("@TenSP", System.Data.SqlDbType.NVarChar);
                parTenSP.Value = TenSP;
                SqlParameter parGiaMua = new SqlParameter("@GiaMua", System.Data.SqlDbType.NVarChar);
                parGiaMua.Value = GiaMua;
                SqlParameter parGiaBan = new SqlParameter("@GiaBan", System.Data.SqlDbType.VarChar);
                parGiaBan.Value = GiaBan;
                SqlParameter parNhaCungCap = new SqlParameter("@NhaCungCap", System.Data.SqlDbType.NVarChar);
                parNhaCungCap.Value = NhaCungCap;
                account.Excute(sql, new[] { parMaSP, parTenSP, parGiaMua, parGiaBan, parNhaCungCap });
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
        public bool SuaSanPham(string id, String MaSP, String TenSP, String GiaMua, String GiaBan, String NhaCungCap)
        {
            bool kq = false;
            try
            {
                var sql = "UPDATE SanPham SET MaSP = @MaSP,TenSP=@TenSP,GiaMua=@GiaMua,GiaBan=@GiaBan,NhaCungCap=@NhaCungCap where id=@id";
                SqlParameter parid = new SqlParameter("@id", System.Data.SqlDbType.NVarChar);
                parid.Value = id;
                SqlParameter parMaSP = new SqlParameter("@MaSP", System.Data.SqlDbType.VarChar);
                parMaSP.Value = MaSP;
                SqlParameter parTenSP = new SqlParameter("@TenSP", System.Data.SqlDbType.NVarChar);
                parTenSP.Value = TenSP;
                SqlParameter parGiaMua = new SqlParameter("@GiaMua", System.Data.SqlDbType.NVarChar);
                parGiaMua.Value = GiaMua;
                SqlParameter parGiaBan = new SqlParameter("@GiaBan", System.Data.SqlDbType.VarChar);
                parGiaBan.Value = GiaBan;
                SqlParameter parNhaCungCap = new SqlParameter("@NhaCungCap", System.Data.SqlDbType.NVarChar);
                parNhaCungCap.Value = NhaCungCap;
                account.Excute(sql, new[] { parMaSP, parTenSP, parGiaMua, parGiaBan, parNhaCungCap, parid });
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
        public bool XoaSanPham(string id, String MaSP, String TenSP, String GiaMua, String GiaBan, String NhaCungCap)
        {
            bool kq = false;
            try
            {
                var sql = "Delete From SanPham Where MaSP=@MaSP and TenSP=@TenSP and GiaMua=@GiaMua and GiaBan=@GiaBan and NhaCungCap=@NhaCungCap";
                SqlParameter parid = new SqlParameter("@id", System.Data.SqlDbType.NVarChar);
                parid.Value = id;
                SqlParameter parMaSP = new SqlParameter("@MaSP", System.Data.SqlDbType.VarChar);
                parMaSP.Value = MaSP;
                SqlParameter parTenSP = new SqlParameter("@TenSP", System.Data.SqlDbType.NVarChar);
                parTenSP.Value = TenSP;
                SqlParameter parGiaMua = new SqlParameter("@GiaMua", System.Data.SqlDbType.NVarChar);
                parGiaMua.Value = GiaMua;
                SqlParameter parGiaBan = new SqlParameter("@GiaBan", System.Data.SqlDbType.VarChar);
                parGiaBan.Value = GiaBan;
                SqlParameter parNhaCungCap = new SqlParameter("@NhaCungCap", System.Data.SqlDbType.NVarChar);
                parNhaCungCap.Value = NhaCungCap;
                account.Excute(sql, new[] { parMaSP, parTenSP, parGiaMua, parGiaBan, parNhaCungCap, parid });
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
