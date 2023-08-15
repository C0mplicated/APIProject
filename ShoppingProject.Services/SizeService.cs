using ShoppingProject.Core.Interfaces;
using ShoppingProject.Core.Model;
using ShoppingProject.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingProject.Services
{
    public class SizeService : ISizeService
    {
        private readonly ISizeRepository _sizeRepository;

        public SizeService(ISizeRepository sizeRepository)
        {
            _sizeRepository = sizeRepository;
        }

        public async Task<IEnumerable<string>> GetSizesByProductIdAsync(int productId)
        {
            return await _sizeRepository.GetSizesByProductIdAsync(productId);
        }

        public async Task<IEnumerable<Product>> GetProductBySizeAsync(string size)
        {
            return await _sizeRepository.GetProductBySizeAsync(size);
        }
    }
}
