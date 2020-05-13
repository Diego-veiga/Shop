using Microsoft.EntityFrameworkCore;
using Shop.Model;

namespace Shop.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Category> Category { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<User> User { get; set; }

        public DataContext(DbContextOptions<DataContext> options):base (options)
        {

        }
    }
}
