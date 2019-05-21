using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GlassesOnline.Models;
using System.Data.SqlClient;
using System.Globalization;

namespace GlassesOnline.Controllers
{
    public class DKDNController : Controller
    {
        DBGNamCuongEntities db = new DBGNamCuongEntities();
        // GET: DKDN
        public ActionResult ViewDangNhap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangNhap(FormCollection frmDN)
        {
            string sTaiKhoan = frmDN["TaiKhoan"];
            string sMatKhau = frmDN["MatKhau"]; 
            KHACHHANG kh = db.KHACHHANGs.SingleOrDefault(n => n.TenDN == sTaiKhoan && n.MatKhau == sMatKhau);
            //var kh1 = from KHACHHANG in db.KHACHHANGs
            //          where KHACHHANG.TenDN == sTaiKhoan && KHACHHANG.MatKhau == sMatKhau
            //          select KHACHHANG;
            //int mkh = 0;
            //foreach(var item in kh1)
            //{
            //    mkh = item.;
            //}
            if(kh != null)
            {
                Session["MaKH"] = kh.MaKH;
                Session["TenKH"] = kh.HoTenKH;
                return RedirectToAction("ViewIndex", "Index");
            }
            return RedirectToAction("ViewDangNhap", "DKDN");
        }
<<<<<<< HEAD
        public ActionResult ViewDangKy()
=======
        public ActionResult ViewDangky()
>>>>>>> 4467409f88e304e15610bf00bee193dca6372a1c
        {

            return View();
        }
        [HttpPost]
        public ActionResult ViewDangKy(FormCollection frmDK, KHACHHANG kh)
        {
            kh.HoTenKH = frmDK["name"];
            kh.Email = frmDK["email"];
            kh.DienThoaiKH = int.Parse(frmDK["SoDienThoai"]);
            kh.DiaChiKH = frmDK["DiaChi"];
            kh.TenDN = frmDK["TenDangNhap"];
            kh.MatKhau = frmDK["MatKhau"];
            kh.GioiTinh = Boolean.Parse(frmDK["GioiTinh"]);
            string NgaySinh = frmDK["NgaySinh"];
            //var NS = DateTime.Parse(NgaySinh, new CultureInfo("en-US", true));
            DateTime date = DateTime.ParseExact(NgaySinh, "dd/MM/yyyy", null);
            //kh.NgaySinh = DateTime.Parse(Convert.ToDateTime(frmDK["NgaySinh"]).ToString("yyyy-MM-dd"));
            kh.NgaySinh = date;
            db.KHACHHANGs.Add(kh);
            db.SaveChanges();
            return RedirectToAction("ViewDangNhap", "DKDN");
        }
    }
}