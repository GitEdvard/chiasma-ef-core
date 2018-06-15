using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace chiasma_ef_core.Data.PlateWithPrincipals
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

        public virtual DbSet<BeadChipInfo> BeadChipInfo { get; set; }
        public virtual DbSet<BeadChipType> BeadChipType { get; set; }
        public virtual DbSet<Contact> Contact { get; set; }
        public virtual DbSet<Plate> Plate { get; set; }
        public virtual DbSet<PlateType> PlateType { get; set; }
        public virtual DbSet<SampleSeries> SampleSeries { get; set; }

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
            modelBuilder.Entity<BeadChipInfo>(entity =>
            {
                entity.ToTable("bead_chip_info");

                entity.Property(e => e.BeadChipInfoId).HasColumnName("bead_chip_info_id");

                entity.Property(e => e.BatchSize).HasColumnName("batch_size");

                entity.Property(e => e.DefaultBeadChipTypeId).HasColumnName("default_bead_chip_type_id");

                entity.Property(e => e.MultipleBatches).HasColumnName("multiple_batches");

                entity.Property(e => e.NCompletedBatches).HasColumnName("n_completed_batches");

                entity.Property(e => e.PlateId).HasColumnName("plate_id");

                entity.HasOne(d => d.DefaultBeadChipType)
                    .WithMany(p => p.BeadChipInfo)
                    .HasForeignKey(d => d.DefaultBeadChipTypeId)
                    .HasConstraintName("bead_chip_info_default_bead_chip_type_id_FK");

                entity.HasOne(d => d.Plate)
                    .WithMany(p => p.BeadChipInfo)
                    .HasForeignKey(d => d.PlateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("bead_chip_info_plate_FK");
            });

            modelBuilder.Entity<BeadChipType>(entity =>
            {
                entity.ToTable("bead_chip_type");

                entity.HasIndex(e => e.Identifier)
                    .HasName("bead_chip_type_UQ")
                    .IsUnique();

                entity.Property(e => e.BeadChipTypeId).HasColumnName("bead_chip_type_id");

                entity.Property(e => e.Chiptype)
                    .IsRequired()
                    .HasColumnName("chiptype")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.DefaultBatchSize).HasColumnName("default_batch_size");

                entity.Property(e => e.Identifier)
                    .IsRequired()
                    .HasColumnName("identifier")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.SizeX).HasColumnName("size_x");

                entity.Property(e => e.SizeY).HasColumnName("size_y");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasColumnName("status")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Contact>(entity =>
            {
                entity.ToTable("contact");

                entity.HasIndex(e => e.Identifier)
                    .HasName("contact_UQ")
                    .IsUnique();

                entity.Property(e => e.ContactId).HasColumnName("contact_id");

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .HasColumnName("city")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CoName)
                    .HasColumnName("co_name")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Comment)
                    .HasColumnName("comment")
                    .HasMaxLength(2048)
                    .IsUnicode(false);

                entity.Property(e => e.Country)
                    .HasColumnName("country")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Fax)
                    .HasColumnName("fax")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Identifier)
                    .IsRequired()
                    .HasColumnName("identifier")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Phone1)
                    .HasColumnName("phone1")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Phone2)
                    .HasColumnName("phone2")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Zipcode)
                    .HasColumnName("zipcode")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

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

                entity.HasOne(d => d.BeadChipInfoNavigation)
                    .WithMany(p => p.PlateNavigation)
                    .HasForeignKey(d => d.BeadChipInfoId)
                    .HasConstraintName("plate_bead_chip_info_id_FK");

                entity.HasOne(d => d.PlateType)
                    .WithMany(p => p.Plate)
                    .HasForeignKey(d => d.PlateTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("plate_plate_type_FK");

                entity.HasOne(d => d.SampleSeries)
                    .WithMany(p => p.Plate)
                    .HasForeignKey(d => d.SampleSeriesId)
                    .HasConstraintName("plate_sample_series_FK");
            });

            modelBuilder.Entity<PlateType>(entity =>
            {
                entity.ToTable("plate_type");

                entity.HasIndex(e => e.Identifier)
                    .HasName("plate_type_UQ")
                    .IsUnique();

                entity.Property(e => e.PlateTypeId).HasColumnName("plate_type_id");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.Identifier)
                    .IsRequired()
                    .HasColumnName("identifier")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.SizeX).HasColumnName("size_x");

                entity.Property(e => e.SizeY).HasColumnName("size_y");

                entity.Property(e => e.Usage)
                    .HasColumnName("usage")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SampleSeries>(entity =>
            {
                entity.ToTable("sample_series");

                entity.HasIndex(e => e.Identifier)
                    .HasName("UQ__sample_series__63F8CA06")
                    .IsUnique();

                entity.Property(e => e.SampleSeriesId).HasColumnName("sample_series_id");

                entity.Property(e => e.Comment)
                    .HasColumnName("comment")
                    .HasMaxLength(2000)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ContactId).HasColumnName("contact_id");

                entity.Property(e => e.Identifier)
                    .IsRequired()
                    .HasColumnName("identifier")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Contact)
                    .WithMany(p => p.SampleSeries)
                    .HasForeignKey(d => d.ContactId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("sample_series_contact_id_FK");
            });
        }
    }
}
