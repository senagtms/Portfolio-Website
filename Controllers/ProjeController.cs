using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using My_CV.Models.Entity;
using My_CV.Repositories;

namespace My_CV.Controllers
{
    public class ProjeController : Controller
    {
        // GET: Proje
        ProjelerRepository repo = new ProjelerRepository();
        public ActionResult Index()
        {
            var degerler = repo.List();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult ProjeEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ProjeEkle(TBL_Projeler p)
        {
            repo.Tadd(p);
            return RedirectToAction("Index");
        }
        public ActionResult ProjeSil(int id)
        {
            TBL_Projeler t = repo.Find(x => x.ID == id);
            repo.Tdelete(t);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult ProjeGetir(int id)
        {
            TBL_Projeler t = repo.Find(x => x.ID == id);
            return View(t);

        }
        [HttpPost]
        public ActionResult ProjeGetir(TBL_Projeler p)
        {
            TBL_Projeler t = repo.Find(x => x.ID == p.ID);
            t.Baslik1 = p.Baslik1;
            t.Baslik2 = p.Baslik2;
            t.Aciklama1 = p.Aciklama1;
            t.Aciklama2 = p.Aciklama2;
            repo.TUpdate(t);
            return RedirectToAction("Index");

        }
    }
}