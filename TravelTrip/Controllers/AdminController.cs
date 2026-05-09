using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using TravelTrip.Models.Siniflar;

namespace TravelTrip.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        // GET: Admin
        Context c = new Context();
        
        public ActionResult Index()
        {
            var degerler = c.Blogs.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniBlog()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniBlog(Blog p , HttpPostedFileBase ImageFile)
        {
            if (!ModelState.IsValid) // Eğer modeldeki [Required] kurallarına uyulmamışsa
            {
                return View(p); // Sayfayı hatalarla birlikte geri döndür
            }
            if (ImageFile != null && ImageFile.ContentLength > 0)
            {
                string extension = Path.GetExtension(ImageFile.FileName).ToLower();
                string[] allowedExtensions = { ".jpg", ".jpeg", ".png" };

                if (allowedExtensions.Contains(extension))
                {
                    string fileName = Guid.NewGuid().ToString() + extension;
                    string path = Path.Combine(Server.MapPath("~/Images/"), fileName);

                    if (!Directory.Exists(Server.MapPath("~/Images/")))
                        Directory.CreateDirectory(Server.MapPath("~/Images/"));

                    ImageFile.SaveAs(path);
                    p.BlogImage = "/Images/" + fileName;
                }
                else
                {
                    // Geçersiz uzantı hatası
                    ModelState.AddModelError("", "Sadece JPG, JPEG ve PNG formatları kabul edilir.");
                    return View(p);
                }
            }

            p.Tarih = DateTime.Now;
            c.Blogs.Add(p);
            c.SaveChanges();
            ViewBag.Basarili = true;
            return View();
        }
        public ActionResult BlogSil(int id)
        {
            var b = c.Blogs.Find(id);
            var yorumlar = c.Yorumlars.Where(x => x.BlogID == id).ToList();
            foreach (var item in yorumlar)
            {
                c.Yorumlars.Remove(item);
            }
            c.Blogs.Remove(b);
            c.SaveChanges();

            TempData["SilmeMesaj"] = "Blog ve bağlı tüm yorumlar başarıyla silindi.";
            return RedirectToAction("Index");
        }
        public ActionResult BlogGetir(int id)
        {
            var blg = c.Blogs.Find(id);
            return View(blg);
        }
        [HttpPost]
        public ActionResult BlogGuncelle(Blog p, HttpPostedFileBase ImageFile)
        {
            var blg = c.Blogs.Find(p.ID);
            if (ImageFile != null && ImageFile.ContentLength > 0)
            {
                string extension = Path.GetExtension(ImageFile.FileName).ToLower();
                string[] allowedExtensions = { ".jpg", ".jpeg", ".png" };

                if (allowedExtensions.Contains(extension))
                {
                    string fileName = Guid.NewGuid().ToString() + extension;
                    string path = Path.Combine(Server.MapPath("~/Images/"), fileName);

                    if (!Directory.Exists(Server.MapPath("~/Images/")))
                        Directory.CreateDirectory(Server.MapPath("~/Images/"));

                    ImageFile.SaveAs(path);
                    blg.BlogImage = "/Images/" + fileName;
                }
                else
                {
                    
                    ModelState.AddModelError("", "Sadece JPG, JPEG ve PNG formatları kabul edilir.");
                    return View("BlogGetir", blg);
                }
            }
            else if (!string.IsNullOrEmpty(p.BlogImage))
            {
                blg.BlogImage = p.BlogImage;
            }
            blg.Baslik = p.Baslik;
            blg.Aciklama = p.Aciklama; 
            blg.Tarih = DateTime.Now;
            c.SaveChanges();
            ViewBag.Basarili = true;
            return View("BlogGetir",blg);
        }
        public ActionResult BlogDetay(int id)
        {
            var blg = c.Blogs.Find(id);
            var degerler = c.Blogs.ToList();
            return View(degerler);
        }
        public ActionResult YorumListesi()
        {
            var yorumlar=c.Yorumlars.ToList();
            return View(yorumlar);
        }
        public ActionResult YorumSil(int id)
        {
            var yrm = c.Yorumlars.Find(id);
            c.Yorumlars.Remove(yrm);
            c.SaveChanges();
            TempData["SilmeMesaj"] = "Yorum başarıyla silindi.";
            return RedirectToAction("YorumListesi");
        }
        public ActionResult YorumGetir(int id)
        {
            var yrm = c.Yorumlars.Find(id);
            return View(yrm);
        }
        [HttpPost]
        public ActionResult YorumGuncelle(Yorumlar p)
        {
            var yrm = c.Yorumlars.Find(p.ID);
            yrm.KullaniciAdi = p.KullaniciAdi;
            yrm.Mail = p.Mail;
            yrm.Yorum = p.Yorum;
            c.SaveChanges();
            ViewBag.Basarili = true;
            return View("YorumGetir", yrm);
        }

        public ActionResult Contact()
        {
            var mesajlar = c.Iletisims.ToList();
            return View(mesajlar);
        }

        public ActionResult Hakkimizda()
        {
            var degerler = c.Hakkimizdas.ToList();
            return View(degerler);
        }

        public ActionResult HakkimizdaGuncelle(int id)
        {
            var h = c.Hakkimizdas.Find(id);
            return View(h);
        }

        [HttpPost]
        public ActionResult HakkimizdaGuncelle(Hakkimizda p, HttpPostedFileBase ImageFile)
        {
            var h = c.Hakkimizdas.Find(p.ID);

            if (ImageFile != null && ImageFile.ContentLength > 0)
            {
                string extension = Path.GetExtension(ImageFile.FileName).ToLower();
                string[] allowedExtensions = { ".jpg", ".jpeg", ".png" };

                if (allowedExtensions.Contains(extension))
                {
                    string fileName = Guid.NewGuid().ToString() + extension;
                    string path = Path.Combine(Server.MapPath("~/Images/"), fileName);

                    if (!Directory.Exists(Server.MapPath("~/Images/")))
                        Directory.CreateDirectory(Server.MapPath("~/Images/"));

                    ImageFile.SaveAs(path);
                    h.FotoURL = "/Images/" + fileName;
                }
            }
            else if (!string.IsNullOrEmpty(p.FotoURL))
            {
                h.FotoURL = p.FotoURL;
            }

            h.Aciklama = p.Aciklama;
            c.SaveChanges();
            return RedirectToAction("Hakkimizda","Admin");
        }
    }
    
}