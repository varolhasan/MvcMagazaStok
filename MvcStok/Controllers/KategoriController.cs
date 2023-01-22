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
    public class KategoriController : Controller
    {
        // GET: Kategori
        DbStokEntities db = new DbStokEntities();
        public ActionResult Index(int sayfa = 1)
        {
            var degerler = db.TBLKATEGORILER.ToList().ToPagedList(sayfa,4);
            return View(degerler);
        }
        [HttpGet]
        public ActionResult KategoriEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult KategoriEkle(TBLKATEGORILER p)
        {
            if (!ModelState.IsValid)
            {
                return View("KategoriEkle");
            }
            db.TBLKATEGORILER.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KategoriSil(int id)
        {
            var deger = db.TBLKATEGORILER.Find(id);
            db.TBLKATEGORILER.Remove(deger);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KategoriGetir(int id)
        {
            var kategori = db.TBLKATEGORILER.Find(id);
            return View("KategoriGetir", kategori);
        }
        public ActionResult KategoriGuncelle(TBLKATEGORILER p)
        {
            var kategori = db.TBLKATEGORILER.Find(p.KATEGORIID);
            kategori.KATEGORIID = p.KATEGORIID;
            kategori.KATEGORIAD = p.KATEGORIAD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}