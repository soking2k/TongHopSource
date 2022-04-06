using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using G7_PhongThuyWeb.Models;
using System.Data;
namespace G7_PhongThuyWeb.Areas.Admin.Controllers
{
    public class AdminTinTucController : Controller
    {
        // GET: Admin/AdminTinTuc
        public DB_PhongThuyEntities22 db = new DB_PhongThuyEntities22();
        // GET: Admin/Product
        public ActionResult Index()
        {
            if (Session["admin"] == null)
                return RedirectToAction("Index", "AdminLogin");
            var models = db.TinTucs.ToList().OrderByDescending(s => s.id);
            return View(models);
        }

        public ActionResult Create()
        {
            if (Session["admin"] == null)
                return RedirectToAction("Index", "AdminLogin");

            TinTuc cr = new TinTuc();
            cr.created = DateTime.Now;
            return View(cr);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(TinTuc tintuc, HttpPostedFileBase Images)
        {
            if (Images != null && Images.ContentLength > 0)
            {
                tintuc.image_link = Images.FileName;
                string urlImage = Server.MapPath("~/Content/Images/" + tintuc.image_link);
                Images.SaveAs(urlImage);
            }
            if (ModelState.IsValid)
            {
                string tacgia = (string)Session["useradmin"];
                tintuc.author = tacgia;
                db.TinTucs.Add(tintuc);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tintuc);
        }
        public ActionResult Details(int id)
        {
            var model = db.TinTucs.Find(id);
            return View(model);
        }
        public ActionResult Delete(int id)
        {
            var model = db.TinTucs.Find(id);
            return View(model);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult ComfirmDelete(int id)
        {
            var item = db.TinTucs.Find(id);
            
                db.TinTucs.Remove(item);

                db.SaveChanges();
                return RedirectToAction("Index", "AdminTinTuc");
        }
      
        public ActionResult Edit(int id)
        {
            var model = db.TinTucs.Find(id);
            if (Session["admin"] == null)
                return RedirectToAction("Index", "AdminLogin");

            //db.LoaiSPs.FirstOrDefault(p => p.id == id);
            return View(model);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(TinTuc tintuc, HttpPostedFileBase Images, int id)
        {
            if (Images != null && Images.ContentLength > 0)
            {
                tintuc.image_link = Images.FileName;
                string urlImage = Server.MapPath("~/Content/Images/" + tintuc.image_link);
                Images.SaveAs(urlImage);
            }

            if (ModelState.IsValid)
            {
              //  string tacgia = (string)Session["useradmin"];
              //  tintuc.author = tacgia;
                db.Entry(tintuc).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tintuc);
        }

        

    }

}
