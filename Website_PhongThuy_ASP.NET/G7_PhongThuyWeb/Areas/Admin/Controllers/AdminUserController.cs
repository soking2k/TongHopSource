using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using G7_PhongThuyWeb.Models;

namespace G7_PhongThuyWeb.Areas.Admin.Controllers
{
    public class AdminUserController : Controller
    {
        public DB_PhongThuyEntities22 db = new DB_PhongThuyEntities22();
        // GET: Admin/AdminUser
        public ActionResult Index()
        {
            if (Session["admin"] == null)
                return RedirectToAction("Index", "AdminLogin");
            var models = db.users.ToList();
            return View(models);
        }
        public ActionResult Create()
        {
            if (Session["admin"] == null)
                return RedirectToAction("Index", "AdminLogin");
            return View();
        }
        [HttpPost]
        public ActionResult Create(user users)
        {
            try
            {
                db.users.Add(users); //Add or Update Book b
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
            var model = db.users.Find(id);
            return View(model);
        }
        public ActionResult Delete(int id)
        {
            var model = db.users.Find(id);
            return View(model);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult ComfirmDelete(int id)
        {
            var item = db.users.Find(id);
            db.users.Remove(item);
            db.SaveChanges();
            return RedirectToAction("Index", "AdminUser");
        }
        public ActionResult Edit(int id)
        {
            var model = db.users.Find(id);
            //db.LoaiSPs.FirstOrDefault(p => p.id == id);
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(user users)
        {
            if (ModelState.IsValid)
            {
                db.Entry(users).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "AdminUser");
            }
            return View(users);
        }

    }
}