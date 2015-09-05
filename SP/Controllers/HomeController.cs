using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SetPortal.Models;

namespace SetPortal.Controllers
{
    public class HomeController : Controller
    {
        SetPortalContext db = new SetPortalContext();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult MenuLeftEnew()
        {

            var model = db.Enews.Take(2).ToList();
            return PartialView(model);
        }
    }
}