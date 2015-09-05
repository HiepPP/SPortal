using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SetPortal.Models;

namespace SetPortal.Controllers
{
    public class EGuildController : Controller
    {
        // GET: EGuild
        SetPortalContext db = new SetPortalContext();
        [HttpGet]
        public ActionResult HomeEGuild(string MaChuDe, string MaTrang)
        {

            if (MaTrang == null)
            {
                MaTrang = "GENERAL";
            }
            if (MaTrang == "GENERAL")
            {
                ViewBag.ListChuDe = db.ChuDeEGuides.Where(n => n.LoaiChuDeEguide == "GENERAL").ToList();
            }
            if (MaTrang == "REGISTRATION")
            {
                ViewBag.ListChuDe = db.ChuDeEGuides.Where(n => n.LoaiChuDeEguide == "REGISTRATION").ToList();
            }
            ViewBag.LoaiTrangDangChon = MaTrang;
            ViewBag.ChuDeDangChon = db.ChuDeEGuides.Where(n => n.MaChuDeEguide == MaChuDe).ToList();
            ViewBag.ListEGuild = db.EGuides.Where(n => n.MaChuDeEguide == MaChuDe).ToList();
            return View();
        }

        public ActionResult Search(string keyword)
        {

            var model = db.EGuides.Where(n => n.Contents.Contains(keyword)).ToList();
            return PartialView("SearchPartialEGuild", model);
        }
    }
}