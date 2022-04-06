using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using G7_PhongThuyWeb.Models;

namespace G7_PhongThuyWeb.Areas.Admin.Controllers
{
    public class AdminHomeController : Controller
    {
        public DB_PhongThuyEntities22 db = new DB_PhongThuyEntities22();

        // GET: Admin/AdminHome
        public ActionResult Index()
        {
            if(Session["admin"] != null)
            {
                ViewBag.taikhoan = db.users.Where(p => p.created == DateTime.Today).Count();
                ViewBag.tongtaikhoan = db.users.Count();
                ViewBag.doanhthuhomnay = db.DonHangs.ToList();
                ViewBag.doanhthunam = db.DonHangs.ToList();
                ViewBag.doanhthuthang = db.DonHangs.ToList();
                return View();
            }    
            else
            {

                return RedirectToAction("Index", "AdminLogin");
            }    
        }
        public ActionResult PieChart()
        {
            // var Countries1 = entities.Countries.Where(p=> p.datime == null).ToList();
            List<DonHang> DonHang1 = new List<DonHang>();

            var Countries2 = db.DonHangs.ToList();

            List<DonHang> Thang1 = new List<DonHang>();
            List<DonHang> Thang2 = new List<DonHang>();
            List<DonHang> Thang3 = new List<DonHang>();
            List<DonHang> Thang4 = new List<DonHang>();
            List<DonHang> Thang5 = new List<DonHang>();
            List<DonHang> Thang6 = new List<DonHang>();
            List<DonHang> Thang7 = new List<DonHang>();
            List<DonHang> Thang8 = new List<DonHang>();
            List<DonHang> Thang9 = new List<DonHang>();
            List<DonHang> Thang10 = new List<DonHang>();
            List<DonHang> Thang11 = new List<DonHang>();
            List<DonHang> Thang12 = new List<DonHang>();



            foreach (DonHang i in Countries2)
            {

                DateTime checkthang;
                checkthang = (DateTime)i.created;

                if (checkthang.Month == 1 && checkthang.Year == DateTime.Now.Year)
                {
                    Thang1.Add(i);
                }
                if (checkthang.Month == 2 && checkthang.Year == DateTime.Now.Year)
                {
                    Thang2.Add(i);
                }
                if (checkthang.Month == 3 && checkthang.Year == DateTime.Now.Year)
                {
                    Thang3.Add(i);
                }
                if (checkthang.Month == 4 && checkthang.Year == DateTime.Now.Year)
                {
                    Thang4.Add(i);
                }
                if (checkthang.Month == 5 && checkthang.Year == DateTime.Now.Year)
                {
                    Thang5.Add(i);
                }
                if (checkthang.Month == 6 && checkthang.Year == DateTime.Now.Year)
                {
                    Thang6.Add(i);
                }
                if (checkthang.Month == 7 && checkthang.Year == DateTime.Now.Year)
                {
                    Thang7.Add(i);
                }
                if (checkthang.Month == 8 && checkthang.Year == DateTime.Now.Year)
                {
                    Thang8.Add(i);
                }
                if (checkthang.Month == 9 && checkthang.Year == DateTime.Now.Year)
                {
                    Thang9.Add(i);
                }
                if (checkthang.Month == 10 && checkthang.Year == DateTime.Now.Year)
                {
                    Thang10.Add(i);
                }
                if (checkthang.Month == 11 && checkthang.Year == DateTime.Now.Year)
                {
                    Thang11.Add(i);
                }
                if (checkthang.Month == 12 && checkthang.Year == DateTime.Now.Year)
                {
                    Thang12.Add(i);
                }
            }


            double total1 = (double)Thang1.Sum(item => item.amount);
            double total2 = (double)Thang2.Sum(item => item.amount);
            double total3 = (double)Thang3.Sum(item => item.amount);
            double total4 = (double)Thang4.Sum(item => item.amount);
            double total5 = (double)Thang5.Sum(item => item.amount);
            double total6 = (double)Thang6.Sum(item => item.amount);
            double total7 = (double)Thang7.Sum(item => item.amount);
            double total8 = (double)Thang8.Sum(item => item.amount);
            double total9 = (double)Thang9.Sum(item => item.amount);
            double total10 = (double)Thang10.Sum(item => item.amount);
            double total11 = (double)Thang11.Sum(item => item.amount);
            double total12 = (double)Thang12.Sum(item => item.amount);

            List<DonHang> Countries6 = new List<DonHang>()
            {
                new DonHang() { id = 1, user_name = "Tháng 1", amount = total1 },
                new DonHang() { id = 1, user_name = "Tháng 2", amount = total2 },
                new DonHang() { id = 1, user_name = "Tháng 3", amount = total3 },
                new DonHang() { id = 1, user_name = "Tháng 4", amount = total4 },
                new DonHang() { id = 1, user_name = "Tháng 5", amount = total5 },
                new DonHang() { id = 1, user_name = "Tháng 6", amount = total6 },
                new DonHang() { id = 1, user_name = "Tháng 7", amount = total7 },
                new DonHang() { id = 1, user_name = "Tháng 8", amount = total8 },
                new DonHang() { id = 1, user_name = "Tháng 9", amount = total9 },
                new DonHang() { id = 1, user_name = "Tháng 10", amount = total10 },
                new DonHang() { id = 1, user_name = "Tháng 11", amount = total11 },
                new DonHang() { id = 1, user_name = "Tháng 12", amount = total12 }

            };
            //    var thang1 = entities.Countries.Where(p => (DateTime)p.datime == DateTime.Now);
            //  var thang2 = entities.Countries.Where(p => p.datime == DateTime.Today);
            //  var x = thang2.Concat(thang1);
            return Json(Countries6.ToList(), JsonRequestBehavior.AllowGet);
        }


        public ActionResult PieChartYear()
        {
            // var Countries1 = entities.Countries.Where(p=> p.datime == null).ToList();
            List<DonHang> DonHang1 = new List<DonHang>();

            var Countries2 = db.DonHangs.ToList();

            List<DonHang> Year2017 = new List<DonHang>();
            List<DonHang> Year2018 = new List<DonHang>();
            List<DonHang> Year2019 = new List<DonHang>();
            List<DonHang> Year2020 = new List<DonHang>();
            List<DonHang> Year2021 = new List<DonHang>();



            foreach (DonHang i in Countries2)
            {

                DateTime checkthang;
                checkthang = (DateTime)i.created;

                if (checkthang.Year == 2017)
                {
                    Year2017.Add(i);
                }
                if (checkthang.Year == 2018)
                {
                    Year2018.Add(i);
                }
                if (checkthang.Year == 2019)
                {
                    Year2019.Add(i);
                }
                if (checkthang.Year == 2020)
                {
                    Year2020.Add(i);
                }
                if (checkthang.Year == 2021)
                {
                    Year2021.Add(i);
                }
            }

            double total = (double)Year2017.Sum(item => item.amount);
            double total1 = (double)Year2018.Sum(item => item.amount);
            double total2 = (double)Year2019.Sum(item => item.amount);
            double total3 = (double)Year2020.Sum(item => item.amount);
            double total4 = (double)Year2021.Sum(item => item.amount);


            List<DonHang> Countries6 = new List<DonHang>()
            {
                new DonHang() { id = 1, user_name = "Năm 2017", amount = total },
                new DonHang() { id = 1, user_name = "Năm 2018", amount = total1 },
                new DonHang() { id = 1, user_name = "Năm 2019", amount = total2 },
                new DonHang() { id = 1, user_name = "Năm 2020", amount = total3 },
                new DonHang() { id = 1, user_name = "Năm 2021", amount = total4 },

            };
            //    var thang1 = entities.Countries.Where(p => (DateTime)p.datime == DateTime.Now);
            //  var thang2 = entities.Countries.Where(p => p.datime == DateTime.Today);
            //  var x = thang2.Concat(thang1);
            return Json(Countries6.ToList(), JsonRequestBehavior.AllowGet);
        }


        public ActionResult Logout()
        {
            Session["admin"] = null;
            Session["useradmin"] = null;

            return RedirectToAction("Index", "AdminLogin");

        }
    }
}