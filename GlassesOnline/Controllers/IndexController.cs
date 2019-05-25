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
            ViewData["DanhGia"] = db.HamLayBangDanhGia().ToList();
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
            int KhoangGia =int.Parse(frmLoc["KhoangGia"].ToString());
            string KieuDang = frmLoc["KieuDang"].ToString();
            string ThuongHieu = frmLoc["ThuongHieu"].ToString();

            if (KieuDang == "All")
                KieuDang = "";
            if(ThuongHieu == "All")
                ThuongHieu = "";
            var DanhSachSPDaLoc = from SP in db.SANPHAMGLAS
                                  where SP.GioiTinh == GioiTinh
                                  select SP;
            if (KhoangGia == 0)
            {
                 DanhSachSPDaLoc = from SP in db.SANPHAMGLAS
                                      where SP.GioiTinh == GioiTinh
                                      && SP.KieuDang.StartsWith(KieuDang)
                                      && SP.HangSanXuat.StartsWith(ThuongHieu)
                                  select SP;
            }
            else if(KhoangGia == 200)
            {
                 DanhSachSPDaLoc = from SP in db.SANPHAMGLAS
                                      where SP.GioiTinh == GioiTinh
                                      && SP.KieuDang.StartsWith(KieuDang)
                                      && SP.HangSanXuat.StartsWith(ThuongHieu)
                                      && SP.DonGia < 200000
                                  select SP;
            }
            else if(KhoangGia == 500)
            {
                 DanhSachSPDaLoc = from SP in db.SANPHAMGLAS
                                      where SP.GioiTinh == GioiTinh
                                      && SP.KieuDang.StartsWith( KieuDang)
                                      && SP.HangSanXuat.StartsWith( ThuongHieu)
                                      && SP.DonGia >= 200000 && SP.DonGia < 500000
                                  select SP;
            }
            else if (KhoangGia == 1000)
            {
                 DanhSachSPDaLoc = from SP in db.SANPHAMGLAS
                                      where SP.GioiTinh == GioiTinh
                                      && SP.KieuDang.StartsWith(KieuDang)
                                      && SP.HangSanXuat.StartsWith( ThuongHieu)
                                      && SP.DonGia >= 500000 && SP.DonGia < 1000000
                                      select SP;
            }
            else
            {
                     DanhSachSPDaLoc = from SP in db.SANPHAMGLAS
                                          where SP.GioiTinh == GioiTinh
                                          && SP.KieuDang.StartsWith(KieuDang)
                                          && SP.HangSanXuat.StartsWith(ThuongHieu)
                                          && SP.DonGia >= 1000000
                                          select SP;
            }
            return View(DanhSachSPDaLoc.ToList());

        }
    }
}