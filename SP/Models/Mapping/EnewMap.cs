using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SetPortal.Models.Mapping
{
    public class EnewMap : EntityTypeConfiguration<Enew>
    {
        public EnewMap()
        {
            // Primary Key
            this.HasKey(t => t.EnewsID);

            // Properties
            this.Property(t => t.EnewsTitle)
                .HasMaxLength(500);

            this.Property(t => t.EnewsTitleM)
                .HasMaxLength(500);

            // Table & Column Mappings
            this.ToTable("Enews");
            this.Property(t => t.EnewsID).HasColumnName("EnewsID");
            this.Property(t => t.EnewsTitle).HasColumnName("EnewsTitle");
            this.Property(t => t.EnewsContent).HasColumnName("EnewsContent");
            this.Property(t => t.EnewsTitleM).HasColumnName("EnewsTitleM");
            this.Property(t => t.EnewsContentM).HasColumnName("EnewsContentM");
            this.Property(t => t.PublishDate).HasColumnName("PublishDate");
            this.Property(t => t.EndDate).HasColumnName("EndDate");
        }
    }
}
