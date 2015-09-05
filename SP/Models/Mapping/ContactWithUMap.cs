using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SetPortal.Models.Mapping
{
    public class ContactWithUMap : EntityTypeConfiguration<ContactWithU>
    {
        public ContactWithUMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.HinhAnh)
                .IsFixedLength()
                .HasMaxLength(200);

            this.Property(t => t.Name)
                .HasMaxLength(200);

            this.Property(t => t.Email)
                .HasMaxLength(200);

            this.Property(t => t.SubjectEmail)
                .HasMaxLength(200);

            // Table & Column Mappings
            this.ToTable("ContactWithUs");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.HinhAnh).HasColumnName("HinhAnh");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Email).HasColumnName("Email");
            this.Property(t => t.SubjectEmail).HasColumnName("SubjectEmail");
            this.Property(t => t.ContentEmail).HasColumnName("ContentEmail");
        }
    }
}
