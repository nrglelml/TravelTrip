using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTrip.Models.Siniflar;

namespace TravelTrip.Controllers
{
    public class HomeController : Controller
    {
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler=c.Blogs.ToList();
            return View(degerler);
        }
     
        public PartialViewResult Partial1()
        {
            var degerler = c.Blogs.ToList();
            return PartialView(degerler);
        }
        public PartialViewResult Partial2()
        {
            var deger=c.Blogs.ToList();
            return PartialView(deger);
        }

        public PartialViewResult Partial3()
        {
            var deger = c.Blogs.ToList();
            return PartialView(deger);
        }


        public ActionResult Contact()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Contact(Iletisim i)
        {
            c.Iletisims.Add(i);
            c.SaveChanges();
            return View();
        }



    }
}