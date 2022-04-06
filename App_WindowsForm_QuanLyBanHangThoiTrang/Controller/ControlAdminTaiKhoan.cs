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
    public class ControlAdminTaiKhoan : DatabaseSerivce
    {
        AdminTaiKhoanModels da1 = new AdminTaiKhoanModels();

        public bool SuaTaiKhoan(string TaiKhoan, string MatKhau, string MatKhauMH, string Email, string HoVaTen, string SoDienThoai)
        {
            bool kq = false;
            if (da1.SuaTaiKhoan(TaiKhoan, MatKhau, MatKhauMH, Email, HoVaTen, SoDienThoai))
            {
                kq = true;
            }
            return kq;
        }
        public bool DuyetTK(string TaiKhoan, string Activity)
        {
            bool kq = false;
            if (da1.DuyetTK(TaiKhoan, Activity))
            {
                kq = true;
            }
            return kq;
        }
        public bool KhoaTK(string TaiKhoan, string Activity)
        {
            bool kq = false;
            if (da1.KhoaTK(TaiKhoan, Activity))
            {
                kq = true;
            }
            return kq;
        }
        public DataTable DSTaiKhoan()
        {
            return da1.DSTaiKhoan();

        }
    }
}
