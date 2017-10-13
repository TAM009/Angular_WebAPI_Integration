using Microsoft.EntityFrameworkCore;

namespace Product.Models
{
    public class ProductDetailsContext:DbContext
    {
        public ProductDetailsContext(DbContextOptions<ProductDetailsContext>options):base(options)
        {}
        public DbSet<ProductDetails> ProductInfoTable {get;set;}
        public DbSet<ProductGroup> ProductGroupTable {get;set;}
    }

}