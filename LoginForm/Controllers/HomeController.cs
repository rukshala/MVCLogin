using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LoginForm.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        //public ActionResult About()
        //{
        //    ViewBag.Message = "Your application description page.";

        //    return View();
        //}

        //public ActionResult Contact()
        //{
        //    ViewBag.Message = "Your contact page.";

        //    return View();
        //}

        public ActionResult login() {
            return View();

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult login(Table u) { 
            if(ModelState.IsValid){
                using (LoginDatabaseEntities cdb = new LoginDatabaseEntities())
                {
                    var i = cdb.Tables.Where(a => a.username.Equals(u.username) && a.password.Equals(u.password)).FirstOrDefault();
                    if (i != null) {
                        Session["LoggedUserusername"] = i.username.ToString();
                        return RedirectToAction("AfterLogin");
                    }
                    else
                    {
                        return RedirectToAction("LoginFailed");
                    }
                }
            }
            return View(u);
        }

        public ActionResult AfterLogin() {

            return View();
        }

        public ActionResult LoginFailed() {

            return View();
        }
    }
}