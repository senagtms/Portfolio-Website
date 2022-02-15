using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using My_CV.Repositories;
using System.Web.Mvc;
using My_CV.Models.Entity;

namespace My_CV.Controllers
{
    public class EgitimController : Controller
    {
        EgitimRepository repo = new EgitimRepository();
        // GET: Egitim
        public ActionResult Index()
        {
            var degerler = repo.List();
            return View(degerler);
        }
        public ActionResult EgitimSil(int id)
        {
            TBL_Egitim t = repo.Find(x => x.ID == id);
            repo.Tdelete(t);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EgitimGetir(int id)
        {
            TBL_Egitim t = repo.Find(x => x.ID == id);
            return View(t);

        }
        [HttpPost]
        public ActionResult EgitimGetir(TBL_Egitim p)
        {
            TBL_Egitim t = repo.Find(x => x.ID == p.ID);
            t.Baslik = p.Baslik;
            t.AltBaslik = p.AltBaslik;
            t.AltBaslik2 = p.AltBaslik2;
            t.GNO = p.GNO;
            t.Tarih = p.Tarih;
            repo.TUpdate(t);
            return RedirectToAction("Index");

        }
        [HttpGet]
        public ActionResult EgitimEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult EgitimEkle(TBL_Egitim p)
        {
            if (!ModelState.IsValid)
            {
                return View("EgitimEkle");
            }
            repo.Tadd(p);
            return RedirectToAction("Index");
        }
    }
}