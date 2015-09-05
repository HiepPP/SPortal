using SetPortal.Models;
using SetPortal.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Profile;
using System.Web.Security;

namespace SetPortal.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {

        SetPortalContext db = new SetPortalContext();
        // GET: Account
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult Login(User u, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var userSuccess = db.Users.Where(x => x.UserID.Equals(u.UserID) && x.UserPassword.Equals(u.UserPassword)).SingleOrDefault();
                var userFail = db.Users.Where(x => x.UserID.Equals(u.UserID) && x.UserPassword != u.UserPassword).SingleOrDefault();
                if (userSuccess != null && userSuccess.TimesLoginFail < 3)
                {
                    //Session["TaiKhoan"] = userSuccess.UserID;
                    FormsAuthentication.SetAuthCookie(userSuccess.UserID, false);
                    Session["TaiKhoan"] = userSuccess.UserID;
                    Session["Email"] = userSuccess.Email;
                    var profile = ProfileBase.Create(u.UserID);
                    if (userSuccess.DateTimeLogin == null)
                    {
                        userSuccess.DateTimeLogin = DateTime.Now;
                        db.SaveChanges();
                        return RedirectToAction("FirstTimeLogin", "Account");
                    }
                    else
                        return RedirectToAction("Index", "Home");
                }
                else if(userFail != null && userFail.TimesLoginFail <3)
                {
                    userFail.TimesLoginFail += 1;
                    db.SaveChanges();
                    ViewBag.Error = "Incorrect UserID or password, please try again";
                    ModelState.AddModelError("", "wrong pass");
                }
                else if( userSuccess != null && userSuccess.TimesLoginFail >= 3)
                {
                    ViewBag.Error = "Your account have been banned";
                }
                else if(userFail != null && userFail.TimesLoginFail >= 3)
                {
                    ViewBag.Error = "Banned";
                }
            }
            return View();
        }
        [Authorize]
        [HttpGet]
        public ActionResult FirstTimeLogin(FirstTimeLoginViewModel model)
        {
            ViewBag.Select1 = new SelectList(db.Question1.Take(1).ToList(), "IDQuestion1", "Question11");
            ViewBag.Select2 = new SelectList(db.Question1.Where(x=>x.IDQuestion1 >1 && x.IDQuestion1<=3).ToList(), "IDQuestion1", "Question11");
            ViewBag.Select3 = new SelectList(db.Question3.ToList(), "IDQuestion3", "Question31");
            //db.Question1.Take(3).ToList();
            //db.Question1.Where(x => x.IDQuestion1 >= 2 && x.IDQuestion1 <= 3);
            //db.Question2.Where(x => x.IDQuestion2 >= 1 && x.IDQuestion2 <=3).ToList();
            return View();
        }
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult FirstTimeLogin(FirstTimeLoginViewModel model, FormCollection f)
        {
            var userlogin = db.Users.FirstOrDefault(x => x.UserID == System.Web.HttpContext.Current.User.Identity.Name);
            if (ModelState.IsValid)
            {
                if (userlogin.UserPassword == model.UserPassword)
                {
                    if (userlogin.UserPassword == model.NewPassword)
                    {
                        ViewBag.loi = "trung pass";
                        return View();
                    }
                    else
                    {
                        userlogin.Answer1 = model.Answer1;
                        userlogin.Answer2 = model.Answer2;
                        userlogin.Answer3 = model.Answer3;
                        userlogin.UserPassword = model.NewPassword;
                        ViewBag.Select1 = new SelectList(db.Question1, "IDQuestion1", "Question11");
                        ViewBag.Select2 = new SelectList(db.Question2, "IDQuestion2", "Question21",userlogin.IDQuestion2);
                        ViewBag.Select3 = new SelectList(db.Question3, "IDQuestion3", "Question31",userlogin.IDQuestion3);
                        var id1 = f.Get("Select1");
                        userlogin.IDQuestion1 = Convert.ToInt32(id1);
                        var id2 = f.Get("Select2");
                        userlogin.IDQuestion2 = Convert.ToInt32(id2);
                        var id3 = f.Get("Select3");
                        userlogin.IDQuestion3 = Convert.ToInt32(id3);
                        db.SaveChanges();
                        return RedirectToAction("Index", "Home");
                    }
                }
            }
            return View();
        }
        [Authorize]
        [HttpGet]
        public ActionResult ChangePass()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult ChangePass(FirstTimeLoginViewModel model)
        {
            var userlogin = db.Users.FirstOrDefault(x => x.UserID == System.Web.HttpContext.Current.User.Identity.Name);
            if (ModelState.IsValid)
            {
                if (userlogin.UserPassword == model.UserPassword)
                {
                    if (userlogin.UserPassword == model.NewPassword )
                    {
                        ViewBag.message = "New password must be different from the old password";
                        return View();
                    }
                    else if(userlogin.UserID == model.NewPassword)
                    {
                        ViewBag.message = "Password must be different from User ID";
                        return View();
                    }
                    else
                    {
                        userlogin.UserPassword = model.NewPassword;
                        db.SaveChanges();
                        ViewBag.message = "Your password has been successfully changed!";
                        return View();
                    }
                }
            }
            ViewBag.message = "Nhập liệu để thay đổi password,dữ liệu không chính xác";
            return View();
        }
        [Authorize]
        public ActionResult Logout()
        {
            Session.Abandon();
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        [Authorize(Roles="Admin")]
        public ActionResult UnlockUser()
        {
            var model = db.Users.Where(x => x.TimesLoginFail > 3).ToList();
            return View(model);
        }
        [HttpPost]
        [Authorize(Roles="Admin")]
        public ActionResult UnlockUser(User u)
        {
            var model = db.Users.Where(x => x.TimesLoginFail > 3).FirstOrDefault();
            if(model != null)
            {
                model.TimesLoginFail = 0;
                db.SaveChanges();
            }
            else
            {
                ViewBag.message = "List banned user is empty"; 
            }
            return RedirectToAction("UnlockUser", "Account");
        }
       
    }
}