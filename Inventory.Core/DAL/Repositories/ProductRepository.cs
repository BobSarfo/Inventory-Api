using Inventory.Core.Domain.Entities;
using Inventory.Core.Domain.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Core.DAL.Repositories
{
    internal class ProductRepository : IProductRepository
    {
        private readonly InventoryDbContext _context;
        private readonly DbSet<Product> _products;

        public ProductRepository(InventoryDbContext context)
        {
            _context = context;
            _products = context.Products; 

        }
        public async Task<bool> Create(Product entity)
        {
            _products.Add(entity);
            return await Save();
        }

        public async Task<bool> CreateRange(ICollection<Product> entities)
        {
            _products.AddRange(entities);
            return await Save();
        }

        public Task<bool> Delete(Product entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<Product>> FindAll()
        {
           return await _products.ToListAsync();
        }

        public Task<Product> FindById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> isExists(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Save()
        {
            var changes = await _context.SaveChangesAsync();
            return changes > 0;
        }

        public Task<bool> Update(Product entity)
        {
            throw new NotImplementedException();
        }
    }
}
