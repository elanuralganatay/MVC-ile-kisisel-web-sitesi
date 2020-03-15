using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using elanora.Models;
namespace elanora.Controllers
{
    public class KullaniciController : YetkiController
    {
        elanoraDb db = new elanoraDb();

        // GET: Kullanici
        public ActionResult Index()
        {
            return View();
        }

        // GET: Kullanici/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult Profile()
        {
            string uyeadi = Session["username"].ToString();
            var kisi = db.Uyelers.Where(i => i.Uadi == uyeadi).SingleOrDefault();
            return View(kisi);
        }

       
        public ActionResult LogOut()
        {
            Session["username"] = null;
            return RedirectToAction("Index", "Home");
        }

        // GET: Kullanici/Edit/5
        public ActionResult Edit(int id)
        {
            string uyeadi = Session["username"].ToString();
            var kisiadi = db.Uyelers.Where(i => i.Uadi == uyeadi).SingleOrDefault();
            var kisiid = db.Uyelers.Where(i => i.Uid == id).SingleOrDefault();

            if (kisiadi.Uid==id)
                return View(kisiid);

            return HttpNotFound();
        }

        // POST: Kullanici/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Uyeler model)
        {
            try
            {
                var kisi = db.Uyelers.Where(i => i.Uid == id).SingleOrDefault();
                kisi.UAd = model.UAd;
                kisi.USoyad = model.USoyad;
                kisi.Sifre = model.Sifre;
                db.SaveChanges();

                return RedirectToAction("Profile");
            }
            catch
            {
                return View();
            }
        }

        // GET: Kullanici/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Kullanici/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
