using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace COVID19.Models
{
    public partial class COVID19Context : DbContext
    {
        public COVID19Context()
        {
        }

        public COVID19Context(DbContextOptions<COVID19Context> options)
            : base(options)
        {
        }

        public virtual DbSet<CityMaster> CityMaster { get; set; }
        public virtual DbSet<CountryMaster> CountryMaster { get; set; }
        public virtual DbSet<InfectionMaster> InfectionMaster { get; set; }
        public virtual DbSet<vInfectionMaster> vInfectionMaster { get; set; }
        public virtual DbSet<StateMaster> StateMaster { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseNpgsql("Server=localhost;Database=COVID19;Port=5432;User Name=postgres;Password=postgres;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<vInfectionMaster>(Query =>
            {
                Query.HasNoKey();
                Query.ToView("vInfectionMaster","Common");
            });
            modelBuilder.Entity<CityMaster>(entity =>
            {
                entity.HasKey(e => e.CityMasterAutoId)
                    .HasName("CityMaster_pkey");

                entity.ToTable("CityMaster", "Global");

                entity.Property(e => e.CityName)
                    .IsRequired()
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<CountryMaster>(entity =>
            {
                entity.HasKey(e => e.CountryMasterAutoId)
                    .HasName("CountryMaster_pkey");

                entity.ToTable("CountryMaster", "Global");

                entity.Property(e => e.CountryName)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.Isocode)
                    .IsRequired()
                    .HasColumnName("ISOCode")
                    .HasMaxLength(3);
            });

            modelBuilder.Entity<InfectionMaster>(entity =>
            {
                entity.HasKey(e => e.InfectionMasterAutoId)
                    .HasName("InfectionMaster_pkey");

                entity.ToTable("InfectionMaster", "Common");

                entity.Property(e => e.ActiveStatus).HasDefaultValueSql("true");

                entity.Property(e => e.AreaType)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.HasOne(d => d.CityMasterAuto)
                    .WithMany(p => p.InfectionMaster)
                    .HasForeignKey(d => d.CityMasterAutoId)
                    .HasConstraintName("InfectionMaster_CityMasterAutoId_fkey");

                entity.HasOne(d => d.CountryMasterAuto)
                    .WithMany(p => p.InfectionMaster)
                    .HasForeignKey(d => d.CountryMasterAutoId)
                    .HasConstraintName("InfectionMaster_CountryMasterAutoId_fkey");

                entity.HasOne(d => d.StateMasterAuto)
                    .WithMany(p => p.InfectionMaster)
                    .HasForeignKey(d => d.StateMasterAutoId)
                    .HasConstraintName("InfectionMaster_StateMasterAutoId_fkey");
            });

            modelBuilder.Entity<StateMaster>(entity =>
            {
                entity.HasKey(e => e.StateMasterAutoId)
                    .HasName("StateMaster_pkey");

                entity.ToTable("StateMaster", "Global");

                entity.Property(e => e.CountryMasterAutoId).HasDefaultValueSql("1");

                entity.Property(e => e.StateName)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.HasOne(d => d.CountryMasterAuto)
                    .WithMany(p => p.StateMaster)
                    .HasForeignKey(d => d.CountryMasterAutoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("StateMaster_CountryMasterAutoId_fkey");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
