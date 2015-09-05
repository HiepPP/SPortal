using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SetPortal.Models.Mapping
{
    public class ArchivedEnewMap : EntityTypeConfiguration<ArchivedEnew>
    {
        public ArchivedEnewMap()
        {
            // Primary Key
            this.HasKey(t => t.ArchivedID);

            // Properties
            this.Property(t => t.Year)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("ArchivedEnews");
            this.Property(t => t.ArchivedID).HasColumnName("ArchivedID");
            this.Property(t => t.Year).HasColumnName("Year");
        }
    }
}
