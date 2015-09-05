using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SetPortal.Models.Mapping
{
    public class EmailSubcribeEnewMap : EntityTypeConfiguration<EmailSubcribeEnew>
    {
        public EmailSubcribeEnewMap()
        {
            // Primary Key
            this.HasKey(t => t.IDEmail);

            // Properties
            this.Property(t => t.EmailSubcribe)
                .HasMaxLength(300);

            this.Property(t => t.UserID)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("EmailSubcribeEnews");
            this.Property(t => t.IDEmail).HasColumnName("IDEmail");
            this.Property(t => t.EmailSubcribe).HasColumnName("EmailSubcribe");
            this.Property(t => t.UserID).HasColumnName("UserID");
        }
    }
}
