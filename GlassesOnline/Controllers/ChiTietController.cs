using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GlassesOnline.Models;
using System.Web.Helpers;
using System.Web.Script.Serialization;

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
            SANPHAMGLA SanPhamHienTaiTrongTrangChiTiet = db.SANPHAMGLAS.SingleOrDefault(n => n.MaSP == _MaSP);
            List<SANPHAMGLA> SPLienQuan = db.SANPHAMGLAS.Where(n => n.MaLoai == SanPhamHienTaiTrongTrangChiTiet.MaLoai).Take(4).ToList();
            ViewData["listSanPhamLienQuan"] = SPLienQuan;
            try
            {
                ViewData["DanhGia"] = db.HamLayBangDanhGia().Single(n => n.MaSP == _MaSP);
            }
            catch
            {
                ViewData["DanhGia"] = null;
            }
            return View(db.SANPHAMGLAS.SingleOrDefault(n => n.MaSP == _MaSP));
        }
        [HttpPost]
        public ActionResult XuLyBinhLuan(string DanhGia, string SoDiemDG,string _MaSP)
        {
            int _MaKH = int.Parse(Session["MaKH"].ToString());
            KHACHHANG kh = db.KHACHHANGs.Single(n => n.MaKH == _MaKH);
            DANHGIASP DG = new DANHGIASP();
            DG.MaKH = kh.MaKH;
            DG.MaSP = int.Parse(_MaSP);
            DG.HoTenKH = kh.HoTenKH;
            DG.DiemDG = int.Parse(SoDiemDG);
            DG.BinhLuan = DanhGia;
            DG.ThoiGian = DateTime.Now;
            DG.TenDN = kh.TenDN;
            db.DANHGIASPs.Add(DG);
            db.SaveChanges();
            return Json(DG.HoTenKH, JsonRequestBehavior.AllowGet);
        }
    }
}