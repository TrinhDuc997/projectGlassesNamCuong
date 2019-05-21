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
        public ActionResult ViewMatKinh(int nhomSP)
        {
            var DanhSachKinh = from kinh in db.SANPHAMGLAS
                               select kinh;
            if (nhomSP == 1)
            {
                DanhSachKinh = from kinh in db.SANPHAMGLAS
                                   where kinh.MaLoai == "KC" || kinh.MaLoai == "KMNU" || kinh.MaLoai == "KMN"
                                   select kinh;
            }
            else if(nhomSP == 2)
            {
                DanhSachKinh = from kinh in db.SANPHAMGLAS
                                   where kinh.MaLoai == "GKC" || kinh.MaLoai == "GKM"
                               select kinh;
            }
            return View(DanhSachKinh.ToList());
        }
        [HttpPost]
        public ActionResult ViewTheoDieuKien(FormCollection frmLoc)
        {
            bool GioiTinh = bool.Parse(frmLoc["GioiTinh"].ToString());
            string KhoangGia = frmLoc["KhoangGia"].ToString();
            string KieuDang = frmLoc["KieuDang"].ToString();
            string ThuongHieu = frmLoc["ThuongHieu"].ToString();
            if(KhoangGia == "All")
                KhoangGia = "%";
            if(KieuDang == "All")
                KieuDang = "%";
            if(ThuongHieu == "All")
                ThuongHieu = "%";
            SANPHAMGLA a = db.SANPHAMGLAS.SingleOrDefault(n => n.DonGia == 280000);
            return View();

        }
    }
}