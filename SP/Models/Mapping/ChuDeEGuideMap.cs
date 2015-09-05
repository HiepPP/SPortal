using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SetPortal.Models.Mapping
{
    public class ChuDeEGuideMap : EntityTypeConfiguration<ChuDeEGuide>
    {
        public ChuDeEGuideMap()
        {
            // Primary Key
            this.HasKey(t => t.MaChuDeEguide);

            // Properties
            this.Property(t => t.MaChuDeEguide)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.TenChuDeEguide)
                .HasMaxLength(100);

            this.Property(t => t.LoaiChuDeEguide)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("ChuDeEGuide");
            this.Property(t => t.MaChuDeEguide).HasColumnName("MaChuDeEguide");
            this.Property(t => t.TenChuDeEguide).HasColumnName("TenChuDeEguide");
            this.Property(t => t.LoaiChuDeEguide).HasColumnName("LoaiChuDeEguide");
        }
    }
}
