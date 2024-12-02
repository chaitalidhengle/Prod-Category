using Microsoft.EntityFrameworkCore;

namespace ProductsAndCategory.Models
{
    public class ContextDemo:DbContext
    {
        public ContextDemo(DbContextOptions<ContextDemo>opt) :base (opt){ }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}