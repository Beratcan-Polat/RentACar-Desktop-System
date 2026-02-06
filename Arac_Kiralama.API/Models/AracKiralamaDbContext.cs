using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Arac_Kiralama.API.Models;

public partial class AracKiralamaDbContext : DbContext
{
    public AracKiralamaDbContext()
    {
    }

    public AracKiralamaDbContext(DbContextOptions<AracKiralamaDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Arac> Arac { get; set; }

    public virtual DbSet<Musteri> Musteri { get; set; }

    public virtual DbSet<Sozlesme> Sozlesme { get; set; }
    public virtual DbSet<Satis> Satis { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=BERATCAN\\SQLEXPRESS;Database=Arac_KiralamaDB;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Arac>(entity =>
        {
            entity.HasKey(e => e.Plaka);
            entity.ToTable("arac");

            entity.Property(e => e.Durumu)
                .HasMaxLength(50)
                .HasColumnName("durumu");
            entity.Property(e => e.KiraUcreti).HasColumnName("kiraUcreti");
            entity.Property(e => e.Km)
                .HasMaxLength(50)
                .HasColumnName("km");
            entity.Property(e => e.Marka)
                .HasMaxLength(50)
                .HasColumnName("marka");
            entity.Property(e => e.ModelAdi)
                .HasMaxLength(50)
                .HasColumnName("modelAdi");
            entity.Property(e => e.ModelYili)
                .HasMaxLength(50)
                .HasColumnName("modelYili");
            entity.Property(e => e.Plaka)
                .HasMaxLength(50)
                .HasColumnName("plaka");
            entity.Property(e => e.Renk)
                .HasMaxLength(50)
                .HasColumnName("renk");
            entity.Property(e => e.Resim)
                .HasMaxLength(150)
                .HasColumnName("resim");
            entity.Property(e => e.Tarih)
                .HasMaxLength(50)
                .HasColumnName("tarih");
            entity.Property(e => e.Vites)
                .HasMaxLength(50)
                .HasColumnName("vites");
            entity.Property(e => e.Yakit)
                .HasMaxLength(50)
                .HasColumnName("yakit");
        });

        modelBuilder.Entity<Musteri>(entity =>
        {
            entity.HasKey(e => e.Tc);
            entity.ToTable("musteri");

            entity.Property(e => e.Tc)
                .HasMaxLength(11)
                .HasColumnName("tc");
            entity.Property(e => e.AdSoyad)
                .HasMaxLength(50)
                .HasColumnName("adSoyad");
            entity.Property(e => e.Adres)
                .HasMaxLength(50)
                .HasColumnName("adres");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");
            entity.Property(e => e.Telefon)
                .HasMaxLength(50)
                .HasColumnName("telefon");
        });

        modelBuilder.Entity<Sozlesme>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.ToTable("sozlesme");

            entity.Property(e => e.Id).HasColumnName("id");

            entity.Property(e => e.Adsoyad)
                .HasMaxLength(50)
                .HasColumnName("adsoyad");
            entity.Property(e => e.Ctarih)
                .HasMaxLength(50)
                .HasColumnName("ctarih");
            entity.Property(e => e.Dtarih)
                .HasMaxLength(50)
                .HasColumnName("dtarih");
            entity.Property(e => e.ETarih)
                .HasMaxLength(50)
                .HasColumnName("e_tarih");
            entity.Property(e => e.Ehliyetno)
                .HasMaxLength(50)
                .HasColumnName("ehliyetno");
            entity.Property(e => e.Gun).HasColumnName("gun");
            entity.Property(e => e.Kirasekli)
                .HasMaxLength(50)
                .HasColumnName("kirasekli");
            entity.Property(e => e.Kiraucreti).HasColumnName("kiraucreti");
            entity.Property(e => e.Marka)
                .HasMaxLength(50)
                .HasColumnName("marka");
            entity.Property(e => e.Modeladi)
                .HasMaxLength(50)
                .HasColumnName("modeladi");
            entity.Property(e => e.Modelyili)
                .HasMaxLength(50)
                .HasColumnName("modelyili");
            entity.Property(e => e.Plaka)
                .HasMaxLength(50)
                .HasColumnName("plaka");
            entity.Property(e => e.Renk)
                .HasMaxLength(50)
                .HasColumnName("renk");
            entity.Property(e => e.Tc)
                .HasMaxLength(50)
                .HasColumnName("tc");
            entity.Property(e => e.Telefon)
                .HasMaxLength(50)
                .HasColumnName("telefon");
            entity.Property(e => e.Tutar).HasColumnName("tutar");
        });

        modelBuilder.Entity<Satis>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.ToTable("satis");

            entity.Property(e => e.Id).HasColumnName("id");

            entity.Property(e => e.Adsoyad)
                .HasMaxLength(50)
                .HasColumnName("adsoyad");
            entity.Property(e => e.Ctarih)
                .HasMaxLength(50)
                .HasColumnName("ctarih");
            entity.Property(e => e.Dtarih)
                .HasMaxLength(50)
                .HasColumnName("dtarih");
            entity.Property(e => e.ETarih)
                .HasMaxLength(50)
                .HasColumnName("e_tarih");
            entity.Property(e => e.Ehliyetno)
                .HasMaxLength(50)
                .HasColumnName("ehliyetno");
            entity.Property(e => e.Gun).HasColumnName("gun");
            entity.Property(e => e.Kirasekli)
                .HasMaxLength(50)
                .HasColumnName("kirasekli");
            entity.Property(e => e.Kiraucreti).HasColumnName("kiraucreti");
            entity.Property(e => e.Marka)
                .HasMaxLength(50)
                .HasColumnName("marka");
            entity.Property(e => e.Modeladi)
                .HasMaxLength(50)
                .HasColumnName("modeladi");
            entity.Property(e => e.Modelyili)
                .HasMaxLength(50)
                .HasColumnName("modelyili");
            entity.Property(e => e.Plaka)
                .HasMaxLength(50)
                .HasColumnName("plaka");
            entity.Property(e => e.Renk)
                .HasMaxLength(50)
                .HasColumnName("renk");
            entity.Property(e => e.Tc)
                .HasMaxLength(50)
                .HasColumnName("tc");
            entity.Property(e => e.Telefon)
                .HasMaxLength(50)
                .HasColumnName("telefon");
            entity.Property(e => e.Tutar).HasColumnName("tutar");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
