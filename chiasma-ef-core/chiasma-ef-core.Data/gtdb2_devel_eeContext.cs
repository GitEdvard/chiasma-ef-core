using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace chiasma_ef_core.Data
{
    public partial class gtdb2_devel_eeContext : DbContext
    {
        public gtdb2_devel_eeContext()
        {
        }

        public gtdb2_devel_eeContext(DbContextOptions<gtdb2_devel_eeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Plate> Plate { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("data source=130.238.178.226;integrated security=true;initial catalog=gtdb2_devel_ee;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Plate>(entity =>
            {
                entity.ToTable("plate");

                entity.HasIndex(e => e.Identifier)
                    .HasName("plate_UQ")
                    .IsUnique();

                entity.Property(e => e.PlateId)
                    .HasColumnName("plate_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.BeadChipInfoId).HasColumnName("bead_chip_info_id");

                entity.Property(e => e.Comment)
                    .HasColumnName("comment")
                    .HasMaxLength(1024)
                    .IsUnicode(false);

                entity.Property(e => e.Identifier)
                    .IsRequired()
                    .HasColumnName("identifier")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Method)
                    .IsRequired()
                    .HasColumnName("method")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.PlateNumber).HasColumnName("plate_number");

                entity.Property(e => e.PlateTypeId).HasColumnName("plate_type_id");

                entity.Property(e => e.PlateUsage)
                    .IsRequired()
                    .HasColumnName("plate_usage")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.SampleSeriesId).HasColumnName("sample_series_id");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasColumnName("status")
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('Active')");

                entity.Property(e => e.TestColumn).HasColumnName("test_column");
            });
        }
    }
}
