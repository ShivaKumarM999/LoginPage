using LoginPage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LoginPage.Controllers
{
    public class LoginController : Controller
    {
        MyDBEntities dbContext = new MyDBEntities();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Login login)
        {
            //Login login1 = (from l in dbContext.Logins
            //                where l.UserName == login.UserName && l.Password == login.Password
            //                select l).FirstOrDefault();
            Login login1 = dbContext.Logins.Where(l => l.UserName == login.UserName && l.Password == login.Password).FirstOrDefault();
            if (login1 != null)
                return RedirectToAction("Index");
            else
            {
                ViewBag.ErrorMessage = "Please Enter Valid UserName & Passord";
                return View(login);
            }
        }
    }
}