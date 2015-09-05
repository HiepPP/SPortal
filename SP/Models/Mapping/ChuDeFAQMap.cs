using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SetPortal.Models.Mapping
{
    public class ChuDeFAQMap : EntityTypeConfiguration<ChuDeFAQ>
    {
        public ChuDeFAQMap()
        {
            // Primary Key
            this.HasKey(t => t.MaChuDeFAQ);

            // Properties
            this.Property(t => t.MaChuDeFAQ)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.TenChuDeFAQ)
                .HasMaxLength(100);

            this.Property(t => t.LoaiChuDeFAQ)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("ChuDeFAQ");
            this.Property(t => t.MaChuDeFAQ).HasColumnName("MaChuDeFAQ");
            this.Property(t => t.TenChuDeFAQ).HasColumnName("TenChuDeFAQ");
            this.Property(t => t.LoaiChuDeFAQ).HasColumnName("LoaiChuDeFAQ");
        }
    }
}
