using Inventory.Core.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Core.Domain.DTOs
{
    public class SalesResponse
    {
        public List<SaleDto> Sales { get; set; }
    }
}
