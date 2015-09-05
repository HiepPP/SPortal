using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SetPortal.Models.Mapping
{
    public class Question3Map : EntityTypeConfiguration<Question3>
    {
        public Question3Map()
        {
            // Primary Key
            this.HasKey(t => t.IDQuestion3);

            // Properties
            this.Property(t => t.Question31)
                .HasMaxLength(200);

            // Table & Column Mappings
            this.ToTable("Question3");
            this.Property(t => t.IDQuestion3).HasColumnName("IDQuestion3");
            this.Property(t => t.Question31).HasColumnName("Question3");
        }
    }
}
