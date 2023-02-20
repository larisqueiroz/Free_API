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
        public DbSet<Menu> Menus { get; set; }


    }
}
