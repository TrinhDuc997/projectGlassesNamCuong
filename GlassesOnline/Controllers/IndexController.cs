using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GlassesOnline.Models;

namespace GlassesOnline.Controllers
{
    public class IndexController : Controller
    {
        DBGNamCuongEntities db = new DBGNamCuongEntities();
        // GET: Index
        public ActionResult ViewIndex()
        {   
            return View(db.SANPHAMGLAS.ToList());
        }
    }
}