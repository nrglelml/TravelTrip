using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTrip.Models.Siniflar;

namespace TravelTrip.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog
        Context c=new Context();
        BlogYorum by = new BlogYorum();
        public ActionResult Index()
        {
           // var degerler = c.Blogs.ToList();
            by.Deger1=c.Blogs.ToList();
            
            return View(by);
        }
      
        public ActionResult BlogDetay(int id)
        {
           // var blogbul=c.Blogs.Where(x=>x.ID==id).ToList();
           //O bloga ait yorumları getirme işlemi
           by.Deger1=c.Blogs.Where(x => x.ID == id).ToList();
            by.Deger2 = c.Yorumlars.Where(x => x.BlogID == id).ToList();
            return View(by);
        }
        public PartialViewResult Partial1()
        {
            by.Deger3 = c.Blogs.OrderByDescending(x => x.ID).Take(3).ToList();
            return PartialView(by);
        }
        public PartialViewResult Partial2()
        {
            by.Deger4=c.Yorumlars.OrderByDescending(x => x.ID).Take(3).ToList();
            return PartialView(by);
        }
        [HttpGet]
       public PartialViewResult YorumYap(int id)
        {
            ViewBag.deger = id;
            return PartialView();
        }
        [HttpPost]
        public ActionResult YorumYap(Yorumlar y)
        {
            c.Yorumlars.Add(y);
            c.SaveChanges();
            TempData["YorumBasarili"] = true;
            return RedirectToAction("BlogDetay", new { id = y.BlogID });
        }
    }
}