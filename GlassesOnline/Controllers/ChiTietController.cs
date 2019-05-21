using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GlassesOnline.Models;

namespace GlassesOnline.Controllers
{
    public class ChiTietController : Controller
    {
        // GET: ChiTiet
        DBGNamCuongEntities db = new DBGNamCuongEntities();
        public ActionResult viewchitiet(int _MaSP)
        {
            List<DANHGIASP> DanhGia = db.DANHGIASPs.Where(n => n.MaSP == _MaSP).OrderByDescending(n=>n.MaDG).ToList();
            ViewData["listDanhGia"] = DanhGia;
            return View(db.SANPHAMGLAS.SingleOrDefault(n => n.MaSP == _MaSP));
        }
    }
}