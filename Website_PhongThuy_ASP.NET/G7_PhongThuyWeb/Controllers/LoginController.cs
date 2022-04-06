using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using G7_PhongThuyWeb.Models;

namespace G7_PhongThuyWeb.Controllers
{
    public class LoginController : Controller
    {
        public DB_PhongThuyEntities22 db = new DB_PhongThuyEntities22();
        // GET: Login
        public ActionResult Index()
        {
            ViewBag.menu = db.LoaiSPs.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult Index(string username, string password)
        {
            ViewBag.menu = db.LoaiSPs.ToList();
            string pass = Encode.EncodeMD5(password);
            var rs = db.users.Where(p => p.username.Equals(username) && p.password.Equals(pass)).FirstOrDefault();
           // var rs = db.users.Where(p => p.username.Equals(username)).FirstOrDefault();

            if (rs != null) // demo web
            {
                Session["users"] = rs.id;
                Session["usersname"] = rs.name;

                return RedirectToAction("Index", "Cart");
            }
            else
                TempData["check"] = "Tài khoản hoặc mật khẩu không đúng";
                return RedirectToAction("Index", "Login");
        }
    

        public ActionResult Register()
        {
            ViewBag.menu = db.LoaiSPs.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult Register(user users)
        {
            if(ModelState.IsValid)
            {
                if (users.password == null || users.password == null || users.phone == null || users.phone == null)
                {
                    TempData["check"] = "Không được để trống thông tin";
                    return RedirectToAction("Register", "Login");
                }
                else
                {
                    var check = db.users.Where(p => p.username.Equals(users.username)).FirstOrDefault();

                    if (check == null)
                    {
                        users.password = Encode.EncodeMD5(users.password);
                        users.created = DateTime.Now;
                        db.users.Add(users);
                        db.SaveChanges();
                    }
                    else
                    {
                        TempData["check"] = "Tài khoản đã tồn tại";
                        return RedirectToAction("Register", "Login");

                    }
                }    
            }
            TempData["check"] = "Đăng ký thành công";
            return RedirectToAction("Index", "Login");
        }
        public ActionResult Forgot()
        {
            ViewBag.menu = db.LoaiSPs.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult Forgot(user users)
        {
            if (ModelState.IsValid)
            {
                if (users.password == null || users.password == null || users.phone == null || users.email == null)
                {
                    TempData["check"] = "Không được để trống thông tin";
                    return RedirectToAction("Forgot", "Login");
                }
                else
                {
                    var check = db.users.Where(p => p.username.Equals(users.username)).FirstOrDefault();
                    user b = db.users.Where(p => p.username == users.username).FirstOrDefault();


                    if (check != null && b.phone == users.phone && b.email == users.email)
                    {
                        user a = db.users.Where(p => p.username == users.username).FirstOrDefault();
                        users.password = Encode.EncodeMD5(users.password);
                        a.password = users.password;
                        db.SaveChanges();
                    }
                    else
                    {
                        TempData["check"] = "Thông tin không đúng";
                        return RedirectToAction("Forgot", "Login");

                    }
                }
            }
            TempData["check"] = "Cập nhật lại mật khẩu thành công";
            return RedirectToAction("Index", "Login");
        }
    }
}