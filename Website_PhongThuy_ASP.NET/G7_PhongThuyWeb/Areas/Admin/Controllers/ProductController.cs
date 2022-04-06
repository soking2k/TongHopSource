using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using G7_PhongThuyWeb.Models;
using System.Data;

namespace G7_PhongThuyWeb.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        public DB_PhongThuyEntities22 db = new DB_PhongThuyEntities22();
        // GET: Admin/Product
        public ActionResult Index()
        {
            if (Session["admin"] == null)
                return RedirectToAction("Index", "AdminLogin");
            var models = db.SanPhams.ToList().OrderByDescending(s=>s.id);
            return View(models);
        }
       
        public ActionResult Create()
        {
            if (Session["admin"] == null)
                return RedirectToAction("Index", "AdminLogin");

            ViewBag.types = new SelectList(db.LoaiSPs.ToList(),"id_loaisp","name");
            SanPham cr = new SanPham();
            cr.created = DateTime.Now;
            return View(cr);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(SanPham sanpham, HttpPostedFileBase Images)
        {
            if (Images != null && Images.ContentLength >0)
            {
                sanpham.image_link = Images.FileName;
                string urlImage = Server.MapPath("~/Content/Images/" + sanpham.image_link);
                Images.SaveAs(urlImage);
            }    
            if(ModelState.IsValid)
            { 
                db.SanPhams.Add(sanpham);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.listtypes = new SelectList(db.LoaiSPs, "id_loaisp", "name", sanpham.loaisp_id);
            return View(sanpham);
        }
        public ActionResult Details(int id)
        {
            var model = db.SanPhams.Find(id);
            return View(model);
        }
        public ActionResult Delete(int id)
        {
            var model = db.SanPhams.Find(id);
            return View(model);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult ComfirmDelete(int id)
        {
            var item = db.SanPhams.Find(id);
            // var ChiTietDonHang1 = db.ChiTietDonHangs.ToList();
            var ChiTietDonHang1 = db.ChiTietDonHangs.ToList();
            int checkx = 0;
            foreach (ChiTietDonHang i in ChiTietDonHang1)
            {
                if (id == i.product_id)
                {
                    checkx = checkx + 1;

                }
            }
            if(checkx > 0)
            {
                TempData["check"] = "Sản phẩm này đã tồn tại trong chi tiết hóa đơn, vui lòng xóa tại chi tiết hóa đơn trước khi xóa sản phẩm.";
                return RedirectToAction("Delete", "Product");
            }    
            else
            {
                db.SanPhams.Remove(item);
                db.SaveChanges();
                TempData["check"] = "Bạn Đã Xóa Sản Phẩm Thành Công";
                return RedirectToAction("Index", "Product");

            }
        }
        //public ActionResult Edit(int id)
        //{
        //    var model = db.SanPhams.Find(id);
        //    //db.LoaiSPs.FirstOrDefault(p => p.id == id);
        //    ViewBag.types = new SelectList(db.LoaiSPs.ToList(), "id_loaisp", "name");
        //    return View(model);
        //}
        //[HttpPost]
        //public ActionResult Edit(SanPham sanpham, HttpPostedFileBase Images)
        //{
        //    if (Images != null && Images.ContentLength > 0)
        //    {
        //        sanpham.image_link = Images.FileName;
        //        string urlImage = Server.MapPath("~/Content/Images/" + sanpham.image_link);
        //        Images.SaveAs(urlImage);
        //    }
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(sanpham).State = System.Data.Entity.EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index", "Product");
        //    }
        //    ViewBag.listtypes = new SelectList(db.LoaiSPs, "id_loaisp", "name", sanpham.loaisp_id);
        //    return View(sanpham);
        //}
        public ActionResult Edit(int id)
        {
            var model = db.SanPhams.Find(id);
            if (Session["admin"] == null)
                return RedirectToAction("Index", "AdminLogin");

            ViewBag.types = new SelectList(db.LoaiSPs.ToList(), "id_loaisp", "name");
          //  ViewBag.types = new SelectList(db.LoaiSPs.Where(s => s.id == 2).ToList(), "id_loaisp", "name");
            
            //db.LoaiSPs.FirstOrDefault(p => p.id == id);
            return View(model);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(SanPham sanpham, HttpPostedFileBase Images,int id)
        {
            if (Images != null && Images.ContentLength > 0)
            {
                sanpham.image_link = Images.FileName;
                string urlImage = Server.MapPath("~/Content/Images/" + sanpham.image_link);
                Images.SaveAs(urlImage);
            }

            if (ModelState.IsValid)
            {
                db.Entry(sanpham).State = System.Data.Entity.EntityState.Modified;            
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.listtypes = new SelectList(db.LoaiSPs, "id_loaisp", "name", sanpham.loaisp_id);
            return View(sanpham);
        }

    }
}