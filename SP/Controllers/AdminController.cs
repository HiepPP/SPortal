using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SetPortal.Models;
using PagedList;
using PagedList.Mvc;
using System.IO;
using System.Net.Mail;
using System.Text;
using System.Net;


namespace SetPortal.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        SetPortalContext db = new SetPortalContext();
        [HttpGet]
        public ActionResult LoginAdmin()
        {
            if (Session["useradmin"] != null)
            {
                return RedirectToAction("QuanLyForAdmin", "Admin");
            }
            return View();
        }
        [HttpPost]
        public ActionResult LoginAdmin(UserAdmin admin)
        {
            string taikhoan = admin.UserName;
            string matkhau = admin.Password;
            UserAdmin aadmin = db.UserAdmins.SingleOrDefault(n => n.UserName == taikhoan && n.Password == matkhau);
            if (aadmin != null)
            {
                Session["useradmin"] = aadmin.UserName;
                return RedirectToAction("QuanLyForAdmin", "Admin");
            }
            else
            {
                ViewBag.thongbao = "Tai khoan hoac mat khau sai!";
            }
            return View();
        }
        public ActionResult QuanLyForAdmin()
        {
            if (Session["useradmin"] == null)
            {
                return RedirectToAction("LoginAdmin", "Admin");
            }
            return View();
        }
        //Logout
        public ActionResult Logout()
        {
            Session.Remove("useradmin");
            return View("LoginAdmin");
        }
        //Phan quan ly Eguild
        [HttpGet]
        public ActionResult QuanLyEGuild(int? page)
        {
            if (Session["useradmin"] == null)
            {
                return RedirectToAction("LoginAdmin", "Admin");
            }
            //Tạo biến số sản phẩm trên trang
            int pageSize = 9;
            //Tạo biến số trang
            int pageNumber = (page ?? 1);
            return View(db.EGuides.OrderBy(n => n.EGuildID).ToPagedList(pageNumber, pageSize));
        }
        [HttpGet]
        public ActionResult AddEguild()
        {
            if (Session["useradmin"] == null)
            {
                return RedirectToAction("LoginAdmin", "Admin");
            }
            ViewBag.MaChuDeEguide = new SelectList(db.ChuDeEGuides.ToList(), "MaChuDeEguide", "TenChuDeEguide");
            return View();
        }
        [HttpPost]
        public ActionResult AddEGuild(EGuide eguild)
        {
            ViewBag.MaChuDeEguide = new SelectList(db.ChuDeEGuides.ToList(), "MaChuDeEguide", "TenChuDeEguide");
            
                int dem;
                dem = db.EGuides.Count();
                string dem2 = (dem + 1).ToString();
                EGuide kiemtra = db.EGuides.SingleOrDefault(n => n.FileName == dem2 + ".doc");
                if (kiemtra != null)
                {
                    dem2 = dem2 + "(1)";
                }
                String path = "E:/029_HCM_HUTECH_01_NET_CF/SetPortal/SetPortal/FileTaiLieuEGuild/" + dem2 + ".doc";
                String content = eguild.Contents;
                System.IO.File.WriteAllText(path, content);

                //Luu tat ca vao database
                eguild.FileName = dem2 + ".doc";
                db.EGuides.Add(eguild);
                db.SaveChanges();
                Response.Write("<script>alert('Add new thành công!');</script>");
            
            return View();
            //return RedirectToAction("QuanLyEGuild");
        }
        [HttpGet]
        public ActionResult XoaEguild(int id)
        {
            EGuide eguild = db.EGuides.Single(n => n.EGuildID == id);
            if (eguild != null)
            {
                db.EGuides.Remove(eguild);
                db.SaveChanges();
                Response.Write("<script>alert('Xoa thành công!');</script>");
            }
            return RedirectToAction("QuanLyEguild");
        }
        [HttpGet]
        public ActionResult SuaEguild(int id)
        {
            if (Session["useradmin"] == null)
            {
                return RedirectToAction("LoginAdmin", "Admin");
            }
            EGuide eguild = db.EGuides.Single(n => n.EGuildID == id);
            ViewBag.MaChuDeEguide = new SelectList(db.ChuDeEGuides.ToList(), "MaChuDeEguide", "TenChuDeEguide");
            return View(eguild);
        }
        [HttpPost]
        public ActionResult SuaEguild(EGuide eguild)
        {
            String path = "E:/029_HCM_HUTECH_01_NET_CF/SetPortal/SetPortal/FileTaiLieuEGuild" + eguild.FileName;
            String content = eguild.Contents;
            System.IO.File.WriteAllText(path, content);

            EGuide eguild2 = db.EGuides.Single(n => n.EGuildID == eguild.EGuildID);
            eguild2.MaChuDeEguide = eguild.MaChuDeEguide;
            eguild2.Contents = eguild.Contents;
            db.SaveChanges();
            return RedirectToAction("QuanLyEGuild");
        }
        //Phan quan ly FAQ
        [HttpGet]
        public ActionResult QuanLyFAQ(int? page)
        {
            if (Session["useradmin"] == null)
            {
                return RedirectToAction("LoginAdmin", "Admin");
            }
            //Tạo biến số sản phẩm trên trang
            int pageSize = 9;
            //Tạo biến số trang
            int pageNumber = (page ?? 1);
            return View(db.FAQs.OrderBy(n => n.FaqID).ToPagedList(pageNumber, pageSize));
        }
        [HttpGet]
        public ActionResult AddFAQ()
        {
            if (Session["useradmin"] == null)
            {
                return RedirectToAction("LoginAdmin", "Admin");
            }
            ViewBag.MaChuDeFAQ = new SelectList(db.ChuDeFAQs.ToList(), "MaChuDeFAQ", "TenChuDeFAQ");
            return View();
        }
        [HttpPost]
        public ActionResult AddFAQ(FAQ faq)
        {
            ViewBag.MaChuDeFAQ = new SelectList(db.ChuDeFAQs.ToList(), "MaChuDeFAQ", "TenChuDeFAQ");

            int dem;
            dem = db.FAQs.Count();
            string dem2 = (dem + 1).ToString();
            FAQ kiemtra = db.FAQs.SingleOrDefault(n => n.FileName == dem2 + ".doc");
            if (kiemtra != null)
            {
                dem2 = dem2 + "(1)";
            }
            String path = "E:/029_HCM_HUTECH_01_NET_CF/SetPortal/SetPortal/FileTaiLieuFAQ/" + dem2 + ".doc";
            String content = "Câu hỏi: " + faq.Question + Environment.NewLine + "Câu trả lời: " + faq.Answer;
            System.IO.File.WriteAllText(path, content);

            //Luu tat ca vao database
            faq.FileName = dem2 + ".doc";

            db.FAQs.Add(faq);
            db.SaveChanges();
            Response.Write("<script>alert('Add new thành công!');</script>");

            return View();
        }
        [HttpGet]
        public ActionResult XoaFAQ(int id)
        {
            FAQ faq = db.FAQs.Single(n => n.FaqID == id);
            db.FAQs.Remove(faq);
            db.SaveChanges();
            return RedirectToAction("QuanLyFAQ");
        }
        [HttpGet]
        public ActionResult SuaFAQ(int id)
        {
            if (Session["useradmin"] == null)
            {
                return RedirectToAction("LoginAdmin", "Admin");
            }
            FAQ faq = db.FAQs.Single(n => n.FaqID == id);
            ViewBag.MaChuDeFAQ = new SelectList(db.ChuDeFAQs.ToList(), "MaChuDeFAQ", "TenChuDeFAQ");
            return View(faq);
        }
        [HttpPost]
        public ActionResult SuaFAQ(FAQ faq)
        {
            String path = "E:/029_HCM_HUTECH_01_NET_CF/SetPortal/SetPortal/FileTaiLieuFAQ" + faq.FileName;
            // String content = faq.Question;
            String content = "Câu hỏi: " + faq.Question + Environment.NewLine + "Câu trả lời: " + faq.Answer;
            System.IO.File.WriteAllText(path, content);

            FAQ faq2 = db.FAQs.Single(n => n.FaqID == faq.FaqID);
            faq2.MaChuDeFAQ = faq.MaChuDeFAQ;
            faq2.Question = faq.Question;
            faq2.Answer = faq.Answer;
            db.SaveChanges();
            return RedirectToAction("QuanLyFAQ");
        }
        //Phan quan ly Enew
        [HttpGet]
        public ActionResult AddEnew()
        {
            if (Session["useradmin"] == null)
            {
                return RedirectToAction("LoginAdmin", "Admin");
            }
            return View();
        }
        [HttpPost]
        
        public ActionResult AddEnew(Enew enew, DateTime ngayxuatban, DateTime ngayketthuc)
        {
            if (ModelState.IsValid)
            {
                //int dem = db.EmailSubcribeEnews.Count();
                //EmailSubcribeEnew[] list = db.EmailSubcribeEnews.ToArray();
                //for (int i = 0; i < dem; i++)
                //{
                //    if (list[i] != null)
                //    {
                //        var smtp = new SmtpClient("smtp.gmail.com", 25);
                //        smtp.Credentials = new NetworkCredential("kentphp2@gmail.com", "songlong");
                //        smtp.EnableSsl = true;

                //        MailMessage mail = new MailMessage();
                //        mail.From = new MailAddress("trumhero@gmail.com", "trumhero@gmail.com");
                //        mail.ReplyToList.Add("trumhero@gmail.com");
                //        mail.To.Add(list[i].EmailSubcribe);
                //        mail.Subject = enew.EnewsTitle;
                //        mail.SubjectEncoding = Encoding.UTF8;
                //        mail.Body = enew.EnewsContent;
                //        mail.BodyEncoding = Encoding.UTF8;
                //        mail.IsBodyHtml = true;
                //        smtp.Send(mail);
                //    }
                //    else
                //    {
                //        ViewBag.thongbao = "gui that bai!";
                //        return View();
                //    }
                //}
                enew.PublishDate = ngayxuatban;
                enew.EndDate = ngayketthuc;
                db.Enews.Add(enew);
                db.SaveChanges();
            }
            return View();
        }
        public ActionResult QuanLyEnew(int? page)
        {
            if (Session["useradmin"] == null)
            {
                return RedirectToAction("LoginAdmin", "Admin");
            }
            //Tạo biến số sản phẩm trên trang
            int pageSize = 9;
            //Tạo biến số trang
            int pageNumber = (page ?? 1);
            return View(db.Enews.OrderBy(n => n.EnewsID).ToPagedList(pageNumber, pageSize));
        }
        [HttpGet]
        public ActionResult SuaEnew(int id)
        {
            if (Session["useradmin"] == null)
            {
                return RedirectToAction("LoginAdmin", "Admin");
            }
            Enew enew = db.Enews.Single(n => n.EnewsID == id);
            return View(enew);
        }
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult SuaEnew(Enew enew,DateTime ngayxuatban,DateTime ngayketthuc)
        {
            Enew enew2 = db.Enews.Single(n => n.EnewsID == enew.EnewsID);
            enew2.PublishDate = ngayxuatban;
            enew2.EndDate = ngayketthuc;
            enew2.EnewsTitle = enew.EnewsTitle;
            enew2.EnewsContent = enew.EnewsContent;
            enew2.EnewsTitleM = enew.EnewsTitleM;
            enew2.EnewsContentM = enew.EnewsContentM;
            db.SaveChanges();
            return View();
        }
        public ActionResult XoaEnew(int id)
        {
            Enew enew = db.Enews.Single(n => n.EnewsID == id);
            db.Enews.Remove(enew);
            db.SaveChanges();
            return RedirectToAction("QuanLyEnew");
        }
        public ActionResult QuanLyEmailSubcribe()
        {

            return View();
        }
        public ActionResult PublicUserSubscribe(int? page)
        {
            //Tạo biến số sản phẩm trên trang
            int pageSize = 9;
            //Tạo biến số trang
            int pageNumber = (page ?? 1);
            return View(db.EmailSubcribeEnews.Where(n=>n.UserID==null).OrderBy(n => n.IDEmail).ToPagedList(pageNumber, pageSize));
        }
        public ActionResult E_ServiceUserSubscribe(int? page)
        {
            //Tạo biến số sản phẩm trên trang
            int pageSize = 9;
            //Tạo biến số trang
            int pageNumber = (page ?? 1);
            return View(db.EmailSubcribeEnews.Where(n => n.UserID != null).OrderBy(n => n.IDEmail).ToPagedList(pageNumber, pageSize));
        }
        public ActionResult XoaEmailSubscribe(int id)
        {
            EmailSubcribeEnew email = db.EmailSubcribeEnews.Single(n => n.IDEmail == id);
            if(email!=null)
            {
                db.EmailSubcribeEnews.Remove(email);
                db.SaveChanges();
                Response.Write("<script>alert('Xoa thành công!');</script>");
            }
            return RedirectToAction("PublicUserSubscribe");
        }
    }
}