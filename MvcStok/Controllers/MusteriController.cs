using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entity;
using PagedList;
using PagedList.Mvc;

namespace MvcStok.Controllers
{
    public class MusteriController : Controller
    {
        // GET: Musteri
        DbStokEntities db = new DbStokEntities();
        public ActionResult Index(int sayfa=1)
        {
            var deger = db.TBLMUSTERILER.ToList().ToPagedList(sayfa,4);
            return View(deger);
        }
        [HttpGet]
        public ActionResult MusteriEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult MusteriEkle(TBLMUSTERILER p)
        {
            if (!ModelState.IsValid)
            {
                return View("MusteriEkle");
            }
            db.TBLMUSTERILER.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult MusteriSil(int id)
        {
            var deger = db.TBLMUSTERILER.Find(id);
            db.TBLMUSTERILER.Remove(deger);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult MusteriGetir(int id)
        {
            var musteri = db.TBLMUSTERILER.Find(id);
            return View("MusteriGetir", musteri);
        }
        public ActionResult MusteriGuncelle(TBLMUSTERILER p)
        {
            var musteri = db.TBLMUSTERILER.Find(p.MUSTERIID);
            musteri.MUSTERIID = p.MUSTERIID;
            musteri.MUSTERIAD = p.MUSTERIAD;
            musteri.MUSTERISOYAD = p.MUSTERISOYAD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}