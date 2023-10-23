using Free_API.Models.DAO;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Free_API.Data
{
    public class FreeAPIContext : DbContext
    {
        public FreeAPIContext(DbContextOptions<FreeAPIContext> options): base(options)
        {
        }

        public DbSet<Allergen> Allergens { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasAlternateKey(user => new { user.Email });

            modelBuilder.Entity<Allergen>().HasIndex(a => a.Name).IsUnique();
            modelBuilder.Entity<Category>().HasIndex(c => c.Name).IsUnique();
        }
    }
}
