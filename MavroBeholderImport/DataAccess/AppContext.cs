using MavroBeholderImport.Models;
using System.Data.Entity;

namespace MavroBeholderImport.DataAccess
{
    public partial class AppContext : DbContext
    {
        public AppContext()
            : base("name=AppContext")
        {
        }

        public virtual DbSet<Chapter> Chapters { get; set; }
        public virtual DbSet<ChapterMediaPublishedRel> ChapterMediaPublishedRels { get; set; }
        public virtual DbSet<MediaPublished> MediaPublisheds { get; set; }
        public virtual DbSet<MediaPublishedContext> MediaPublishedContexts { get; set; }
        public virtual DbSet<MediaWebsiteEGroup> MediaWebsiteEGroups { get; set; }
        public virtual DbSet<MediaWebsiteEGroupContext> MediaWebsiteEGroupContexts { get; set; }
        public virtual DbSet<BeholderPerson> BeholderPeople { get; set; }
        public virtual DbSet<CommonPerson> CommonPeople { get; set; }
        public virtual DbSet<PersonMediaPublishedRel> PersonMediaPublishedRels { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Chapter>()
                .Property(e => e.ChapterName)
                .IsUnicode(false);

            modelBuilder.Entity<Chapter>()
                .Property(e => e.ChapterDesc)
                .IsUnicode(false);

            modelBuilder.Entity<Chapter>()
                .Property(e => e.RemovalReason)
                .IsUnicode(false);

            modelBuilder.Entity<Chapter>()
                .HasMany(e => e.ChapterMediaPublishedRels)
                .WithRequired(e => e.Chapter)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MediaPublished>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<MediaPublished>()
                .Property(e => e.Author)
                .IsUnicode(false);

            modelBuilder.Entity<MediaPublished>()
                .Property(e => e.RenewalPermission)
                .IsUnicode(false);

            modelBuilder.Entity<MediaPublished>()
                .Property(e => e.Summary)
                .IsUnicode(false);

            modelBuilder.Entity<MediaPublished>()
                .Property(e => e.City)
                .IsUnicode(false);

            modelBuilder.Entity<MediaPublished>()
                .Property(e => e.County)
                .IsUnicode(false);

            modelBuilder.Entity<MediaPublished>()
                .Property(e => e.RemovalReason)
                .IsUnicode(false);

            modelBuilder.Entity<MediaPublished>()
                .Property(e => e.CatalogId)
                .IsUnicode(false);

            modelBuilder.Entity<MediaPublished>()
                .HasMany(e => e.ChapterMediaPublishedRels)
                .WithRequired(e => e.MediaPublished)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MediaPublished>()
                .HasMany(e => e.PersonMediaPublishedRels)
                .WithRequired(e => e.MediaPublished)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MediaPublishedContext>()
                .Property(e => e.FileName)
                .IsUnicode(false);

            modelBuilder.Entity<MediaPublishedContext>()
                .Property(e => e.DocumentExtension)
                .IsUnicode(false);

            modelBuilder.Entity<MediaWebsiteEGroup>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<MediaWebsiteEGroup>()
                .Property(e => e.URL)
                .IsUnicode(false);

            modelBuilder.Entity<MediaWebsiteEGroup>()
                .Property(e => e.IPAddress)
                .IsUnicode(false);

            modelBuilder.Entity<MediaWebsiteEGroup>()
                .Property(e => e.WhoIsInfo)
                .IsUnicode(false);

            modelBuilder.Entity<MediaWebsiteEGroup>()
                .Property(e => e.Summary)
                .IsUnicode(false);

            modelBuilder.Entity<MediaWebsiteEGroup>()
                .Property(e => e.City)
                .IsUnicode(false);

            modelBuilder.Entity<MediaWebsiteEGroup>()
                .Property(e => e.County)
                .IsUnicode(false);

            modelBuilder.Entity<MediaWebsiteEGroup>()
                .Property(e => e.RemovalReason)
                .IsUnicode(false);

            modelBuilder.Entity<MediaWebsiteEGroupContext>()
                .Property(e => e.FileName)
                .IsUnicode(false);

            modelBuilder.Entity<MediaWebsiteEGroupContext>()
                .Property(e => e.DocumentExtension)
                .IsUnicode(false);

            modelBuilder.Entity<BeholderPerson>()
                .Property(e => e.DistinguishableMarks)
                .IsUnicode(false);

            modelBuilder.Entity<BeholderPerson>()
                .Property(e => e.RemovalReason)
                .IsUnicode(false);
        }
    }
}
