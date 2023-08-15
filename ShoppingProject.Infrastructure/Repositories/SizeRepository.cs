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
    public class SizeRepository : ISizeRepository
    {
        private readonly ShoppingDbContext _context;

        public SizeRepository(ShoppingDbContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<IEnumerable<string>> GetSizesByProductIdAsync(int productId)
        {
            return await _context.AvailableSizes.Where(ps => ps.ProductId == productId).Select(ps => ps.SizeValue).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductBySizeAsync(string size)
        {
            var products = from product in _context.Products
                                    join availableSize in _context.AvailableSizes
                                    on product.Id equals availableSize.ProductId
                                    where availableSize.SizeValue == size
                                    select product;
            return await products.ToListAsync();
        }
    }
}
