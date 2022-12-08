using Inventory.Core.Application.DTOs;
using Inventory.Core.Domain.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Core.Application.Commands.Handlers
{
    internal class CreateProductCommandHandler : IRequestHandler<CreateProductComand, bool>
    {
        private readonly IProductRepository _productRepository;

        public CreateProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public  async Task<bool> Handle(CreateProductComand request, CancellationToken cancellationToken)
        {
           return  await _productRepository.Create(request.ProductRequest.AsEntity());
        }
    }
}
