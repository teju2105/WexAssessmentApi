using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WexAssessmentApi.Interfaces;
using WexAssessmentApi.Models;

namespace WexAssessmentApi.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository()
        {
            // Seed some initial products
            _data.Add(1, new Product { Id = 1, Name = "Product 1", Price = 10.99m, Category = "Category 1", StockQuantity = 100 });
            _data.Add(2, new Product { Id = 2, Name = "Product 2", Price = 20.99m, Category = "Category 2", StockQuantity = 50 });
            _data.Add(3, new Product { Id = 3, Name = "Product 3", Price = 15.99m, Category = "Category 1", StockQuantity = 75 });
        }

        public Task<IEnumerable<Product>> GetProductsByCategoryAsync(string category)
        {
            var products = _data.Values.Where(p => p.Category == category);
            return Task.FromResult(products.AsEnumerable());
        }
    }
}
