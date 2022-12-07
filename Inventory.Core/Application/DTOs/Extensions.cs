using Inventory.Core.Domain.DTOs;
using Inventory.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Core.Application.DTOs
{
    public static class Extensions
    {
        public static Sale AsEntity(this CreateSaleRequest saleRequest)
        {
            return new Sale
            {
                CustomerName = saleRequest.CustomerName,
                ProductName = saleRequest.ProductName,
                ProductPrice = saleRequest.ProductPrice,
            };
        }

        public static List<SaleDto> AsDtoList(this List<Sale> sales)
        {
            return sales.Select(x =>
            new SaleDto
            {
                Customer = x.CustomerName.Value,
                Id = x.Id,
                Price = x.ProductPrice,
                Product = x.ProductName.Value

            }).ToList();
        }
    }
}
