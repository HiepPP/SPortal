using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SetPortal.Models.Mapping
{
    public class NameStateMap : EntityTypeConfiguration<NameState>
    {
        public NameStateMap()
        {
            // Primary Key
            this.HasKey(t => t.IDState);

            // Properties
            this.Property(t => t.IDState)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.State)
                .HasMaxLength(200);

            // Table & Column Mappings
            this.ToTable("NameState");
            this.Property(t => t.IDState).HasColumnName("IDState");
            this.Property(t => t.State).HasColumnName("State");
        }
    }
}
