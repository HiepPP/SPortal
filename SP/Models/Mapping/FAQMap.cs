using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SetPortal.Models.Mapping
{
    public class FAQMap : EntityTypeConfiguration<FAQ>
    {
        public FAQMap()
        {
            // Primary Key
            this.HasKey(t => t.FaqID);

            // Properties
            this.Property(t => t.MaChuDeFAQ)
                .HasMaxLength(50);

            this.Property(t => t.FileName)
                .HasMaxLength(300);

            // Table & Column Mappings
            this.ToTable("FAQ");
            this.Property(t => t.FaqID).HasColumnName("FaqID");
            this.Property(t => t.Question).HasColumnName("Question");
            this.Property(t => t.Answer).HasColumnName("Answer");
            this.Property(t => t.MaChuDeFAQ).HasColumnName("MaChuDeFAQ");
            this.Property(t => t.FileName).HasColumnName("FileName");

            // Relationships
            this.HasOptional(t => t.ChuDeFAQ)
                .WithMany(t => t.FAQs)
                .HasForeignKey(d => d.MaChuDeFAQ);

        }
    }
}
