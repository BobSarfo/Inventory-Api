﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Core.Domain.DTOs
{
    public class CreateProductRequest
    {
        public string? ProductName { get; set; }
        public decimal Price { get; set; }
    }
}
