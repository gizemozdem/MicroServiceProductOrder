using Microsoft.EntityFrameworkCore;
using MicroServiceProduct.Models;
using System.Linq;

namespace MicroServiceProduct.DbContexts
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

       
        public static void Seed(ProductContext context)
        {
            if (!context.Categories.Any())
            {
                context.Categories.AddRange(
                    new Category
                    {
                        Id = 1,
                        Name = "Electronic",
                        Description = "ffkkfık"
                    },
                    new Category
                    {
                        Id = 2,
                        Name = "Book",
                        Description  = "kkdfkfk"
                    }
                );

                context.SaveChanges();
            }
        }
        
    }
}
