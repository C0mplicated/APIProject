﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingProject.Core.Model
{
    public class AvailableSize
    {
        public int SizeId { get; set; }

        public int ProductId { get; set; }

        public string SizeValue { get; set; } = null!;

        public virtual Product Product { get; set; } = null!;
    }
}
