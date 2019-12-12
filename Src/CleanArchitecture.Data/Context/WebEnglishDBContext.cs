using System;
using System.Collections.Generic;
using System.Text;
using CleanArchitecture.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;


namespace CleanArchitecture.Data.Context
{  
    public partial class WebEnglishDBContext : DbContext
    {
        public WebEnglishDBContext(DbContextOptions options) : base(options)
        {

        }

        public virtual DbSet<CthoaDon> CthoaDon { get; set; }
        public virtual DbSet<CtnhapHang> CtnhapHang { get; set; }
        public virtual DbSet<HoaDon> HoaDon { get; set; }
        public virtual DbSet<KhachHang> KhachHang { get; set; }
        public virtual DbSet<NguoiDung> NguoiDung { get; set; }
        public virtual DbSet<NhaCungCap> NhaCungCap { get; set; }
        public virtual DbSet<NhapHang> NhapHang { get; set; }
        public virtual DbSet<Xe> Xe { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=WebDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CthoaDon>(entity =>
            {
                entity.ToTable("CTHoaDon");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.IdhoaDon).HasColumnName("IDHoaDon");

                entity.Property(e => e.Idxe).HasColumnName("IDXe");

                entity.Property(e => e.Soluong).HasColumnName("soluong");

                entity.HasOne(d => d.IdhoaDonNavigation)
                    .WithMany(p => p.CthoaDon)
                    .HasForeignKey(d => d.IdhoaDon)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("CTHoaDon_HoaDon");

                entity.HasOne(d => d.IdxeNavigation)
                    .WithMany(p => p.CthoaDon)
                    .HasForeignKey(d => d.Idxe)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("CTHoaDon_Xe");
            });

            modelBuilder.Entity<CtnhapHang>(entity =>
            {
                entity.ToTable("CTNhapHang");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.IdnhapHang).HasColumnName("IDNhapHang");

                entity.Property(e => e.Idxe).HasColumnName("IDXe");

                entity.Property(e => e.Soluong).HasColumnName("soluong");

                entity.HasOne(d => d.IdnhapHangNavigation)
                    .WithMany(p => p.CtnhapHang)
                    .HasForeignKey(d => d.IdnhapHang)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("CTNhapHang_NhapHang");

                entity.HasOne(d => d.IdxeNavigation)
                    .WithMany(p => p.CtnhapHang)
                    .HasForeignKey(d => d.Idxe)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("CTNhapHang_Xe");
            });

            modelBuilder.Entity<HoaDon>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Gia).HasColumnName("gia");

                entity.Property(e => e.IdkhachHang).HasColumnName("IDKhachHang");

                entity.Property(e => e.IdnguoiDung).HasColumnName("IDNguoiDung");

                entity.Property(e => e.Ngaymua)
                    .HasColumnName("ngaymua")
                    .HasMaxLength(1);

                entity.HasOne(d => d.IdkhachHangNavigation)
                    .WithMany(p => p.HoaDon)
                    .HasForeignKey(d => d.IdkhachHang)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("HoaDon_KhachHang");

                entity.HasOne(d => d.IdnguoiDungNavigation)
                    .WithMany(p => p.HoaDon)
                    .HasForeignKey(d => d.IdnguoiDung)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("HoaDon_NguoiDung");
            });

            modelBuilder.Entity<KhachHang>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Diachi)
                    .HasColumnName("diachi")
                    .HasMaxLength(100);

                entity.Property(e => e.Ngaysinh)
                    .HasColumnName("ngaysinh")
                    .HasMaxLength(10);

                entity.Property(e => e.Sdt)
                    .HasColumnName("sdt")
                    .HasMaxLength(10);

                entity.Property(e => e.Ten)
                    .HasColumnName("ten")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<NguoiDung>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Gmail)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MatKhau)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NgayTao)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.SoDienThoai)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TaiKhoan)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TenNguoiDung).HasMaxLength(100);

                entity.Property(e => e.VaiTro).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<NhaCungCap>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Diachi)
                    .HasColumnName("diachi")
                    .HasMaxLength(100);

                entity.Property(e => e.Sdt)
                    .HasColumnName("sdt")
                    .HasMaxLength(100);

                entity.Property(e => e.Ten)
                    .HasColumnName("ten")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<NhapHang>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Gia).HasColumnName("gia");

                entity.Property(e => e.IdnguoiDung).HasColumnName("IDNguoiDung");

                entity.Property(e => e.Ngaymua)
                    .HasColumnName("ngaymua")
                    .HasMaxLength(1);

                entity.HasOne(d => d.IdnguoiDungNavigation)
                    .WithMany(p => p.NhapHang)
                    .HasForeignKey(d => d.IdnguoiDung)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("NhapHang_NguoiDung");
            });

            modelBuilder.Entity<Xe>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Gia).HasColumnName("gia");

                entity.Property(e => e.Idncc).HasColumnName("IDNCC");

                entity.Property(e => e.Loai)
                    .HasColumnName("loai")
                    .HasMaxLength(100);

                entity.Property(e => e.Soluong).HasColumnName("soluong");

                entity.Property(e => e.Ten)
                    .HasColumnName("ten")
                    .HasMaxLength(100);

                entity.HasOne(d => d.IdnccNavigation)
                    .WithMany(p => p.Xe)
                    .HasForeignKey(d => d.Idncc)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("Xe_NhaCungCap");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
