using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GlassesOnline.Models;

namespace GlassesOnline.Controllers
{
    public class GioHangController : Controller
    {
        public List<GioHang> LayGioHang()
        {
            List<GioHang> lstSanPham = Session["GioHang"] as List<GioHang>;
            if(lstSanPham == null)
            {
                lstSanPham = new List<GioHang>();
                Session["GioHang"] = lstSanPham;
            }
            return lstSanPham; 
        }
        // GET: GioHang
        DBGNamCuongEntities db = new DBGNamCuongEntities();
        public ActionResult ViewGiohang()
        {
            List<GioHang> lstGioHang = LayGioHang();

            return View(lstGioHang);
        }
        [HttpPost]
        public ActionResult ThemGioHang(int _MaSP,int? SL)
        {
            List<GioHang> lisSP = LayGioHang();
            GioHang SPTrongGioHang = lisSP.Find(n => n.MaSP == _MaSP);
            if (SPTrongGioHang == null)
            {
                SPTrongGioHang = new GioHang();
                SANPHAMGLA SPTrongdb = db.SANPHAMGLAS.Single(n => n.MaSP == _MaSP);
                SPTrongGioHang.MaSP = SPTrongdb.MaSP;
                SPTrongGioHang.TenSP = SPTrongdb.TenSP;
                SPTrongGioHang.DonGiaSP = double.Parse(SPTrongdb.DonGia.ToString());
                SPTrongGioHang.AnhSP = SPTrongdb.HinhMinhHoa;
                if(SL == null)
                {
                    SPTrongGioHang.SoLuongSP = 1;
                }
                else
                {
                    SPTrongGioHang.SoLuongSP = SL;
                }
                lisSP.Add(SPTrongGioHang);
                Session["GioHang"] = lisSP;
                return Json(lisSP, JsonRequestBehavior.AllowGet);

            }
            else
            {
                if(SL == 1)
                {
                    SPTrongGioHang.SoLuongSP++;
                }
                else
                {
                    SPTrongGioHang.SoLuongSP = int.Parse(SL.ToString());
                }
                Session["GioHang"] = lisSP;
                return Json(lisSP, JsonRequestBehavior.AllowGet);
            }
        }

    }
}