using Inventory.Core.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Core.Application.Commands
{
    public record  AddSales(ICollection<SaleDto> sales);
}
