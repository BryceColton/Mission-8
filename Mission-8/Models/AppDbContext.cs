using Microsoft.EntityFrameworkCore;

namespace Mission_8.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<TaskModel> Tasks { get; set; }
        public DbSet<CategoryModel> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seed the database with default categories
            modelBuilder.Entity<CategoryModel>().HasData(
                new CategoryModel { CategoryId = 1, CategoryName = "Home" },
                new CategoryModel { CategoryId = 2, CategoryName = "School" },
                new CategoryModel { CategoryId = 3, CategoryName = "Work" },
                new CategoryModel { CategoryId = 4, CategoryName = "Church" }
            );
        }
    }
}
