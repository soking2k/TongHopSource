using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using G7_PhongThuyWeb.Models;
using System.Data;

namespace G7_PhongThuyWeb.Areas.Admin.Controllers
{
    public class TypeProductController : Controller
    {
        public DB_PhongThuyEntities22 db = new DB_PhongThuyEntities22();
        // GET: Admin/TypeProduct
        public ActionResult Index()
        {
            if (Session["admin"] == null)
                return RedirectToAction("Index", "AdminLogin");
            var models = db.LoaiSPs.ToList();
            return View(models);
        }
        public ActionResult Create()
        {
            if (Session["admin"] == null)
                return RedirectToAction("Index", "AdminLogin");
            return View();
        }
        [HttpPost]
        public ActionResult Create(LoaiSP type)
        {
            try
            {
                db.LoaiSPs.Add(type); //Add or Update Book b
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
            var model = db.LoaiSPs.Find(id);
            return View(model);
        }
        public ActionResult Delete(int id)
        {
            var model = db.LoaiSPs.Find(id);
            return View(model);
        }
        [HttpPost,ActionName("Delete")]
        public ActionResult ComfirmDelete(int id)
        {
            var item = db.LoaiSPs.Find(id);
            db.LoaiSPs.Remove(item);
            db.SaveChanges();
            return RedirectToAction("Index", "TypeProduct");
        }
        public ActionResult Edit(int id)
        {
            var model = db.LoaiSPs.Find(id);
            //db.LoaiSPs.FirstOrDefault(p => p.id == id);
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(LoaiSP loaisp)
        {
            if (ModelState.IsValid)
            {
                db.Entry(loaisp).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "TypeProduct");
            }
            return View(loaisp);
        }
    }
}