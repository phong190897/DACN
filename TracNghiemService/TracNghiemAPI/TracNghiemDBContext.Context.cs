﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class TracNghiemDataModel : DbContext
    {
        public TracNghiemDataModel()
            : base("name=TracNghiemDataModel")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<BaiThi> BaiThis { get; set; }
        public virtual DbSet<CauHoi> CauHois { get; set; }
        public virtual DbSet<DeThi> DeThis { get; set; }
        public virtual DbSet<LoaiCauHoi> LoaiCauHois { get; set; }
        public virtual DbSet<MonThi> MonThis { get; set; }
        public virtual DbSet<Quyen> Quyens { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<TaiKhoan> TaiKhoans { get; set; }
    }
}
