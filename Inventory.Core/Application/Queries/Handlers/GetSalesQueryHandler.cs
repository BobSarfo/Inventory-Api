using Inventory.Core.Application.DTOs;
using Inventory.Core.Domain.DTOs;
using Inventory.Core.Domain.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Core.Application.Queries.Handlers
{
    public class GetSalesQueryHandler : IRequestHandler<GetSalesQuery, SalesResponse>
    {
        private readonly ISaleRepository _saleRepository;

        public GetSalesQueryHandler(ISaleRepository saleRepository)
        {
            _saleRepository = saleRepository;
        }
        public async Task<SalesResponse> Handle(GetSalesQuery request, CancellationToken cancellationToken)
        {                      
            var saleDtoList=  (await _saleRepository.FindAll()).AsDtoList();
            return new SalesResponse { Items = saleDtoList };
        }
    }
}
