using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using G7_PhongThuyWeb.Models;
using PagedList;

namespace G7_PhongThuyWeb.Controllers
{
    public class HomeController : Controller
    {
        public DB_PhongThuyEntities22 db = new DB_PhongThuyEntities22();
        public IEnumerable<SanPham> AllListPaging(int page, int pagesize)
        {
            return db.SanPhams.OrderByDescending(x => x.id).ToPagedList(page, pagesize);
        }
        public IEnumerable<SanPham> AllListPagingByType(int page, int pagesize,string typeId)
        {
          //  int ma = int.Parse(typeId);
            return db.SanPhams.OrderByDescending(x => x.id).Where(x => x.loaisp_id.Equals(typeId)).ToPagedList(page, pagesize);
        }

        public ActionResult Index(String id, int page = 1, int pagesize =20)
        {
            ViewBag.menu = db.LoaiSPs.ToList();
           // List<SanPham> models;
            if (id == null)
            {
                var models = AllListPaging(page, pagesize);
                ViewBag.id = null;
                return View(models);
            }
            //models = db.SanPhams.OrderByDescending(p => p.name).ToList();
            else
            {
                var models = AllListPagingByType(page, pagesize, id);
                ViewBag.id = id;
                return View(models);
            }    
             //   models = db.SanPhams.OrderByDescending(p => p.name).Where(p => p.loaisp_id.Equals(id)).ToList();
          //  return View(models);
        }
        public ActionResult Logout()
        {           
                Session["users"] = null;
                Session["usersname"] = null;

            return RedirectToAction("Index", "Home");

        }

      
        //public ActionResult TimKiem()
        //{

        //    TimKiem("Ấm Trà");
        //    return View();
        //}
       
        public ActionResult TimKiem(string s)
        {
            ViewBag.timkiemsanpham = db.SanPhams.Where(p => p.name.Contains(s)).ToList();
            ViewBag.TuKhoa = s;

            return View();
        }
        public ActionResult Details(int id)
        {

            ViewBag.sanphamz = db.SanPhams.Where(p => p.loaisp_id == "3").ToList();
            var model = db.SanPhams.Find(id);
            return View(model);
        }
        public ActionResult GioiThieu()
        {

            return View();
        }
        public ActionResult ChinhSach()
        {

            return View();
        }
        public ActionResult TinTuc()
        {
            var models = db.TinTucs.Where(p=> p.description !="Đợi Duyệt").ToList().OrderByDescending(s => s.id);

            ViewBag.TinTuc = models.ToList();


            return View();
        }

        public ActionResult ChiTietTinTuc(int id)
        {
            ViewBag.TinTuc = db.TinTucs.ToList();
            var model = db.TinTucs.Find(id);
            return View(model);
        }
        public ActionResult Create()
        {
            if (Session["usersname"] == null)
                return RedirectToAction("Index", "Login");

            TinTuc cr = new TinTuc();
            cr.created = DateTime.Now;
            return View(cr);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(TinTuc tintuc, HttpPostedFileBase Images)
        {
            if(tintuc.title != null != null && tintuc.content != null)
               { 
                    if (Images != null && Images.ContentLength > 0)
                    {
                        tintuc.image_link = Images.FileName;
                        string urlImage = Server.MapPath("~/Content/Images/" + tintuc.image_link);
                        Images.SaveAs(urlImage);
                    }
                    if (ModelState.IsValid)
                    {
                        string tacgia = (string)Session["usersname"];
                        tintuc.author = tacgia;
                        db.TinTucs.Add(tintuc);
                        db.SaveChanges();
                        TempData["check"] = "Bạn đã đăng phản hồi thành công, sẽ mất vài phút để đội kỹ thuật kiểm duyệt.";
                        return RedirectToAction("TinTuc", "Home");
                    }
                    return View(tintuc);
                }
            else
            {
                return View(tintuc);

            }
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


    }
}