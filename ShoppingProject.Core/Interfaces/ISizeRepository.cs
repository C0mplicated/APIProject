using ShoppingProject.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingProject.Core.Interfaces
{
    public interface ISizeRepository
    {
        Task<IEnumerable<string>> GetSizesByProductIdAsync(int productId);

        Task<IEnumerable<Product>> GetProductBySizeAsync(string size);
    }
}
