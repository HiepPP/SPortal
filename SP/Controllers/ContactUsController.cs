using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using SetPortal.Models;

namespace SetPortal.Controllers
{
    public class ContactUsController : Controller
    {
        //
        // GET: /ContactUs/
        SetPortalContext db = new SetPortalContext();
        [HttpGet]
        public ActionResult ContactUsPublicUser()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ContactUsPublicUser(ContactWithU contact, HttpPostedFileBase fileUpload)
        {
            //Kiem tra duong dan anh bia
            if (fileUpload == null)
            {
                ViewBag.ThongBao = "Vui long chon hinh anh!";
                return View();
            }
            if (ModelState.IsValid)
            {
                //Lưu tên file
                var fileName = Path.GetFileName(fileUpload.FileName);
                //Lưu đường dẫn của file
                var path = Path.Combine(Server.MapPath("~/HinhAnhContact"), fileName);
                //Luu hinh anh vao thu muc
                fileUpload.SaveAs(path);
                //luu vao database
                contact.HinhAnh = fileUpload.FileName;
                db.ContactWithUs.Add(contact);
                db.SaveChanges();
                Response.Write("<script>alert('Email được gửi thành công!');</script>");
            }
            return View();
        }
        [HttpGet]
        public ActionResult ContactUsKDRM()
        {
            if (Session["Email"] == null)
            {
                Session["Email"] = "NULL";
            }
            if (Session["TaiKhoan"] == null)
            {
                return RedirectToAction("Login", "Account");
            }
            ViewBag.Email = Session["Email"];
            ViewBag.taikhoan = "Welcome     " + ViewBag.tk;
            return View();
        }
        [HttpPost]
        public ActionResult ContactUsKDRM(ContactWithU contact, HttpPostedFileBase fileUpload)
        {
            if (Session["Email"] == null)
            {
                Session["Email"] = "NULL";
            }
            ViewBag.Email = Session["Email"];
            ViewBag.taikhoan = "Welcome     " + ViewBag.tk;
            //Kiem tra duong dan anh bia
            if (fileUpload == null)
            {
                ViewBag.ThongBao = "Vui long chon hinh anh!";
                return View();
            }
            if (ModelState.IsValid)
            {
                //Lưu tên file
                var fileName = Path.GetFileName(fileUpload.FileName);
                //Lưu đường dẫn của file
                var path = Path.Combine(Server.MapPath("~/HinhAnhContact"), fileName);
                //Luu hinh anh vao thu muc
                fileUpload.SaveAs(path);
                //luu vao database
                contact.Name = Session["TaiKhoan"].ToString();
                contact.Email = Session["Email"].ToString();
                contact.HinhAnh = fileUpload.FileName;
                db.ContactWithUs.Add(contact);
                db.SaveChanges();
                Response.Write("<script>alert('Email được gửi thành công!');</script>");
            }
            return View();
        }
        [HttpGet]
        public ActionResult TestHinhAnh()
        {
            return View();
        }
        [HttpPost]
        public ActionResult TestHinhAnh(ContactWithU Contact, HttpPostedFileBase fileUpload)
        {
            //Kiem tra duong dan anh bia
            if (fileUpload == null)
            {
                ViewBag.ThongBao = "Vui long chon hinh anh!";
                return View();
            }
            if (ModelState.IsValid)
            {
                //Lưu tên file
                var fileName = Path.GetFileName(fileUpload.FileName);
                //Lưu đường dẫn của file
                var path = Path.Combine(Server.MapPath("~/HinhAnhContact"), fileName);
                //Luu hinh anh vao thu muc
                fileUpload.SaveAs(path);
                //luu vao database
                Contact.HinhAnh = fileUpload.FileName;
                db.ContactWithUs.Add(Contact);
                db.SaveChanges();
            }
            return View();
        }
        public ActionResult TestHienThi()
        {
            return View(db.ContactWithUs.OrderBy(n => n.ID).ToList());
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult submit()
        {
            return View();
        }
    }
}