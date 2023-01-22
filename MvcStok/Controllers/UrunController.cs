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
    public class UrunController : Controller
    {
        // GET: Urunler
        DbStokEntities db = new DbStokEntities();
        public ActionResult Index(int sayfa = 1)
        {
            var deger = db.TBLURUNLER.ToList().ToPagedList(sayfa,4);
            return View(deger);
        }
        [HttpGet]
        public ActionResult UrunEkle()
        {
            List<SelectListItem> degerler = (from x in db.TBLKATEGORILER.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.KATEGORIAD,
                                                 Value = x.KATEGORIID.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;
            return View();
        }
        [HttpPost]
        public ActionResult UrunEkle(TBLURUNLER p )
        {
            var ktg = db.TBLKATEGORILER.Where(x => x.KATEGORIID == p.TBLKATEGORILER.KATEGORIID).FirstOrDefault();
            p.TBLKATEGORILER = ktg;
            db.TBLURUNLER.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunSil(int id)
        {
            var deger = db.TBLURUNLER.Find(id);
            db.TBLURUNLER.Remove(deger);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunGetir(int id)
        {
            var urun = db.TBLURUNLER.Find(id);
            List<SelectListItem> degerler = (from i in db.TBLKATEGORILER.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KATEGORIAD,
                                                 Value = i.KATEGORIID.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;
            return View("UrunGetir", urun);
        }
        public ActionResult UrunGuncelle(TBLURUNLER p )
        {
            var urun = db.TBLURUNLER.Find(p.URUNID);
            urun.URUNID = p.URUNID;
            urun.URUNAD = p.URUNAD;
            urun.MARKA = p.MARKA;
            urun.STOK = p.STOK;
            urun.FIYAT = p.FIYAT;
            var ktg = db.TBLKATEGORILER.Where(x => x.KATEGORIID == p.TBLKATEGORILER.KATEGORIID).FirstOrDefault();
            urun.URUNKATEGORI = ktg.KATEGORIID;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}