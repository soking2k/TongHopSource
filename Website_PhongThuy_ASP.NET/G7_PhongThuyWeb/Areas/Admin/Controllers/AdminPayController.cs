using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using G7_PhongThuyWeb.Models;

namespace G7_PhongThuyWeb.Areas.Admin.Controllers
{
    public class AdminPayController : Controller
    {
        public DB_PhongThuyEntities22 db = new DB_PhongThuyEntities22();

        // GET: Admin/AdminPay
        public ActionResult Index()
        {
            if (Session["admin"] == null)
                return RedirectToAction("Index", "AdminLogin");
            var models = db.DonHangs.OrderByDescending(s => s.id).ToList();
            return View(models);
        }
        public ActionResult Create()
        {
            if (Session["admin"] == null)
                return RedirectToAction("Index", "AdminLogin");
            return View();
        }
        [HttpPost]
        public ActionResult Create(DonHang donhang)
        {
            try
            {
                db.DonHangs.Add(donhang); //Add or Update Book b
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Details(int id)
        {

            ViewBag.od = db.DonHangs.Find(id);
            var models = db.ChiTietDonHangs.Where(p => p.id == id).ToList();
            
            var upcommingCourse = db.ChiTietDonHangs.Where(c => c.transaction_id == id).ToList();
            decimal tong_price = 0;
            foreach (ChiTietDonHang i in upcommingCourse)
            {
                var upcommingCourse1 = db.SanPhams.Where(b => b.id == i.product_id).ToList();
                foreach (SanPham j in upcommingCourse1)
                {
                    i.Name = j.name;
                    i.Price = j.price;
                    tong_price = tong_price + j.price;
                }
                i.tong_price = tong_price;
            }
            return View(upcommingCourse);
        }
        public ActionResult Delete(int id)
        {
            var model = db.DonHangs.Find(id);
            return View(model);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult ComfirmDelete(int id)
        {
            var item = db.DonHangs.Find(id);
            db.DonHangs.Remove(item);
            db.SaveChanges();
            return RedirectToAction("Index", "AdminPay");
        }
        public ActionResult Edit(int id)
        {
            var model = db.DonHangs.Find(id);
            //db.LoaiSPs.FirstOrDefault(p => p.id == id);
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(DonHang donhang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(donhang).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "AdminPay");
            }
            return View(donhang);
        }
    }
}