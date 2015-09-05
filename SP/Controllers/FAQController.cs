using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SetPortal.Models;
using PagedList;
using PagedList.Mvc;

namespace SetPortal.Controllers
{
    public class FAQController : Controller
    {

        // GET: FAQ
        SetPortalContext db = new SetPortalContext();
        [HttpGet]
        public ActionResult HomeFAQ(string MaChuDe, string MaTrang)
        {
            ViewBag.keyword = "";
            if (MaTrang == null)
            {
                MaTrang = "GENERAL";
            }
            if (MaTrang == "GENERAL")
            {
                ViewBag.ListChuDe = db.ChuDeFAQs.Where(n => n.LoaiChuDeFAQ == "GENERAL").ToList();
            }
            if (MaTrang == "REGISTRATION")
            {
                ViewBag.ListChuDe = db.ChuDeFAQs.Where(n => n.LoaiChuDeFAQ == "REGISTRATION").ToList();
            }
            ViewBag.LoaiTrangDangChon = MaTrang;
            ViewBag.ChuDeDangChon = db.ChuDeFAQs.Where(n => n.MaChuDeFAQ == MaChuDe).ToList();
            ViewBag.ListFAQ = db.FAQs.Where(n => n.MaChuDeFAQ == MaChuDe).ToList();
            return View();
        }
        public ActionResult Search(string keyword)
        {
            var model = db.FAQs.Where(n => n.Answer.Contains(keyword)).ToList();
            return PartialView("SearchPartialFAQ", model);
        }

    }
}