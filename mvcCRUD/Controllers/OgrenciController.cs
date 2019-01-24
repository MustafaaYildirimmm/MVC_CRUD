using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvcCRUD.Models;

namespace mvcCRUD.Controllers
{
    public class OgrenciController : Controller
    {
        // GET: Ogrenci

        OkulDb db = new OkulDb();
        public ActionResult List()
        {
            var ogrenciler = db.Ogrenci.ToList();
            return View(ogrenciler);
        }
        public ActionResult YeniOlustur()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Ekle(Ogrenci ogrenci)
        {
            Ogrenci yeni = new Ogrenci();
            yeni.Name = ogrenci.Name;
            yeni.Surname = ogrenci.Surname;
            yeni.Age = ogrenci.Age;
            yeni.Grade = ogrenci.Grade;

            db.Ogrenci.Add(yeni);
            db.SaveChanges();
            return RedirectToAction("List");
        }
        public ActionResult Sil(int id)
        {
            Ogrenci silinecek = db.Ogrenci.Find(id);
            db.Ogrenci.Remove(silinecek);
            db.SaveChanges();
            return RedirectToAction("List");
        }
        public ActionResult Duzenle(int id)
        {
            Ogrenci duzenlenecek = db.Ogrenci.Find(id);
            return View(duzenlenecek);
        }
        public ActionResult Guncelle(Ogrenci duzenlenen)
        {
            Ogrenci ogrenci = db.Ogrenci.Find(duzenlenen.ID);
            ogrenci.Name = duzenlenen.Name;
            ogrenci.Surname = duzenlenen.Surname;
            ogrenci.Age = duzenlenen.Age;
            ogrenci.Grade = duzenlenen.Grade;
            db.SaveChanges();
            return RedirectToAction("List");
        }
    }
}