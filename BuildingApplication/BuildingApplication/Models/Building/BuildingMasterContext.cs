using System;
using BuildingApplication.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace BuildingApplication.Models.Building
{
    public partial class BuildingMasterContext : DbContext
    {
        private readonly IConfiguration config;

        public BuildingMasterContext(IConfiguration config)
        {
            this.config = config;

        }

        public BuildingMasterContext(DbContextOptions<BuildingMasterContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Building> Building { get; set; }
        public virtual DbSet<DataField> DataField { get; set; }
        public virtual DbSet<Object> Object { get; set; }
        public virtual DbSet<Reading> Reading { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(config.GetConnectionString("BuildingMaster"));

                //optionsBuilder.UseSqlServer("Data Source=TEST_SERVER;Initial Catalog=Temp_DB;User ID=sa;Password=e0LZ0G*#%B9)G9}P95;Integrated Security=false;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BuildingDTO>().HasNoKey();
            modelBuilder.Entity<Building>(entity =>
            {
                entity.Property(e => e.Location)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<DataField>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Object>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Reading>(entity =>
            {
                

                entity.Property(e => e.Value).HasColumnType("decimal(18, 7)");

                entity.Property(e => e.TimeStamp).HasColumnType("datetime");

                entity.HasOne(d => d.Building)
                    .WithMany(p => p.Reading)
                    .HasForeignKey(d => d.BuildingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Reading_Building");

                entity.HasOne(d => d.DataField)
                    .WithMany(p => p.Reading)
                    .HasForeignKey(d => d.DataFieldId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Reading_DataField");

                entity.HasOne(d => d.Object)
                    .WithMany(p => p.Reading)
                    .HasForeignKey(d => d.ObjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Reading_Object");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
