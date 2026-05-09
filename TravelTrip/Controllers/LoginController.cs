using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TravelTrip.Models.Siniflar;

namespace TravelTrip.Controllers
{
    public class LoginController : Controller
    {
        // GET: LoginDefault
        Context c = new Context();
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Admin adm)
        {
            var bilgiler = c.Admins.FirstOrDefault(x => x.Kullanici == adm.Kullanici && x.Sifre == adm.Sifre);
            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.Kullanici, false);
                Session["Kullanici"] = bilgiler.Kullanici.ToString();
                ViewBag.BasariliMi = true;
                return View();
            }
            else
            {
                ViewBag.BasariliMi = false;
                return View();
            }
        }
        public ActionResult Logout()
        { 
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Login");
        }
    }
}