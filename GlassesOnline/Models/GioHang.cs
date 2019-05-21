using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GlassesOnline.Models;

namespace GlassesOnline.Models
{
    public class GioHang
    {
        public int MaSP { get; set; }
        public string TenSP { get; set; }
        public double DonGiaSP { get; set; }
        public string MoTa { get; set; }
        public string AnhSP { get; set; }
        public DateTime Ngay { get; set; }
        public int? SoLuongSP { get; set; }
        public double? TongTien {
            get { return SoLuongSP * DonGiaSP; }
        }
    }
}