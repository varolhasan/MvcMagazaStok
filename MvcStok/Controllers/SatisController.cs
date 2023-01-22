using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entity;

namespace MvcStok.Controllers
{
    public class SatisController : Controller
    {
        // GET: Satis
        DbStokEntities db = new DbStokEntities();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult YeniSatis()
        {
            return View();
        }
        [HttpGet]
        public ActionResult YeniSatis(TBLSATISLAR p)
        {
            var satis = db.TBLSATISLAR.Add(p);
            db.SaveChanges();
            return View("Index");
        }
    }
}