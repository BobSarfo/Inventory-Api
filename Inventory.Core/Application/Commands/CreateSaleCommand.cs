using Inventory.Core.Domain.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Core.Application.Commands
{
    internal class CreateSaleCommand : IRequest<bool>
    {
        public CreateSaleRequest SaleRequest { get; set; }
    }
}
