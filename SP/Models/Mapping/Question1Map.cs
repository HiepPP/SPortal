using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SetPortal.Models.Mapping
{
    public class Question1Map : EntityTypeConfiguration<Question1>
    {
        public Question1Map()
        {
            // Primary Key
            this.HasKey(t => t.IDQuestion1);

            // Properties
            this.Property(t => t.Question11)
                .HasMaxLength(200);

            // Table & Column Mappings
            this.ToTable("Question1");
            this.Property(t => t.IDQuestion1).HasColumnName("IDQuestion1");
            this.Property(t => t.Question11).HasColumnName("Question1");
        }
    }
}
