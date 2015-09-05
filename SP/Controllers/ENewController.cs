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
    public class ENewController : Controller
    {
        // GET: ENew
        SetPortalContext db = new SetPortalContext();
        public ActionResult HomeEnew(int? page)
        {
            //Tạo biến số tin tức trên trang
            int pageSize = 9;
            //Tạo biến số trang
            int pageNumber = (page ?? 1);
            return View(db.Enews.OrderByDescending(n => n.EnewsID).ToPagedList(pageNumber, pageSize));
        }
        public ActionResult DetailEnew(int id)
        {
            var enew = db.Enews.Where(n => n.EnewsID == id).ToList();
            return View(enew);
        }
        [HttpGet]
        public ActionResult Subscribe()
        {
            return View("Subscribe");
        }
        [HttpPost]  
        public ActionResult Subscribe(EmailSubcribeEnew email)
        {
            
            if (ModelState.IsValid)
            {
                EmailSubcribeEnew email2 = db.EmailSubcribeEnews.SingleOrDefault(n => n.EmailSubcribe == email.EmailSubcribe);
                if (email2 != null)
                {
                    ViewBag.thongbao = "Email da ton tai!";
                    return View();
                }
                else
                {
                    if (Session["TaiKhoan"] != null)
                    {
                        email.UserID = Session["TaiKhoan"].ToString();
                        email.EmailSubcribe = Session["Email"].ToString();
                    }
                    db.EmailSubcribeEnews.Add(email);
                    db.SaveChanges();
                    Response.Write("<script>alert('Bạn đã Subcribe thành công!');</script>");
                }
            }
            return View();
        }
        [HttpGet]
        public ActionResult UnSubscribe()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UnSubscribe(EmailSubcribeEnew email)
        {
            if (ModelState.IsValid)
            {
                EmailSubcribeEnew email2 = db.EmailSubcribeEnews.SingleOrDefault(n => n.EmailSubcribe == email.EmailSubcribe);
                if (email2 == null)
                {
                    ViewBag.thongbao = "Email không tồn tại!";
                    return View();
                }
                else
                {
                    db.EmailSubcribeEnews.Remove(email2);
                    db.SaveChanges();
                    Response.Write("<script>alert('Bạn đã Unsubcribe thành công!');</script>");
                }
            }
            return View();
        }
        [HttpGet]
        public ActionResult ArchivedEnew()
        {

            ViewBag.allyear = new SelectList(db.ArchivedEnews.ToList(),"", "Year");

            List<String> AllMonth = new List<string>();
            AllMonth.Add("01");
            AllMonth.Add("02");
            AllMonth.Add("03");
            AllMonth.Add("04");
            AllMonth.Add("05");
            AllMonth.Add("06");
            AllMonth.Add("07");
            AllMonth.Add("08");
            AllMonth.Add("09");
            AllMonth.Add("10");
            AllMonth.Add("11");
            AllMonth.Add("12");
            ViewBag.allmonth = new SelectList(AllMonth);
            return View();
        }
        [HttpPost]
        public ActionResult ArchivedEnew(int allyear, int? allmonth)
        {
            ViewBag.allyear = new SelectList(db.ArchivedEnews.ToList(), "", "Year");

            List<String> AllMonth = new List<string>();
            AllMonth.Add("01");
            AllMonth.Add("02");
            AllMonth.Add("03");
            AllMonth.Add("04");
            AllMonth.Add("05");
            AllMonth.Add("06");
            AllMonth.Add("07");
            AllMonth.Add("08");
            AllMonth.Add("09");
            AllMonth.Add("10");
            AllMonth.Add("11");
            AllMonth.Add("12");
            ViewBag.allmonth = new SelectList(AllMonth);
            var model = new object();
            if (allmonth == null)
            {
                model = db.Enews.Where(n => n.PublishDate.Value.Year == allyear).ToList();
            }
            else
            {
                model = db.Enews.Where(n => n.PublishDate.Value.Year == allyear && n.PublishDate.Value.Month == allmonth).ToList();
            }
            return View(model);
            
        }
    }
}