using GermanVocabulary.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace GermanVocabulary.Data
{
    public class GermanVocabularyDbContext : DbContext
    {
        public GermanVocabularyDbContext(DbContextOptions<GermanVocabularyDbContext> options) : base(options)
        {
        }

        public DbSet<Words> Words { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Words>()
                .Property(w => w.Id)
                .HasColumnName("id")
                .IsRequired();

            modelBuilder.Entity<Words>()
                .Property(w => w.German)
                .HasColumnName("german")
                .HasColumnType("text")
                .IsRequired();

            modelBuilder.Entity<Words>()
                .Property(w => w.Serbian)
                .HasColumnName("serbian")
                .HasColumnType("text")
                .IsRequired();

            modelBuilder.Entity<Words>().ToTable("words", "public").HasKey(w => w.Id);
        }
    }
}
