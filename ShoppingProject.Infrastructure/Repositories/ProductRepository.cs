using Microsoft.EntityFrameworkCore;
using ShoppingProject.Core.Interfaces;
using ShoppingProject.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingProject.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ShoppingDbContext _dbContext;

        public ProductRepository(ShoppingDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        async Task<IEnumerable<Product>> IProductRepository.GetAllProductsAsync()
        {
            return await _dbContext.Products.ToListAsync();
        }

        async Task<Product> IProductRepository.GetProductByIdAsync(int id)
        {
            return await _dbContext.Products.FindAsync(id);
        }
    }
}
