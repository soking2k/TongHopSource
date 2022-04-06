using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Net.Mail;
using G7_PhongThuyWeb.Models;
using API_MoMo;
using Newtonsoft.Json.Linq;

namespace G7_PhongThuyWeb.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        public DB_PhongThuyEntities22 db = new DB_PhongThuyEntities22();

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public ActionResult Index()
        {
            ViewBag.menu = db.LoaiSPs.ToList();
            List<CartItem> list = (List<CartItem>)Session["CartSession"];
            return View(list);
        }
        public ActionResult AddItem(int id)
        {
            ViewBag.menu = db.LoaiSPs.ToList();
            var cart = Session["cartSession"];
            List<CartItem> list = new List<CartItem>();
            if (cart == null)
            {
                SanPham sanpham = db.SanPhams.Where(x => x.id == id).SingleOrDefault();
                CartItem item = new CartItem();
                item.sanpham = sanpham;
                item.qty = 1;
                list.Add(item);
                Session["cartSession"] = list;
            }
            else
            {
                list = (List<CartItem>)Session["cartSession"];
                if (list.Exists(x => x.sanpham.id == id))
                {
                    foreach (var a in list)
                    {
                        if (a.sanpham.id == id)
                            a.qty = a.qty + 1;

                    }
                    Session["cartSession"] = list;
                }
                else
                {
                    SanPham sanpham = db.SanPhams.Where(x => x.id == id).SingleOrDefault();
                    CartItem item = new CartItem();
                    item.sanpham = sanpham;
                    item.qty = 1;
                    list.Add(item);
                    Session["cartSession"] = list;
                }

            }
            return RedirectToAction("Index", "Cart");
        }
        public ActionResult UpdateItem(int id, int qty)
        {
            List<CartItem> list = (List<CartItem>)Session["CartSession"];
            if (qty != 0)
                list.Where(p => p.sanpham.id.Equals(id)).FirstOrDefault().qty = qty;
            return RedirectToAction("Index", "Cart");

        }
        public ActionResult DeleteItem(int id)
        {
            List<CartItem> list = (List<CartItem>)Session["CartSession"];
            CartItem item = list.Where(p => p.sanpham.id.Equals(id)).FirstOrDefault();
            list.Remove(item);
            Session["CartSession"] = list;
            return RedirectToAction("Index", "Cart");
        }
        public ActionResult Order()
        {
            if (Session["users"] == null)
                return RedirectToAction("Index", "Login");
            else
            {

                ViewBag.menu = db.LoaiSPs.ToList();
                List<CartItem> list = (List<CartItem>)Session["CartSession"];
                var cart = Session["cartSession"];
                ViewBag.ordersp = list.ToList();


                //  ViewBag.menu = db.Type
                return View();
            }

        }

        [HttpPost]
        public ActionResult Order(DonHang donhang)
        {
            //if (Session["cartSession"] == null)
            //    return RedirectToAction("Index", "Home");

            string payment_method = Request["option_payment"];
            string hoten = donhang.ho_ten;
            string diachi = donhang.dia_chi;
            string ghichu = donhang.ghi_chu;
            if (payment_method != null && hoten!= null && diachi != null && ghichu != null)
            {
                if (payment_method.Equals("MOMO"))
                {
                    if (Session["users"] == null)
                        return RedirectToAction("Index", "Login");
                    else
                    {
                        DonHang od = new DonHang();
                        // check trường hợp table DONHANG trống
                        if (db.DonHangs.Count() == 0)
                        {
                            od.id = 1;
                        }
                        else
                        {
                            od.id = db.DonHangs.OrderByDescending(p => p.id).First().id + 1;
                        }


                        List<CartItem> list = (List<CartItem>)Session["cartSession"];
                        string message = "";
                        float sum = 0;
                        foreach (CartItem item in list)
                        {
                            float giamgia = 0;
                            giamgia = (float)(item.sanpham.price * item.sanpham.discount) / 100;
                            ChiTietDonHang orderDetail = new ChiTietDonHang();
                            //   orderDetail.id = db.ChiTietDonHangs.OrderByDescending(p => p.id).First().id + 1;
                            orderDetail.product_id = item.sanpham.id;
                            orderDetail.transaction_id = od.id;
                            orderDetail.qty = item.qty;

                            sum += (float)(item.qty * ((float)item.sanpham.price - (float)giamgia));
                        }


                        //return RedirectToAction("Thanks for contacting us! We'll be in contact with you soon!");


                        Random rand = new Random((int)DateTime.Now.Ticks);
                        int numIterations = 0;
                        numIterations = rand.Next(1, 100000);
                        DateTime time = DateTime.Now;
                        string orderCode = XString.ToStringNospace(numIterations + "" + time);
                        string sumOrder = sum.ToString();
                        //   string payment_method = Request["option_payment"];
                        //request params need to request to MoMo system
                        string endpoint = momoInfo.endpoint;
                        string partnerCode = momoInfo.partnerCode;
                        string accessKey = momoInfo.accessKey;
                        string serectkey = momoInfo.serectkey;
                        string orderInfo = momoInfo.orderInfo;
                        string returnUrl = momoInfo.returnUrl;
                        string notifyurl = momoInfo.notifyurl;

                        string amount = sumOrder;
                        string orderid = Guid.NewGuid().ToString();
                        string requestId = Guid.NewGuid().ToString();
                        string extraData = "";


                        //Before sign HMAC SHA256 signature
                        string rawHash = "partnerCode=" +
                            partnerCode + "&accessKey=" +
                            accessKey + "&requestId=" +
                            requestId + "&amount=" +
                            amount + "&orderId=" +
                            orderid + "&orderInfo=" +
                            orderInfo + "&returnUrl=" +
                            returnUrl + "&notifyUrl=" +
                            notifyurl + "&extraData=" +
                            extraData;

                        log.Debug("rawHash = " + rawHash);

                        MoMoSecurity crypto = new MoMoSecurity();
                        //sign signature SHA256
                        string signature = crypto.signSHA256(rawHash, serectkey);
                        log.Debug("Signature = " + signature);

                        //build body json request
                        JObject message1 = new JObject
                    {
                        { "partnerCode", partnerCode },
                        { "accessKey", accessKey },
                        { "requestId", requestId },
                        { "amount", amount },
                        { "orderId", orderid },
                        { "orderInfo", orderInfo },
                        { "returnUrl", returnUrl },
                        { "notifyUrl", notifyurl },
                        { "extraData", extraData },
                        { "requestType", "captureMoMoWallet" },
                        { "signature", signature }

                    };
                        log.Debug("Json request to MoMo: " + message1.ToString());
                        string responseFromMomo = PaymentRequest.sendPaymentRequest(endpoint, message1.ToString());
                        JObject jmessage = JObject.Parse(responseFromMomo);

                        saveOrder("Cổng thanh toán MOMO", 2, orderid, hoten, diachi, ghichu);
                        return Redirect(jmessage.GetValue("payUrl").ToString());




                        // return RedirectToAction("Index", "Home");

                    }
                }
                else if (payment_method.Equals("COD"))
                {
                    if (Session["users"] == null)
                        return RedirectToAction("Index", "Login");
                    else
                    {
                        saveOrder("Ship Code", 0, "Ship Code", hoten, diachi, ghichu);
                        TempData["check"] = "Bạn đã đặt hàng thàng công.";
                        return RedirectToAction("XemDonHang", "Cart");
                    }

                }
                else if (payment_method.Equals("NL"))
                {
                    return RedirectToAction("Order", "Cart");


                }
                else
                {
                    return RedirectToAction("Index", "Home");

                }
            }
            else
            {
                TempData["check"] = "Vui lòng nhập đầy đủ thông tin và chọn phương thức thanh toán.";
                return RedirectToAction("Order", "Cart");

            }
        }

        public void saveOrder(string paymentMethod, int StatusPayment, string ordercode,string hoten, string diachi, string ghichu)
        {
            if (Session["users"] == null)
            {
                 RedirectToAction("Index", "Home");
            }
            else
            {
                DonHang od = new DonHang();
                // check trường hợp table DONHANG trống
                if (db.DonHangs.Count() == 0)
                {
                    od.id = 1;
                }
                else
                {
                    od.id = db.DonHangs.OrderByDescending(p => p.id).First().id + 1;
                }
                List<CartItem> list = (List<CartItem>)Session["cartSession"];
                string message = "";
                float sum = 0;
                foreach (CartItem item in list)
                {
                    float giamgia = 0;
                    giamgia = (float)(item.sanpham.price * item.sanpham.discount) / 100;
                    ChiTietDonHang orderDetail = new ChiTietDonHang();
                    //   orderDetail.id = db.ChiTietDonHangs.OrderByDescending(p => p.id).First().id + 1;
                    orderDetail.product_id = item.sanpham.id;
                    orderDetail.transaction_id = od.id;
                    orderDetail.qty = item.qty;
                    db.ChiTietDonHangs.Add(orderDetail);
                    db.SaveChanges();
                    message += "<br> Mã Sản Phẩm :" + item.sanpham.id;
                    message += "<br> Tên Sản Phẩm :" + item.sanpham.name;
                    message += "<br> Số Lượng :" + item.qty;
                    message += "<br> Giá :" + String.Format("{0:0,0 VND}", item.sanpham.price);
                    message += "<br> Được Giảm :" + String.Format("{0:0,0 VND}", giamgia);

                    message += "<br> Tổng Giá / Sản Phẩm :" + String.Format("{0:0,0 VND}", item.qty * ((float)item.sanpham.price- (float)giamgia));
                    sum += (float)(item.qty * ((float)item.sanpham.price - (float)giamgia));

                }
                message += "<br> Tổng Đơn Hàng :" + String.Format("{0:0,0 VND}", sum);
                od.user_id = (int)Session["users"];
                user ct = db.users.Find(od.user_id);
                od.user_name = ct.username;
                od.user_mail = ct.email;
                od.user_phone = ct.phone;
                od.Code = ordercode;
                od.DeliveryPaymentMethod = paymentMethod;
                od.ho_ten = hoten;
                od.dia_chi = diachi;
                od.ghi_chu = ghichu;
                od.amount = sum;
                od.created = DateTime.Now;
                // od.user_name = (string)Session["usersname"];
                od.payment = 0; // 0 là chưa thanh toán, 1 là đã thanh toán
                od.status = StatusPayment; // 0-1 để check về sau có gì cần check
                db.DonHangs.Add(od);
                db.SaveChanges();
                //user ct = db.users.Find(od.user_id);
                Session["cartSession"] = null;

                SendContactEmail(ct.email, "Một đơn hàng đã được gửi đến cho bạn", message);  // _tạm Đóng Send Mail
                //return RedirectToAction("Thanks for contacting us! We'll be in contact with you soon!");

            }
        }
        public ActionResult cancel_order()
            {
                return RedirectToAction("Index", "Home");
            }
        public ActionResult confirm_orderPaymentOnline_momo()
        {

            String errorCode = Request["errorCode"];
            String orderId = Request["orderId"];

            if (errorCode == "0")
            {
                Session["SessionCart"] = null;
                var OrderInfo = db.DonHangs.Where(m => m.Code == orderId).FirstOrDefault();
                OrderInfo.payment = 1;
                db.SaveChanges();
                TempData["check"] = "Bạn đã đặt hàng thàng công.";
                return RedirectToAction("XemDonHang", "Cart");
            }
            else
            {
                ViewBag.status = false;
            }

            return RedirectToAction("Index", "Home");
        }
        public ActionResult XemDonHang()
        {

            if (Session["users"] == null)
                return RedirectToAction("Index", "Login");
            else
            {
                ViewBag.menu = db.LoaiSPs.ToList();
                int id = (int)Session["users"];
                var DonHang = db.DonHangs.Where(c => c.user_id == id).OrderByDescending(x => x.id).ToList();

                return View(DonHang);
            }
        }

        public ActionResult ChiTietHang(int id)
        {

            if (Session["users"] == null)
                return RedirectToAction("Index", "Login");
            else
            {
                ViewBag.menu = db.LoaiSPs.ToList();
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
        }
        public void SendContactEmail(string mailkh, string subject, string message)
        {
            // Your hard-coded email values (where the email will be sent from), this could be
            // define in a config file, etc.
            var email = "phamdanno3@gmail.com";
            var password = "Ngocvan789";

            // Your target (you may want to ensure that you have a property within your form so that you know
            // who to send the email to
            string address = mailkh;

            // Builds a message and necessary credentials (example using Gmail)
            var loginInfo = new NetworkCredential(email, password);
            var msg = new MailMessage();
            var smtpClient = new SmtpClient("smtp.gmail.com", 587);
            // This email will be sent from you
            msg.From = new MailAddress(email);
            // Your target email address
            msg.To.Add(new MailAddress(address));
            msg.Subject = subject;

            // Build the body of your email using the Body property of your message
            msg.Body = message;
            msg.IsBodyHtml = true;

            // Wires up and send the email
            smtpClient.EnableSsl = true;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = loginInfo;
            smtpClient.Send(msg);
        }
        /*
        [HttpPost]
        public ActionResult Contact(string mailkh, string name, string message)
        {
            // name and message will be populated with the values from the form
            ViewBag.menu = db.LoaiSPs.ToList();
            // TODO: Send e-mail or store message here
            SendContactEmail(mailkh,name, message);
            return Content("Thanks for contacting us! We'll be in contact with you soon!");
        }
        */
    

    }
}