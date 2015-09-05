using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SetPortal.Models.Mapping
{
    public class UserAdminMap : EntityTypeConfiguration<UserAdmin>
    {
        public UserAdminMap()
        {
            // Primary Key
            this.HasKey(t => t.IDUser);

            // Properties
            this.Property(t => t.IDUser)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.UserName)
                .HasMaxLength(100);

            this.Property(t => t.Password)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("UserAdmin");
            this.Property(t => t.IDUser).HasColumnName("IDUser");
            this.Property(t => t.UserName).HasColumnName("UserName");
            this.Property(t => t.Password).HasColumnName("Password");
        }
    }
}
