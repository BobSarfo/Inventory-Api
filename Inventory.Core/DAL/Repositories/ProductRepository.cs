using Inventory.Core.Domain.Entities;
using Inventory.Core.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Core.DAL.Repositories
{
    internal class ProductRepository : IProductRepository
    {
        public Task<bool> Create(Product entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CreateRange(ICollection<Product> entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(Product entity)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Product>> FindAll()
        {
            throw new NotImplementedException();
        }

        public Task<Product> FindById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> isExists(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Save()
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(Product entity)
        {
            throw new NotImplementedException();
        }
    }
}
