using Inventory.Core.Application.DTOs;
using Inventory.Core.Domain.DTOs;
using Inventory.Core.Domain.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Core.Application.Commands.Handlers
{
    internal class CreateSaleCommandHandler : IRequestHandler<CreateSaleCommand, bool>
    {
        private readonly ISaleRepository _saleRepository;

        public CreateSaleCommandHandler(ISaleRepository saleRepository)
        {
            _saleRepository = saleRepository;
        }
    

        public async Task<bool> Handle(CreateSaleCommand request, CancellationToken cancellationToken)
        {
            return await _saleRepository.Create(request.SaleRequest.AsEntity());
        }
    }
}
