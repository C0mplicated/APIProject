using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingProject.Core.Model
{
    public class Product
    {
        public int Id { get; set; }

        public int Sku { get; set; }

        public string Title { get; set; } = null!;

        public string? Description { get; set; }

        public string? Style { get; set; }

        public decimal Price { get; set; }

        public int? Installments { get; set; }

        public string? CurrencyId { get; set; }

        public string? CurrencyFormat { get; set; }

        public bool? IsFreeShipping { get; set; }

        public virtual ICollection<AvailableSize> AvailableSizes { get; set; } = new List<AvailableSize>();
    }
}
