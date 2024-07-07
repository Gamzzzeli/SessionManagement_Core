using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using OturumYonetimi_Core.Models;

namespace OturumYonetimi_Core.Data;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Kullanicilar> Kullanicilars { get; set; }

    public virtual DbSet<Subeler> Subelers { get; set; }

    public virtual DbSet<Urunler> Urunlers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-1829VV2\\SQLEXPRESS;Database=OturumYonetimi_Core_Db;Integrated Security=true;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Kullanicilar>(entity =>
        {
            entity.ToTable("Kullanicilar");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.KullaniciAdi)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Sifre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Subeler>(entity =>
        {
            entity.ToTable("Subeler");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Adres)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.SubeAdi)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Urunler>(entity =>
        {
            entity.ToTable("Urunler");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Fiyat).HasColumnType("smallmoney");
            entity.Property(e => e.UrunAd)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
