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
    public class ConTrollerSanPham
    {
       SanPhamModels da1 = new SanPhamModels();
        public bool Checksanpham(String MaSP, String TenSP, String GiaMua, String GiaBan, String NhaCungCap)
        {
            bool kq = false;
            if (da1.Checksanpham(MaSP, TenSP, GiaMua, GiaBan, NhaCungCap))
            {
                kq = true;
            }
            return kq;
        }
        public bool ThemSanPham(String MaSP, String TenSP, String GiaMua, String GiaBan, String NhaCungCap)
        {
            bool kq = false;
            if (da1.ThemSanPham(MaSP, TenSP, GiaMua, GiaBan, NhaCungCap))
            {
                kq = true;
            }
            return kq;
        }
        public bool SuaSanPham(string id, String MaSP, String TenSP, String GiaMua, String GiaBan, String NhaCungCap)
        {
            bool kq = false;
            if (da1.SuaSanPham(id, MaSP, TenSP, GiaMua, GiaBan, NhaCungCap))
            {
                kq = true;
            }
            return kq;
        }
        public bool XoaSanPham(string id, String MaSP, String TenSP, String GiaMua, String GiaBan, String NhaCungCap)
        {
            bool kq = false;
            if (da1.XoaSanPham(id, MaSP, TenSP, GiaMua, GiaBan, NhaCungCap))
            {
                kq = true;
            }
            return kq;
        }
        public DataTable DSSanPham()
        {
            return da1.DSSanPham();

        }
        public DataTable LoadNhaCungCap()
        {
            return da1.LoadNhaCungCap();

        }
    }
}
