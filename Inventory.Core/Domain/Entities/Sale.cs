using Inventory.Core.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Core.Domain.Entities
{
    public class Sale
    {
        public int Id { get; set; }
        public CustomerName CustomerName { get; set; }
        public ProductName ProductName { get; set; }
        public decimal ProductPrice { get; set; } 
    }
}
