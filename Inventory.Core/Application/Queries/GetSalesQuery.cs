using Inventory.Core.Domain.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Core.Application.Queries
{
    public class GetSalesQuery : IRequest<SalesResponse>
    {
    }
}
