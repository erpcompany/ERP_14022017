﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ERP.Web.Models.Database
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class HOPLONG_DATABASEEntities : DbContext
    {
        public HOPLONG_DATABASEEntities()
            : base("name=HOPLONG_DATABASEEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<CCTC_CONG_TY> CCTC_CONG_TY { get; set; }
        public DbSet<CCTC_MO_HINH_CONG_TY> CCTC_MO_HINH_CONG_TY { get; set; }
        public DbSet<CCTC_NHAN_VIEN> CCTC_NHAN_VIEN { get; set; }
        public DbSet<CCTC_PHONG_BAN> CCTC_PHONG_BAN { get; set; }
        public DbSet<CN_CHI_TIET_NGHIEP_VU> CN_CHI_TIET_NGHIEP_VU { get; set; }
        public DbSet<CN_NGHIEP_VU> CN_NGHIEP_VU { get; set; }
        public DbSet<CN_NGHIEP_VU_NHAN_VIEN> CN_NGHIEP_VU_NHAN_VIEN { get; set; }
        public DbSet<CN_NHOM_NGHIEP_VU> CN_NHOM_NGHIEP_VU { get; set; }
        public DbSet<CN_NHOM_NGUOI_DUNG_NGHIEP_VU> CN_NHOM_NGUOI_DUNG_NGHIEP_VU { get; set; }
        public DbSet<DM_HANG_HOA> DM_HANG_HOA { get; set; }
        public DbSet<DM_HANG_SP> DM_HANG_SP { get; set; }
        public DbSet<DM_HANG_TON_KHO> DM_HANG_TON_KHO { get; set; }
        public DbSet<DM_KHO> DM_KHO { get; set; }
        public DbSet<DM_TAI_KHOAN_HACH_TOAN> DM_TAI_KHOAN_HACH_TOAN { get; set; }
        public DbSet<DM_TONKHO_HANG> DM_TONKHO_HANG { get; set; }
        public DbSet<HT_NGUOI_DUNG> HT_NGUOI_DUNG { get; set; }
    }
}
