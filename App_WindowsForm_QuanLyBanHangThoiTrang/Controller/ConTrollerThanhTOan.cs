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

    public class ConTrollerThanhTOan
    {
        ThanhToanModels da1 = new ThanhToanModels();
        public bool CheckThanhToan(String FullName, String MaGiaoDich, String SoTien, String HinhThuc, String GhiChu, String date)
        {
            bool kq = false;
            if (da1.CheckThanhToan(FullName, MaGiaoDich, SoTien, HinhThuc, GhiChu, date))
            {
                kq = true;
            }
            return kq;
        }
        public bool XoaThanhToan(String FullName, String MaGiaoDich, String SoTien, String HinhThuc, String GhiChu, String date)
        {
            bool kq = false;
            if (da1.XoaThanhToan(FullName, MaGiaoDich, SoTien, HinhThuc, GhiChu, date) == true)
            {
                kq = true;
            }
            return kq;
        }
        public bool SuaThanhToan(string id, String FullName, String MaGiaoDich, String SoTien, String HinhThuc, String GhiChu, String date)
        {
            bool kq = false;
            if (da1.SuaThanhToan(id, FullName, MaGiaoDich, SoTien, HinhThuc, GhiChu, date))
            {
                kq = true;
            }
            return kq;
        }
        public DataTable DSThanhToan()
        {
            return da1.DSThanhToan();

        }
        public DataTable LoadHinhThucGD()
        {
            return da1.LoadHinhThucGD();

        }
        public bool ThemThanhToan(String FullName, String MaGiaoDich, String SoTien, String HinhThuc, String GhiChu, String date)
        {
            bool kq = false;
            if (da1.ThemThanhToan(FullName, MaGiaoDich, SoTien, HinhThuc, GhiChu, date))
            {
                kq = true;
            }
            return kq;
        }
    }
}
