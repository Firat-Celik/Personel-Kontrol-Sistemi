using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using PersonelKontrol.Domain.Entities.Concrates;
using Microsoft.Extensions.Configuration;

namespace PersonelKontrol.Persistence.Context
{
    public partial class PersonelDbContext : DbContext
    {
        public PersonelDbContext(DbContextOptions options) : base(options)
        {
        }

        public virtual DbSet<Firma> Firmas { get; set; }

        public virtual DbSet<Personel> Personels { get; set; }

        public virtual DbSet<PersonelHareketleri> PersonelHareketleris { get; set; }

        public virtual DbSet<Sube> Subes { get; set; }

       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Firma>(entity =>
            {
                entity.ToTable("Firma");

                entity.Property(e => e.Aciklama).HasMaxLength(150);
                entity.Property(e => e.FirmaAdi).HasMaxLength(150);

                entity.HasOne(d => d.Sube).WithMany(p => p.Firmas)
                    .HasForeignKey(d => d.SubeId)
                    .HasConstraintName("FK_Firma_Sube");
            });

            modelBuilder.Entity<Personel>(entity =>
            {
                entity.ToTable("Personel");

                entity.Property(e => e.Adi).HasMaxLength(50);
                entity.Property(e => e.DuzenlenmeZamani).HasColumnType("datetime");
                entity.Property(e => e.Email).HasMaxLength(100);
                entity.Property(e => e.KimlikNo).HasMaxLength(11);
                entity.Property(e => e.OlusturulmaZamani).HasColumnType("datetime");
                entity.Property(e => e.Soyadi).HasMaxLength(50);
                entity.Property(e => e.Telefon).HasMaxLength(50);
            });

            modelBuilder.Entity<PersonelHareketleri>(entity =>
            {
                entity.ToTable("PersonelHareketleri");

                entity.Property(e => e.CikisSaati).HasColumnType("datetime");
                entity.Property(e => e.DuzenlenmeZamani).HasColumnType("datetime");
                entity.Property(e => e.GirisSaati).HasColumnType("datetime");
                entity.Property(e => e.OlusturulmaZamani).HasColumnType("datetime");
                entity.Property(e => e.Tarih).HasColumnType("datetime");

                entity.HasOne(d => d.Personel).WithMany(p => p.PersonelHareketleris)
                    .HasForeignKey(d => d.PersonelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PersonelHareketleri_Personel");
            });

            modelBuilder.Entity<Sube>(entity =>
            {
                entity.ToTable("Sube");

                entity.Property(e => e.Aciklama).HasMaxLength(150);
                entity.Property(e => e.DuzenlenmeZamani).HasColumnType("datetime");
                entity.Property(e => e.OlusturulmaZamani).HasColumnType("datetime");
                entity.Property(e => e.SubeAdi).HasMaxLength(50);

                entity.HasOne(d => d.Personel).WithMany(p => p.Subes)
                    .HasForeignKey(d => d.PersonelId)
                    .HasConstraintName("FK_Sube_Personel");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
