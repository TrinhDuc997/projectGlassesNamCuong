using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GlassesOnline.Models;

namespace GlassesOnline.Controllers
{
    public class PartialViewController : Controller
    {
        DBGNamCuongEntities db = new DBGNamCuongEntities();
        // GET: PartialView
        public ActionResult PatialBuyMore()
        {
            var NhomSanPhamBanChay = from NhomSP in db.CTDONHANGs
                                     group NhomSP by NhomSP.MaSP into GroupNhomSP
                                     select new
                                     {
                                         MaSP1 = GroupNhomSP.Key,
                                         SoLuong = GroupNhomSP.Sum(n=>n.SoLuong)
                                     };
            var SanPhamBanChay = (from sanpham in db.SANPHAMGLAS
                                 join sanpham2 in NhomSanPhamBanChay on sanpham.MaSP equals sanpham2.MaSP1
                                 orderby sanpham2.SoLuong descending
                                 select sanpham);
                                 
            return PartialView(SanPhamBanChay.Take(5).ToList());
        }
    }
}