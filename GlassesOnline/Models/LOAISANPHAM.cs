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
    
    public partial class LOAISANPHAM
    {
        public LOAISANPHAM()
        {
            this.SANPHAMGLAS = new HashSet<SANPHAMGLA>();
        }
    
        public string MaLoai { get; set; }
        public string TenLoai { get; set; }
    
        public virtual ICollection<SANPHAMGLA> SANPHAMGLAS { get; set; }
    }
}