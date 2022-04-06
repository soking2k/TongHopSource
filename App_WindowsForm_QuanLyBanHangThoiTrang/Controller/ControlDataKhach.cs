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

    public class ControlDataKhach
    {
        DataKhachModels da1 = new DataKhachModels();

        public bool XoaKH(String FullName, String GioiTinh, String DiaChi, String Email, String Phone, String NgheNghiep, String DanhGia)
        {
            bool kq = false;
            if (da1.XoaKH(FullName, GioiTinh, DiaChi, Email, Phone, NgheNghiep, DanhGia) == true)
            {
                kq = true;
            }
            return kq;
        }
        public bool ThemKH(String FullName, String GioiTinh, String DiaChi, String Email, String Phone, String NgheNghiep, String DanhGia)
        {
            bool kq = false;
            if (da1.ThemKH(FullName, GioiTinh, DiaChi, Email, Phone, NgheNghiep, DanhGia))
            {
                kq = true;
            }
            return kq;
        }
        public bool CheckTonTai(String FullName, String GioiTinh, String DiaChi, String Email, String Phone, String NgheNghiep, String DanhGia)
        {
            bool kq = false;
            if (da1.CheckTonTai(FullName, GioiTinh, DiaChi, Email, Phone, NgheNghiep, DanhGia) == true)
            {
                kq = true;
            }
            return kq;
        }
        public bool SuaKH(string id, String FullName, String GioiTinh, String DiaChi, String Email, String Phone, String NgheNghiep, String DanhGia)
        {
            bool kq = false;
            if (da1.SuaKH(id, FullName, GioiTinh, DiaChi, Email, Phone, NgheNghiep, DanhGia))
            {
                kq = true;
            }
            return kq;
        }
        public DataTable Laydata()
        {
            return da1.Laydata();

        }

        public DataTable LoadGioiTinh()
        {
            return da1.LoadGioiTinh();

        }
    }
}
