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
    
    public partial class NHACUNGCAP
    {
        public NHACUNGCAP()
        {
            this.CTPHIEUNHAPs = new HashSet<CTPHIEUNHAP>();
        }
    
        public string MaNCC { get; set; }
        public string TenNCC { get; set; }
        public int SDT { get; set; }
        public string Diachi { get; set; }
    
        public virtual ICollection<CTPHIEUNHAP> CTPHIEUNHAPs { get; set; }
    }
}
