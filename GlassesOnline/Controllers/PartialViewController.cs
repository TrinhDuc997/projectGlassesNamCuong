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
<<<<<<< HEAD
        public ActionResult PatialBuyMore()
        {
=======
        public ActionResult PartialBuyMore()
        {

>>>>>>> fe6b7fdb0d7eb470c7db74bba6f68c0f7267626a
            var NhomSanPhamBanChay = from NhomSP in db.CTDONHANGs
                                     group NhomSP by NhomSP.MaSP into GroupNhomSP
                                     select new
                                     {
                                         MaSP1 = GroupNhomSP.Key,
<<<<<<< HEAD
                                         SoLuong = GroupNhomSP.Sum(n=>n.SoLuong)
                                     };
            var SanPhamBanChay = (from sanpham in db.SANPHAMGLAS
                                 join sanpham2 in NhomSanPhamBanChay on sanpham.MaSP equals sanpham2.MaSP1
                                 orderby sanpham2.SoLuong descending
                                 select sanpham);
                                 
=======
                                         SoLuong = GroupNhomSP.Sum(n => n.SoLuong)
                                     };
            var SanPhamBanChay = (from sanpham in db.SANPHAMGLAS
                                  join sanpham2 in NhomSanPhamBanChay on sanpham.MaSP equals sanpham2.MaSP1
                                  orderby sanpham2.SoLuong descending
                                  select sanpham);

>>>>>>> fe6b7fdb0d7eb470c7db74bba6f68c0f7267626a
            return PartialView(SanPhamBanChay.Take(5).ToList());
        }
    }
}