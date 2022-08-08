using Microsoft.EntityFrameworkCore;

namespace ProductsAPI.Database
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }


        public DbSet<ProductDetail> ProductDetails { get; set; }
        public DbSet<Kind> Kinds { get; set; }
    }
}
