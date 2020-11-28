namespace DA_Web.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class QuanLyBanHangDataContext : DbContext
    {
        public QuanLyBanHangDataContext()
            : base("name=QL_BANHANGConnectionString")
        {
        }

        public virtual DbSet<Table_BANSANPHAM> Table_BANSANPHAM { get; set; }
        public virtual DbSet<Table_DONHANG> Table_DONHANG { get; set; }
        public virtual DbSet<Table_DONHANG_DM> Table_DONHANG_DM { get; set; }
        public virtual DbSet<Table_KHACHHANG> Table_KHACHHANG { get; set; }
        public virtual DbSet<Table_LOAINHANVIEN> Table_LOAINHANVIEN { get; set; }
        public virtual DbSet<Table_LOAISANPHAM> Table_LOAISANPHAM { get; set; }
        public virtual DbSet<Table_MUCHINHANH> Table_MUCHINHANH { get; set; }
        public virtual DbSet<Table_NHANVIEN> Table_NHANVIEN { get; set; }
        public virtual DbSet<Table_NHAPKHO> Table_NHAPKHO { get; set; }
        public virtual DbSet<Table_NhaSX> Table_NhaSX { get; set; }
        public virtual DbSet<Table_SANPHAM> Table_SANPHAM { get; set; }
        public virtual DbSet<Table_TUYCHON> Table_TUYCHON { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Table_DONHANG>()
                .HasMany(e => e.Table_BANSANPHAM)
                .WithRequired(e => e.Table_DONHANG)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Table_DONHANG>()
                .HasMany(e => e.Table_DONHANG_DM)
                .WithRequired(e => e.Table_DONHANG)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Table_KHACHHANG>()
                .Property(e => e.SDT)
                .IsUnicode(false);

            modelBuilder.Entity<Table_KHACHHANG>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Table_KHACHHANG>()
                .Property(e => e.Facebook)
                .IsUnicode(false);

            modelBuilder.Entity<Table_KHACHHANG>()
                .Property(e => e.Skype)
                .IsUnicode(false);

            modelBuilder.Entity<Table_KHACHHANG>()
                .Property(e => e.Whatapp)
                .IsUnicode(false);

            modelBuilder.Entity<Table_KHACHHANG>()
                .Property(e => e.Telegram)
                .IsUnicode(false);

            modelBuilder.Entity<Table_LOAISANPHAM>()
                .Property(e => e.TenThuMuc)
                .IsUnicode(false);

            modelBuilder.Entity<Table_LOAISANPHAM>()
                .HasMany(e => e.Table_SANPHAM)
                .WithRequired(e => e.Table_LOAISANPHAM)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Table_MUCHINHANH>()
                .Property(e => e.HINHANH_N)
                .IsUnicode(false);

            modelBuilder.Entity<Table_NHANVIEN>()
                .Property(e => e.Username)
                .IsUnicode(false);

            modelBuilder.Entity<Table_NHANVIEN>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<Table_NHANVIEN>()
                .Property(e => e.SDT)
                .IsUnicode(false);

            modelBuilder.Entity<Table_NHANVIEN>()
                .Property(e => e.TKBank)
                .IsUnicode(false);

            modelBuilder.Entity<Table_NHANVIEN>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Table_NHANVIEN>()
                .Property(e => e.Skype)
                .IsUnicode(false);

            modelBuilder.Entity<Table_NHANVIEN>()
                .Property(e => e.ANHDAIDIEN)
                .IsUnicode(false);

            modelBuilder.Entity<Table_NHANVIEN>()
                .HasMany(e => e.Table_DONHANG)
                .WithOptional(e => e.Table_NHANVIEN)
                .HasForeignKey(e => e.ID_NGUOIBAN);

            modelBuilder.Entity<Table_NHANVIEN>()
                .HasMany(e => e.Table_NHAPKHO)
                .WithRequired(e => e.Table_NHANVIEN)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Table_SANPHAM>()
                .Property(e => e.HINHANH)
                .IsUnicode(false);

            modelBuilder.Entity<Table_SANPHAM>()
                .HasMany(e => e.Table_DONHANG_DM)
                .WithRequired(e => e.Table_SANPHAM)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Table_SANPHAM>()
                .HasMany(e => e.Table_MUCHINHANH)
                .WithRequired(e => e.Table_SANPHAM)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Table_SANPHAM>()
                .HasMany(e => e.Table_NHAPKHO)
                .WithRequired(e => e.Table_SANPHAM)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Table_SANPHAM>()
                .HasMany(e => e.Table_TUYCHON)
                .WithRequired(e => e.Table_SANPHAM)
                .WillCascadeOnDelete(false);
        }
    }
}
