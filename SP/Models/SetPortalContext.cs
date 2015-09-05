using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using SetPortal.Models.Mapping;

namespace SetPortal.Models
{
    public partial class SetPortalContext : DbContext
    {
        static SetPortalContext()
        {
            Database.SetInitializer<SetPortalContext>(null);
        }

        public SetPortalContext()
            : base("Name=SetPortalContext")
        {
        }

        public DbSet<ArchivedEnew> ArchivedEnews { get; set; }
        public DbSet<ChuDeEGuide> ChuDeEGuides { get; set; }
        public DbSet<ChuDeFAQ> ChuDeFAQs { get; set; }
        public DbSet<ContactWithU> ContactWithUs { get; set; }
        public DbSet<EAduan> EAduans { get; set; }
        public DbSet<EGuide> EGuides { get; set; }
        public DbSet<EmailSubcribeEnew> EmailSubcribeEnews { get; set; }
        public DbSet<Enew> Enews { get; set; }
        public DbSet<FAQ> FAQs { get; set; }
        public DbSet<NameState> NameStates { get; set; }
        public DbSet<Question1> Question1 { get; set; }
        public DbSet<Question2> Question2 { get; set; }
        public DbSet<Question3> Question3 { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<sysdiagram> sysdiagrams { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserAdmin> UserAdmins { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ArchivedEnewMap());
            modelBuilder.Configurations.Add(new ChuDeEGuideMap());
            modelBuilder.Configurations.Add(new ChuDeFAQMap());
            modelBuilder.Configurations.Add(new ContactWithUMap());
            modelBuilder.Configurations.Add(new EAduanMap());
            modelBuilder.Configurations.Add(new EGuideMap());
            modelBuilder.Configurations.Add(new EmailSubcribeEnewMap());
            modelBuilder.Configurations.Add(new EnewMap());
            modelBuilder.Configurations.Add(new FAQMap());
            modelBuilder.Configurations.Add(new NameStateMap());
            modelBuilder.Configurations.Add(new Question1Map());
            modelBuilder.Configurations.Add(new Question2Map());
            modelBuilder.Configurations.Add(new Question3Map());
            modelBuilder.Configurations.Add(new RoleMap());
            modelBuilder.Configurations.Add(new sysdiagramMap());
            modelBuilder.Configurations.Add(new UserMap());
            modelBuilder.Configurations.Add(new UserAdminMap());
        }
    }
}
