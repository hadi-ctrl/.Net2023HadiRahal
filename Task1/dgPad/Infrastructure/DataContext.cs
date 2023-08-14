using dgPad.Models;
using Microsoft.EntityFrameworkCore;

namespace dgPad.Infrastructure
{
        public class DataContext : DbContext
        {
                public DataContext(DbContextOptions<DataContext> options) : base(options) { }

                public DbSet<Product> Products { get; set; }
                public DbSet<Category> Categories { get; set; }
                public DbSet<dgPad.Models.User> User { get; set; }
        }
}
