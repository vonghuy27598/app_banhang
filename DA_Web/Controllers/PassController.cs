using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DA_Web.Models;
using System.Net.Mail;
using System.Web.Services.Description;
using System.Net;
using System.Text;
using System.Security.Cryptography;
using DA_Web.ViewModel;

namespace DA_Web.Controllers
{
    public class PassController : Controller
    {
        //
        // GET: /Pass/
        dbQL_BanHangDataContext db = new dbQL_BanHangDataContext();
        public ActionResult DoiMK()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DoiMK(FormCollection collection)
        {
            Table_NHANVIEN nv = (Table_NHANVIEN)Session["User1"];
            var matkhaucu = collection["MatKhauCu"];
            var matkhau = collection["MatKhau"];
            var nlmatkhau = collection["NhapLaiMatKhau"];
            var upMK = db.Table_NHANVIENs.First(m => m.ID_NHANVIEN == nv.ID_NHANVIEN);
            if (Str_Encoder(matkhaucu) == nv.Password)
            {
                if (matkhau == nlmatkhau)
                {
                    upMK.Password = Str_Encoder(matkhau);
                    UpdateModel(upMK);
                    db.SubmitChanges();
                    Response.Write("<script>alert('Đổi mật khẩu thành công')</script>");
                    return RedirectToAction("Me", "NhanVien");
                }
                else
                {
                    ViewData["LoiMK"] = "Xác Nhận Mật Khẩu KHÔNG Trùng Khớp";
                }
            }
            else
            {
                ViewData["LoiMK1"] = "Mật khẩu cũ không đúng";
            }
            return this.DoiMK();
        }

        public string Str_Encoder(string str)
        {
            UnicodeEncoding encoding = new UnicodeEncoding();
            Byte[] hashBytes = encoding.GetBytes(str);
            // Compute the SHA-1 hash
            SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider();
            Byte[] crypt_str = sha1.ComputeHash(hashBytes);
            return BitConverter.ToString(crypt_str);
        }

        public ActionResult QuenMK()
        {
            return View();
        }

        [HttpPost]
        public ActionResult QuenMK(string EmailCF)
        {
            string messe = " ";
            bool status = false;

            var account = db.Table_NHANVIENs.Where(m => m.Email == EmailCF).FirstOrDefault();
            if (account != null)
            {
                string rsCode = EncodeTo64(DateTime.Now.TimeOfDay.ToString());
                GuiEmailXN(account.Email, rsCode, "DatLaiMK");
                account.Code = rsCode;
                db.SubmitChanges();
                messe = "Kiểm tra hộp thư của bạn !!!";
            }
            else
            {
                messe = "Email chưa được đăng ký !!!";
            }
            ViewBag.Message = messe;
            return View();
        }

        [NonAction]
        public void GuiEmailXN(string emailXN, string CodeXN, string emailFor = "DatLaiMK")
        {

            //get link
            var vrfURL = "/Pass/" + emailFor + "/" + CodeXN;
            var link = Request.Url.AbsoluteUri.Replace(Request.Url.PathAndQuery, vrfURL);
            //gui thu
            var fromEmail = new MailAddress("qunag7190@gmail.com", "Quang Vlogs");
            var toEmail = new MailAddress(emailXN);
            var fromEmailPass = "270134275";
            //noi dung
            var subject = "";
            var body = "";
            subject = "Đặt lại mật khẩu";
            body = "Chào bạn, <br/> Chúng tôi nhận được yêu cầu đặt lại mật khẩu cho tài khoản của bạn. Vui lòng nhấp vào link dưới đây để đặt lại mật khẩu của bạn: " +
                    "<br/><a href=" + link + "> Đặt lại mật khẩu </a>";
            //smtp
            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromEmail.Address, fromEmailPass)
            };
            //gui mail di
            using (var mess = new MailMessage(fromEmail, toEmail)
            {
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            })
                smtp.Send(mess);
        }

        public ActionResult DatLaiMK(string id)
        {
            Session["Check"] = "ok";
            var user = db.Table_NHANVIENs.Where(m => m.Code == id).FirstOrDefault();
            if (user != null)
            {
                ResetPassword rs = new ResetPassword();
                rs.ReserCode = id;
                return View(rs);
            }
            else
            {
                return HttpNotFound();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DatLaiMK(ResetPassword rs)
        {
            var message = "";
            if (ModelState.IsValid)
            {
                var user = db.Table_NHANVIENs.Where(m => m.Code == rs.ReserCode).FirstOrDefault();
                if (user != null)
                {
                    if (rs.Password == rs.RePassword)
                    {
                        user.Password = Str_Encoder(rs.Password);
                        user.Code = "";
                        db.SubmitChanges();

                        message = "Đặt lại mật khẩu thành công";
                        Session["Check"] = null;
                    }
                    else
                    {
                        message = "Xác nhận mật khẩu không trùng khớp";
                    }
                }
            }
            else
            {
                message = "Lỗi";
            }
            ViewBag.Message = message;
            return View(rs);
        }

        //Base64
        static public string EncodeTo64(string toEncode)
        {

            byte[] toEncodeAsBytes

                  = System.Text.ASCIIEncoding.ASCII.GetBytes(toEncode);

            string returnValue

                  = System.Convert.ToBase64String(toEncodeAsBytes);

            return returnValue;

        }
    }
}