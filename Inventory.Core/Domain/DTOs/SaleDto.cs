using Inventory.Core.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Core.Domain.DTOs
{
    public class SaleDto
    {
        public CustomerName CustomerName { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
    }
}
