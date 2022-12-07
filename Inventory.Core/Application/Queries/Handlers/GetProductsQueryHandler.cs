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
    public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, ProductResponse>
    {
        private readonly IProductRepository _productRepository;

        public GetProductsQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<ProductResponse> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            var products = (await _productRepository.FindAll()).AsProductDtoList();
            return new ProductResponse { Products = products };
        }
    }
}
