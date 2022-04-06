using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using G7_PhongThuyWeb.Models; 

namespace G7_PhongThuyWeb.Areas.Admin.Controllers
{
    public class AdminLoginController : Controller
    {
        // GET: Admin/AdminLogin
        public DB_PhongThuyEntities22 db = new DB_PhongThuyEntities22();
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(string username, string password)
        {
            string pass = Encode.EncodeMD5(password);
            var result = db.admins.Where(s => s.username.Equals(username) && s.password.Equals(pass)).FirstOrDefault();
            if (result != null)
            {
                Session["admin"] = result.id;
                Session["useradmin"] = result.username;

                return RedirectToAction("Index", "AdminHome");
            }    
            else
            {
                TempData["check"] = "Tài khoản hoặc mật khẩu không đúng";
                return View();
            }    
        }
    }
}