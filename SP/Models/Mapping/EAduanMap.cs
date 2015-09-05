using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SetPortal.Models.Mapping
{
    public class EAduanMap : EntityTypeConfiguration<EAduan>
    {
        public EAduanMap()
        {
            // Primary Key
            this.HasKey(t => t.IDEAduan);

            // Properties
            this.Property(t => t.ComplaintName)
                .HasMaxLength(200);

            this.Property(t => t.Email)
                .HasMaxLength(200);

            this.Property(t => t.Number)
                .HasMaxLength(200);

            this.Property(t => t.Address)
                .HasMaxLength(200);

            this.Property(t => t.Postcode)
                .HasMaxLength(200);

            this.Property(t => t.Town)
                .HasMaxLength(200);

            this.Property(t => t.Company)
                .HasMaxLength(200);

            this.Property(t => t.LocationCompany)
                .HasMaxLength(200);

            this.Property(t => t.Subject)
                .HasMaxLength(200);

            this.Property(t => t.Image)
                .HasMaxLength(200);

            this.Property(t => t.FileName)
                .HasMaxLength(200);

            // Table & Column Mappings
            this.ToTable("EAduan");
            this.Property(t => t.IDEAduan).HasColumnName("IDEAduan");
            this.Property(t => t.ComplaintName).HasColumnName("ComplaintName");
            this.Property(t => t.Email).HasColumnName("Email");
            this.Property(t => t.Number).HasColumnName("Number");
            this.Property(t => t.Address).HasColumnName("Address");
            this.Property(t => t.Postcode).HasColumnName("Postcode");
            this.Property(t => t.Town).HasColumnName("Town");
            this.Property(t => t.IDState).HasColumnName("IDState");
            this.Property(t => t.Company).HasColumnName("Company");
            this.Property(t => t.LocationCompany).HasColumnName("LocationCompany");
            this.Property(t => t.Subject).HasColumnName("Subject");
            this.Property(t => t.Complaint).HasColumnName("Complaint");
            this.Property(t => t.Image).HasColumnName("Image");
            this.Property(t => t.FileName).HasColumnName("FileName");

            // Relationships
            this.HasOptional(t => t.NameState)
                .WithMany(t => t.EAduans)
                .HasForeignKey(d => d.IDState);

        }
    }
}
