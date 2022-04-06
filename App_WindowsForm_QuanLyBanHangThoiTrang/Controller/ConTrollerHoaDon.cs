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
    public class ConTrollerHoaDon
    {
        HoaDonModels da1 = new HoaDonModels();
        public bool ThemHoaDon(String MaHD, String NgayDat, String NgayGiao, string nv)
        {
            bool kq = false;
            if (da1.ThemHoaDon(MaHD, NgayDat, NgayGiao, nv))
            {
                kq = true;
            }
            return kq;
        }
        public bool SuaHoaDon(String MaHD, String NgayDat, String NgayGiao)
        {
            bool kq = false;
            if (da1.SuaHoaDon(MaHD, NgayDat, NgayGiao))
            {
                kq = true;
            }
            return kq;
        }
        public bool XoaHoaDon(String MaHD, String NgayDat, String NgayGiao)
        {
            bool kq = false;
            if (da1.XoaHoaDon(MaHD, NgayDat, NgayGiao))
            {
                kq = true;
            }
            return kq;
        }
        public bool CheckHoaDon(String MaHD, String NgayDat, String NgayGiao)
        {
            bool kq = false;
            if (da1.CheckHoaDon(MaHD, NgayDat, NgayGiao))
            {
                kq = true;
            }
            return kq;
        }
        public bool XoaCTHoaDon(String MaHD, String MaSP, String TenSP, String DonGia, String SoLuong)
        {
            bool kq = false;
            if (da1.XoaCTHoaDon(MaHD, MaSP, TenSP, DonGia, SoLuong))
            {
                kq = true;
            }
            return kq;
        }
        public bool ThemCTHoaDon(String MaHD, String MaSP, String TenSP, String DonGia, String SoLuong)
        {
            bool kq = false;
            if (da1.ThemCTHoaDon(MaHD, MaSP, TenSP, DonGia, SoLuong))
            {
                kq = true;
            }
            return kq;
        }

        public bool CheckCTHoaDon(String MaHD, String MaSP, String TenSP, String DonGia, String SoLuong)
        {
            bool kq = false;
            if (da1.CheckCTHoaDon(MaHD, MaSP, TenSP, DonGia, SoLuong))
            {
                kq = true;
            }
            return kq;
        }

        public DataTable DSHoaDon()
        {
            return da1.DSHoaDon();

        }
        public DataTable DSCTHoaDon(string maxuathd)
        {
            return da1.DSCTHoaDon(maxuathd);

        }
        public DataTable LoadMaSanPham(string MaLoai)
        {
            return da1.LoadMaSanPham(MaLoai);

        }
        public DataTable LoadLoaiSP()
        {
            return da1.LoadLoaiSP();

        }
        public DataTable LoadMaHoaDon()
        {
            return da1.LoadMaHoaDon();

        }
    }
}
