using System;
using System.Collections.Generic;

namespace ShoppingProject.Infrastructure.Models;

public partial class AvailableSize
{
    public int SizeId { get; set; }

    public int ProductId { get; set; }

    public string SizeValue { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
