using Microsoft.EntityFrameworkCore;

namespace ProductWebsite.Models
{
    public class ProductCatalogContext : DbContext 
        
    {
        public ProductCatalogContext(DbContextOptions<ProductCatalogContext> options) 
            : base(options)
        {
            
        }
        public DbSet<Product> Products { get; set;}
    }
}
