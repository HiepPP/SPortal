using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SetPortal.Models;
using System.IO;

namespace SetPortal.Controllers
{
    public class EAduanController : Controller
    {
        SetPortalContext db = new SetPortalContext();
        // GET: HomeEAduan
        public ActionResult HomeEAduan()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Reporting()
        {
            IEnumerable<NameState> State = (IEnumerable<NameState>)db.NameStates;
            ViewBag.IDState = new SelectList(State, "IDState", "State");//Tao List chon State
            return View();
        }
        [HttpPost]
        public ActionResult Reporting(EAduan eaduan, HttpPostedFileBase fileAnh, HttpPostedFileBase fileTaiLieu)
        {
            IEnumerable<NameState> State = (IEnumerable<NameState>)db.NameStates;
            ViewBag.IDState = new SelectList(State, "IDState", "State");//Tao List chon State

            //Kiem tra duong dan anh bia
            if (fileAnh == null)
            {
                ViewBag.ThongBao = "Vui long chon hinh anh!";
                return View();
            }
            if (fileTaiLieu == null)
            {
                ViewBag.ThongBao = "Vui long chon tai lieu!";
                return View();
            }
            if (ModelState.IsValid)
            {
                //Lưu tên file
                var fileName = Path.GetFileName(fileAnh.FileName);
                //Lưu đường dẫn của file
                var path = Path.Combine(Server.MapPath("~/HinhAnhEAduan"), fileName);
                //Luu hinh anh vao thu muc
                fileAnh.SaveAs(path);
                //luu vao database
                eaduan.Image = fileAnh.FileName;

                //Luu Tai Lieu
                //Lưu tên file
                var fileNametailieu = Path.GetFileName(fileTaiLieu.FileName);
                //Lưu đường dẫn của file
                var pathtailieu = Path.Combine(Server.MapPath("~/FileTaiLieuEAduan"), fileNametailieu);
                //Luu vao thu muc
                fileTaiLieu.SaveAs(pathtailieu);
                //luu vao database
                eaduan.FileName = fileTaiLieu.FileName;
                //Luu tat ca vao database
                db.EAduans.Add(eaduan);
                db.SaveChanges();
                Response.Write("<script>alert('Email được gửi thành công!');</script>");
            }
            return View();
        }
        public ActionResult TestHienThi()
        {
            return View(db.EAduans.OrderBy(n=>n.IDEAduan).ToList());
        }
    }
}