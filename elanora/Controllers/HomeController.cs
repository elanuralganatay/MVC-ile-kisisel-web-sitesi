using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using elanora.Models;
using System.Web.Mvc;

namespace elanora.Controllers
{
    public class HomeController : Controller
    {
        elanoraDb db = new elanoraDb();
        
        // GET: Home
        public ActionResult Index()
        {
            var listeleme = db.Makalelers.Take(5).ToList();
            return View(listeleme);
        }
        public ActionResult Archive()
        {
            var listeleme = db.Makalelers.ToList();
            return View(listeleme);
        }
        public ActionResult About()
        {
            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }
        // GET: Kullanici/Create
        public ActionResult Create()//kaydol
        {
            return View();
        }

        // POST: Kullanici/Create
        [HttpPost]
        public ActionResult Create(Uyeler model)//kaydol
        {

            try
            {
                var varmi = db.Uyelers.Where(i => i.Uadi == model.Uadi).SingleOrDefault();

                if (varmi != null)
                {
                    return View();
                }
                if (string.IsNullOrEmpty(model.Sifre))
                {
                    return View();
                }
                db.Uyelers.Add(model);
                model.Yetkiid = 1;
                db.SaveChanges();
                Session["username"] = model.Uadi;
                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View();
            }
        }
        [HttpGet]
        public ActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogIn(Uyeler model)
        {

            try
            {
                var varmi = db.Uyelers.Where(i => i.Uadi == model.Uadi).SingleOrDefault();
                if (varmi == null)
                {
                    return View();
                }

                if (varmi.Sifre == model.Sifre)
                {
                    Session["username"] = model.Uadi;
                    Session["userid"] = model.Uid;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return View();
                }

            }
            catch
            {
                return View();
            }
        }
        [HttpGet]
        public ActionResult AdminGiris()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdminGiris(Uyeler model)
        {

            try
            {
                var varmi = db.Uyelers.Where(i => i.Uadi == model.Uadi).SingleOrDefault();
                if (varmi == null)
                {
                    return View();
                }

                if (varmi.Sifre == model.Sifre && varmi.Yetkiid == 2)
                {
                    Session["username"] = model.Uadi;
                    return RedirectToAction("Index", "Admin");
                }
                else
                {
                    return View();
                }

            }
            catch
            {
                return View();
            }
        }
        public ActionResult MakaleDetay(int id)
        {
            var makale = db.Makalelers.Where(i => i.Mid == id).SingleOrDefault();
            return View(makale);
        }
    }
}