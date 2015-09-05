using SetPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using SetPortal.Models.ViewModel;

namespace SetPortal.Controllers
{
    public class SearchController : Controller
    {
        // GET: Search
        SetPortalContext db = new SetPortalContext();
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult SearchPartial()
        {

            return PartialView();
        }
        public ActionResult SearchView()
        {

            return View();
        }
        [HttpPost]
        //public ActionResult SearchResult(int? page, FormCollection f, SearchViewModel sview, string dropdownlist)
        //{
        //    //string timkiem = f.Get("timkiem");
        //    //string AllGST = f["AllGST"];
        //    //string FAQs = f["FAQs"];
        //    //string eGuide = f["eGuide"];
        //    string TuKhoa = f["txtSearch"].ToString();
        //    var kqFAQ = db.FAQs.Where(x => x.Question.Contains(TuKhoa) || x.Answer.Contains(TuKhoa)).ToList();
        //    var kqEguide = db.EGuides.Where(x => x.Contents.Contains(TuKhoa)).OrderBy(x => x.EGuildID).ToList();
        //     //Phan trang tim kiem,
        //    var ketqua = db.FAQs.Where(x => x.Question.Contains(TuKhoa) || x.Answer.Contains(TuKhoa)).ToList();
        //    int pageNumber = (page ?? 1);
        //    int pageSize = 5;
        //    if (kqFAQ != null && dropdownlist=="FAQs")
        //    {
        //        return View(kqFAQ.ToPagedList(pageNumber, pageSize));
        //    }
        //    else if (kqEguide != null && dropdownlist == "eGuide")
        //    {
        //        return View(kqEguide.ToPagedList(pageNumber, pageSize));
        //    }
        //    ViewBag.message = "Không tìm thấy kết quả";
        //    return View();
        //}
        public ActionResult SearchResult(int? page,SearchViewModel sview)
        {
            string TuKhoa = sview.tukhoa;
            if(sview.tukhoa== null && sview.dropdown=="-Select-")
            {
                ViewBag.message = "Nhập từ khóa";
                return RedirectToAction("SearchResult", "Search");
            }
            var kqFAQ = db.FAQs.Where(x => x.Question.Contains(TuKhoa) || x.Answer.Contains(TuKhoa)).ToList();
            var kqEguide = db.EGuides.Where(x => x.Contents.Contains(TuKhoa)).OrderBy(x => x.EGuildID).ToList();
            var k = new List<SearchViewModel>();
            var p = new List<SearchViewModel>();
            foreach (var item in kqFAQ)
            {
                var l = new SearchViewModel
                {
                    Answer = item.Answer,
                    Question = item.Question,
                    MaChuDeFAQ = item.MaChuDeFAQ,
                };
                k.Add(l);
            }
            foreach (var item in kqEguide)
            {
                var o = new SearchViewModel
                {
                    Contents = item.Contents,
                };
                p.Add(o);
            }
            //Phan trang tim kiem,
            int pageNumber = (page ?? 1);
            int pageSize = 5;
            if (k != null && sview.dropdown == "FAQs")
            {
                return View(k.ToPagedList(pageNumber, pageSize));
            }
            else if (p != null && sview.dropdown == "eGuide")
            {
                return View(p.ToPagedList(pageNumber, pageSize));
            }
            ViewBag.message = "Không tìm thấy kết quả";
            return View();
        }

        public ActionResult Search()
        {
            var data = Request["txtSearch"];
            var search = db.FAQs.Where(x => x.Question.Contains(data) || x.Answer.Contains(data)).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}