using Microsoft.EntityFrameworkCore;
using TechStore.Models;

namespace TechStore.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Maker> Makers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
