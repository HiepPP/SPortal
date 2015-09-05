using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SetPortal.Models.Mapping
{
    public class EGuideMap : EntityTypeConfiguration<EGuide>
    {
        public EGuideMap()
        {
            // Primary Key
            this.HasKey(t => t.EGuildID);

            // Properties
            this.Property(t => t.MaChuDeEguide)
                .HasMaxLength(50);

            this.Property(t => t.FileName)
                .HasMaxLength(300);

            // Table & Column Mappings
            this.ToTable("EGuide");
            this.Property(t => t.EGuildID).HasColumnName("EGuildID");
            this.Property(t => t.MaChuDeEguide).HasColumnName("MaChuDeEguide");
            this.Property(t => t.FileName).HasColumnName("FileName");
            this.Property(t => t.Contents).HasColumnName("Contents");

            // Relationships
            this.HasOptional(t => t.ChuDeEGuide)
                .WithMany(t => t.EGuides)
                .HasForeignKey(d => d.MaChuDeEguide);

        }
    }
}
