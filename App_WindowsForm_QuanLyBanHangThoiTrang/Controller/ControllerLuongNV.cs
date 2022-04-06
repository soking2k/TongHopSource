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
    public class ControllerLuongNV
    {
        AdminLuongNVModels da1 = new AdminLuongNVModels();
        public bool XoaLuongNV(string taikhoan, string luong, string thoigian, string ghichu)
        {
            bool kq = false;
            if (da1.XoaLuongNV(taikhoan, luong, thoigian, ghichu))
            {
                kq = true;
            }
            return kq;
        }
        public bool SuaLuongNV(string taikhoan, string luong, string thoigian, string ghichu)
        {
            bool kq = false;
            if (da1.SuaLuongNV(taikhoan, luong, thoigian, ghichu))
            {
                kq = true;
            }
            return kq;
        }
        public bool ThemLuongNV(string taikhoan, string luong, string thoigian, string ghichu)
        {
            bool kq = false;
            if (da1.ThemLuongNV(taikhoan, luong, thoigian, ghichu))
            {
                kq = true;
            }
            return kq;
        }
        public bool CheckLuongNV(string taikhoan, string luong, string thoigian, string ghichu)
        {
            bool kq = false;
            if (da1.CheckLuongNV(taikhoan, luong, thoigian, ghichu))
            {
                kq = true;
            }
            return kq;
        }
        public DataTable DSLuongNV()
        {
            return da1.DSLuongNV();

        }
        public DataTable LoadAccount()
        {
            return da1.LoadAccount();

        }
    }
}
