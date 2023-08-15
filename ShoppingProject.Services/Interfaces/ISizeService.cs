using ShoppingProject.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingProject.Services.Interfaces
{
    public interface ISizeService
    {
        Task<IEnumerable<string>> GetSizesByProductIdAsync(int productId);

        Task<IEnumerable<Product>> GetProductBySizeAsync(string size);
    }
}
