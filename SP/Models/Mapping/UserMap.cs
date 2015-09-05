using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SetPortal.Models.Mapping
{
    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            // Primary Key
            this.HasKey(t => t.IDCode);

            // Properties
            this.Property(t => t.IDCode)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.UserID)
                .HasMaxLength(100);

            this.Property(t => t.UserPassword)
                .HasMaxLength(100);

            this.Property(t => t.Email)
                .HasMaxLength(100);

            this.Property(t => t.Answer1)
                .HasMaxLength(100);

            this.Property(t => t.Answer2)
                .HasMaxLength(100);

            this.Property(t => t.Answer3)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("User");
            this.Property(t => t.IDCode).HasColumnName("IDCode");
            this.Property(t => t.UserID).HasColumnName("UserID");
            this.Property(t => t.UserPassword).HasColumnName("UserPassword");
            this.Property(t => t.TimesLoginFail).HasColumnName("TimesLoginFail");
            this.Property(t => t.Email).HasColumnName("Email");
            this.Property(t => t.DateTimeLogin).HasColumnName("DateTimeLogin");
            this.Property(t => t.IDQuestion1).HasColumnName("IDQuestion1");
            this.Property(t => t.Answer1).HasColumnName("Answer1");
            this.Property(t => t.IDQuestion2).HasColumnName("IDQuestion2");
            this.Property(t => t.Answer2).HasColumnName("Answer2");
            this.Property(t => t.IDQuestion3).HasColumnName("IDQuestion3");
            this.Property(t => t.Answer3).HasColumnName("Answer3");
            this.Property(t => t.RoleID).HasColumnName("RoleID");

            // Relationships
            this.HasOptional(t => t.Question1)
                .WithMany(t => t.Users)
                .HasForeignKey(d => d.IDQuestion1);
            this.HasOptional(t => t.Question2)
                .WithMany(t => t.Users)
                .HasForeignKey(d => d.IDQuestion2);
            this.HasOptional(t => t.Question3)
                .WithMany(t => t.Users)
                .HasForeignKey(d => d.IDQuestion3);
            this.HasOptional(t => t.Role)
                .WithMany(t => t.Users)
                .HasForeignKey(d => d.RoleID);

        }
    }
}
