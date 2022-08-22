using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace PackagesRegistry.Models
{
    public partial class PackagesRegistryContext : DbContext
    {
        public PackagesRegistryContext()
        {
        }

        public PackagesRegistryContext(DbContextOptions<PackagesRegistryContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Driver> Drivers { get; set; }
        public virtual DbSet<PackagesInCustody> PackagesInCustodies { get; set; }
        public virtual DbSet<PackagesRetired> PackagesRetireds { get; set; }
        public virtual DbSet<TransportCompany> TransportCompanies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>(entity =>
            {
                entity.Property(e => e.BirthDate)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Driver>(entity =>
            {
                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Drivers)
                    .HasForeignKey(d => d.CompanyId)
                    .HasConstraintName("FK__Drivers__Company__267ABA7A");
            });

            modelBuilder.Entity<PackagesInCustody>(entity =>
            {
                entity.ToTable("PackagesInCustody");

                entity.Property(e => e.Date)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TrackingId)
                    .HasMaxLength(18)
                    .IsUnicode(false);

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.PackagesInCustodies)
                    .HasForeignKey(d => d.ClientId)
                    .HasConstraintName("FK__PackagesI__Clien__2C3393D0");

                entity.HasOne(d => d.Driver)
                    .WithMany(p => p.PackagesInCustodies)
                    .HasForeignKey(d => d.DriverId)
                    .HasConstraintName("FK__PackagesI__Drive__2B3F6F97");
            });

            modelBuilder.Entity<PackagesRetired>(entity =>
            {
                entity.ToTable("PackagesRetired");

                entity.Property(e => e.Description)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ReiredDate)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.TrackingId)
                    .HasMaxLength(18)
                    .IsUnicode(false);

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.PackagesRetireds)
                    .HasForeignKey(d => d.ClientId)
                    .HasConstraintName("FK__PackagesR__Clien__300424B4");

                entity.HasOne(d => d.Driver)
                    .WithMany(p => p.PackagesRetireds)
                    .HasForeignKey(d => d.DriverId)
                    .HasConstraintName("FK__PackagesR__Drive__2F10007B");
            });

            modelBuilder.Entity<TransportCompany>(entity =>
            {
                entity.Property(e => e.Name)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
