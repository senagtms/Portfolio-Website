using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using My_CV.Models.Entity;
using My_CV.Repositories;

namespace My_CV.Controllers
{
    public class YetenekController : Controller
    {
        YetenekRepository repo = new YetenekRepository();
        // GET: Yetenek
        public ActionResult Index()
        {
            var degerler = repo.List();
            return View(degerler);
        }
        public ActionResult YetenekSil(int id)
        {
            TBL_Yetenekler t = repo.Find(x => x.ID == id);
            repo.Tdelete(t);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult YetenekGetir(int id)
        {
            TBL_Yetenekler t = repo.Find(x => x.ID == id);
            return View(t);

        }

        [HttpPost]
        public ActionResult YetenekGetir(TBL_Yetenekler p)
        {
            TBL_Yetenekler t = repo.Find(x => x.ID == p.ID);
            t.Yetenek = p.Yetenek;
            t.Oran = p.Oran;
            repo.TUpdate(t);
            return RedirectToAction("Index");

        }
        [HttpGet]
        public ActionResult YetenekEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YetenekEkle(TBL_Yetenekler p)
        {
            repo.Tadd(p);
            return RedirectToAction("Index");
        }


    }
}