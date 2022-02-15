using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using My_CV.Models.Entity;

namespace My_CV.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        DB_CvEntities2 db = new DB_CvEntities2();
        public ActionResult Index()
        {
            var degerler = db.TBL_Hakkımda.ToList();
            return View(degerler);
        }
        public PartialViewResult Deneyimler()
        {
            var deneyimler = db.TBL_Deneyimler.ToList();
            return PartialView(deneyimler);
        }
        public PartialViewResult Egitim()
        {
            var egitim = db.TBL_Egitim.ToList();
            return PartialView(egitim);
        } 
        public PartialViewResult Yetenekler()
        {
            var yetenek = db.TBL_Yetenekler.ToList();
            return PartialView(yetenek);
        }
        public PartialViewResult Projeler()
        {
            var proje = db.TBL_Projeler.ToList();
            return PartialView(proje);
        }
        public PartialViewResult Hobiler()
        {
            var hobiler = db.TBL_Hobiler.ToList();
            return PartialView(hobiler);
        }
        public PartialViewResult Sertifikalar()
        {
            var sertifika = db.TBL_Sertifika.ToList();
            return PartialView(sertifika);
        } 
       [HttpGet]
        public PartialViewResult Iletisim()
        {
            var iletisim = db.TBL_Iletisim.ToList();
            return PartialView(iletisim);
        }
        [HttpPost]
        public PartialViewResult Iletisim(TBL_Iletisim t)
        {
            t.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            db.TBL_Iletisim.Add(t);
            db.SaveChanges();
            return PartialView();
        }
    }
}