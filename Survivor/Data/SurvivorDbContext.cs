using Microsoft.EntityFrameworkCore;
using Survivor.Models.Entities;

namespace Survivor.Data
{
    public class SurvivorDbContext : DbContext
    {
        public SurvivorDbContext(DbContextOptions<SurvivorDbContext> options) : base(options)
        {
        }

        public DbSet<CategoryEntity> Categories { get; set; }
        public DbSet<CompetitorEntity> Competitors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Category -> Competitor ilişkisi (1-n)
            modelBuilder.Entity<CompetitorEntity>()
                .HasOne(c => c.Category)
                .WithMany(c => c.Competitors)
                .HasForeignKey(c => c.CategoryId)
                .OnDelete(DeleteBehavior.Restrict); // Kategori silindiğinde yarışmacılar silinmesin

            // Soft delete için global query filter
            modelBuilder.Entity<CategoryEntity>().HasQueryFilter(c => !c.IsDeleted);
            modelBuilder.Entity<CompetitorEntity>().HasQueryFilter(c => !c.IsDeleted);
        }

    }
}
