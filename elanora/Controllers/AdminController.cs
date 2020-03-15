using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using elanora.Models;

namespace elanora.Controllers
{
    
    public class AdminController : YetkiController
    {
        elanoraDb db = new elanoraDb();

        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AdminGiris()
        {
            return View();
        }
        [HttpGet]  
        public ActionResult MakaleEkle()
        {
            ViewBag.KategoriId = new SelectList(db.Kategorilers,"Kid", "KategoriAdi");
            return View();
        }
        [HttpPost]
        public ActionResult MakaleEkle(Makaleler model)
        {
            /*yöntem1
            if (ModelState.IsValid)
            {

                var file = Request.Files["ImageUpload"];
                if (file != null && file.ContentLength > 0)
                {
                    var uploadDir = "/Content/img/";
                    var imagePath = Path.Combine(Server.MapPath(uploadDir), file.FileName);
                    var imageUrl = Path.Combine(uploadDir, file.FileName);
                    file.SaveAs(imagePath);
                    model.MakaleResim = imageUrl;
                }

            }*/

            db.Makalelers.Add(model);
            db.SaveChanges();

            return RedirectToAction("MakaleListele");
        }
        public ActionResult MakaleListele(Makaleler model)
        {
            var listeleme = db.Makalelers.ToList();
            return View(listeleme);
        }
        [HttpGet]
        public ActionResult MakaleDuzenle(int id)
        {

            ViewBag.KategoriId = new SelectList(db.Kategorilers, "Kid", "KategoriAdi");
            var makale = db.Makalelers.Where(i => i.Mid == id).SingleOrDefault();
            if (makale.Mid == id)
                return View();

            return HttpNotFound();
        }
        [HttpPost]
        public ActionResult MakaleDuzenle(int id,Makaleler model)
        {
            try
            {
                var makale = db.Makalelers.Where(i => i.Mid == id).SingleOrDefault();
                makale.Baslik = model.Baslik;
                makale.Icerik = model.Icerik;
                makale.KategoriId = model.KategoriId;
                makale.MakaleResim = model.MakaleResim;
                db.SaveChanges();

                return RedirectToAction("MakaleListele");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult MakaleSil(int id,Makaleler model)
        {
            var makale = db.Makalelers.Where(i => i.Mid == id).SingleOrDefault();
            db.Makalelers.Remove(makale);
            db.SaveChanges();
            return RedirectToAction("MakaleListele");
        }
        [HttpGet]
        public ActionResult KategoriEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult KategoriEkle(Kategoriler model)
        {
            db.Kategorilers.Add(model);
            db.SaveChanges();
            return RedirectToAction("KategoriListele");
        }
        public ActionResult KategoriListele(Kategoriler model)
        {
            var listeleme = db.Kategorilers.ToList();
            return View(listeleme);
        }
        [HttpGet]
        public ActionResult KategoriDuzenle(int id)
        {
            var kategori = db.Kategorilers.Where(i => i.Kid == id).SingleOrDefault();
            if (kategori.Kid == id)
                return View();

            return HttpNotFound();
        }
        [HttpPost]
        public ActionResult KategoriDuzenle(int id, Kategoriler model)
        {
            try
            {
                var kategori = db.Kategorilers.Where(i => i.Kid == id).SingleOrDefault();
                kategori.KategoriAdi = model.KategoriAdi;
                db.SaveChanges();

                return RedirectToAction("KategoriListele");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult KategoriSil(int id, Makaleler model)
        {
            var kategori = db.Kategorilers.Where(i => i.Kid == id).SingleOrDefault();
            db.Kategorilers.Remove(kategori);
            db.SaveChanges();
            return RedirectToAction("KategoriListele");
        }
        [HttpGet]
        public ActionResult EtiketEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult EtiketEkle(Etiketler model)
        {
            db.Etiketlers.Add(model);
            db.SaveChanges();
            return RedirectToAction("EtiketListele");
        }
        public ActionResult EtiketListele(Etiketler model)
        {
            var listele = db.Etiketlers.ToList();
            return View(listele);
        }
        [HttpGet]
        public ActionResult EtiketDuzenle(int id)
        {
            var etiket = db.Etiketlers.Where(i => i.Eid == id).SingleOrDefault();
            if (etiket.Eid == id)
                return View();

            return HttpNotFound();
        }
        [HttpPost]
        public ActionResult EtiketDuzenle(int id,Etiketler model)
        {
            try
            {
                var etiket = db.Etiketlers.Where(i => i.Eid == id).SingleOrDefault();
                etiket.EtiketAdi = model.EtiketAdi;
                db.SaveChanges();

                return RedirectToAction("EtiketListele");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult EtiketSil(int id)
        {
            var etiket = db.Etiketlers.Where(i => i.Eid == id).SingleOrDefault();
            db.Etiketlers.Remove(etiket);
            db.SaveChanges();
            return RedirectToAction("EtiketListele");
        }
        public ActionResult UyeListele(Uyeler model)
        {
            var listele = db.Uyelers.ToList();
            return View(listele);
        }
        public ActionResult UyeSil(int id)
        {
            var uye = db.Uyelers.Where(i => i.Uid == id).SingleOrDefault();
            db.Uyelers.Remove(uye);
            db.SaveChanges();
            return RedirectToAction("UyeListele");
        }
        public ActionResult Cikis()
        {
            Session["username"] = null;
            return RedirectToAction("AdminGiris", "Home");
        }

    }
}