using Microsoft.EntityFrameworkCore;

namespace ProductsAPI.Database
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Kind>()
                .HasOne(k => k.MainProduct)
                .WithMany(m => m.Kinds)
                .HasForeignKey(k => k.MainProductId);

            //modelBuilder.Entity<ProductDetail>()
            //    .HasOne(p => p.Kind)
            //    .WithMany(ba => ba.Book_Authors)
            //    .HasForeignKey(bi => bi.AuthorId);
        }

        public DbSet<ProductDetail> ProductDetails { get; set; }
        public DbSet<Kind> Kinds { get; set; }
        public DbSet<MainProduct> MainProducts { get; set; }
    }
}
