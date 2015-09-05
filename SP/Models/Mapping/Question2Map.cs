using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SetPortal.Models.Mapping
{
    public class Question2Map : EntityTypeConfiguration<Question2>
    {
        public Question2Map()
        {
            // Primary Key
            this.HasKey(t => t.IDQuestion2);

            // Properties
            this.Property(t => t.Question21)
                .HasMaxLength(200);

            // Table & Column Mappings
            this.ToTable("Question2");
            this.Property(t => t.IDQuestion2).HasColumnName("IDQuestion2");
            this.Property(t => t.Question21).HasColumnName("Question2");
        }
    }
}
