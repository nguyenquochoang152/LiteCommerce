using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LiteCommerce.Admin.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ChangePassword()
        {
            return View();
        }
        public ActionResult SignOut()
        {
            Session.Abandon();
            Session.Clear();
            System.Web.Security.FormsAuthentication.SignOut();
            return RedirectToAction("SignIn");
        }
        [AllowAnonymous]
        [HttpGet]
        public ActionResult SignIn()
        {
            if (User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Dashboard");
            return View();
        }
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult SignIn(string email = "" , string password = "")
        {
            //TODO : Kiểm tra tài khoản thông qua cơ sở dữ liệu
            if(email =="quochoang1521998@gmail.com" && password =="123")
            {
                //Ghi nhận phiên đăng nhập của tài khoản
                System.Web.Security.FormsAuthentication.SetAuthCookie(email, false);
                //chuyển trang về Dashboard
                return RedirectToAction("Index", "Dashboard");
            }else
            {
                ModelState.AddModelError("LoginError", "Login Fail");
                ViewBag.Email = email;

                return View();
            }
            
        }
        [AllowAnonymous]
        public ActionResult ForgotPassword()
        {
            return View();
        }
    }
}