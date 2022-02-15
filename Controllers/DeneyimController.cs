using My_CV.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using My_CV.Models.Entity;

namespace My_CV.Controllers
{
    public class DeneyimController : Controller
    {
        // GET: Deneyim
        DeneyimrRepository repo = new DeneyimrRepository();
        public ActionResult Index()
        {
            var degerler = repo.List();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult DeneyimEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DeneyimEkle(TBL_Deneyimler p)
        {
            repo.Tadd(p);
            return RedirectToAction("Index");
        }
        public ActionResult DeneyimSil(int id)
        {
            TBL_Deneyimler t = repo.Find(x => x.ID == id);
            repo.Tdelete(t);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult DeneyimGetir(int id)
        {
            TBL_Deneyimler t = repo.Find(x => x.ID == id);
            return View(t);

        }
        [HttpPost]
        public ActionResult DeneyimGetir(TBL_Deneyimler p)
        {
            TBL_Deneyimler t = repo.Find(x => x.ID == p.ID);
            t.Baslik = p.Baslik;
            t.AltBaslik = p.AltBaslik;
            t.Tarih = p.Tarih;
            repo.TUpdate(t);
            t.Aciklama = p.Aciklama;
            repo.TUpdate(t);
            return RedirectToAction("Index");

        }


    }
    
}