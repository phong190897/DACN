//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TracNghiemAPI
{
    using System;
    using System.Collections.Generic;
    
    public partial class BaiThi
    {
        public string MaBaiThi { get; set; }
        public string TaiKhoan { get; set; }
        public string MaDe { get; set; }
        public Nullable<int> ThoiGianHoanThanh { get; set; }
        public string SoCauDung { get; set; }
        public Nullable<int> Diem { get; set; }
        public string CauTraLoi { get; set; }
        public Nullable<System.DateTime> NgayThi { get; set; }
    
        public virtual DeThi DeThi { get; set; }
        public virtual TaiKhoan TaiKhoan1 { get; set; }
    }
}