//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GlassesOnline.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class PHIEUNHAP
    {
        public PHIEUNHAP()
        {
            this.CTPHIEUNHAPs = new HashSet<CTPHIEUNHAP>();
        }
    
        public int MaPhieu { get; set; }
        public System.DateTime NgayNhap { get; set; }
        public int SoLuong { get; set; }
        public double TongTien { get; set; }
    
        public virtual ICollection<CTPHIEUNHAP> CTPHIEUNHAPs { get; set; }
    }
}