using Microsoft.EntityFrameworkCore;
using MicroServiceProduct.DbContexts;
using MicroServiceProduct.Models;
using System.Collections.Generic;
using System.Linq;
using System;

namespace MicroServiceProduct.Repository
{
    public class ProductRepository : IProductRepository
    {
      private readonly ProductContext _dbContext;

        public ProductRepository(ProductContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void DeleteProduct(int ProductId)
        {
            var product = _dbContext.Products.Find(ProductId); 
            if (product != null)
            {
                _dbContext.Products.Remove(product);
                Save();
            }


        }

        public Product GetProductId(int ProductId)
        {
            return _dbContext.Products.Find(ProductId);
        }

        public IEnumerable<Product> GetProducts()
        {
            return _dbContext.Products.ToList();
        }

        public void InsertProduct(Product Product)
        {
            _dbContext.Add(Product);
            Save();
        }

        public void Save()
        {
            try
            {
                _dbContext.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                // Hata ile ilgili bilgi al
                Console.WriteLine($"Veri güncelleme hatası: {ex.Message}");
                // Daha fazla detay almak için InnerException'ı kontrol et
                if (ex.InnerException != null)
                {
                    Console.WriteLine($"İç hata: {ex.InnerException.Message}");
                }
                throw; // Hatayı dışarı fırlat
            }
        }


        public void UpdateProduct(Product Product)
        {
            _dbContext.Products.Update(Product);
            Save();
        }
    }
}
