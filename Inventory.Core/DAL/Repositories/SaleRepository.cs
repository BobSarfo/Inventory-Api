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
    public class SaleRepository : ISaleRepository
    {
        private readonly InventoryDbContext _context;
        private readonly DbSet<Sale> _sales;

        public SaleRepository(InventoryDbContext context)
        {
            _context = context;
            _sales = _context.Sales;
        }

        public async Task<bool> Create(Sale entity)
        {
            _sales.Add(entity);
            return await Save();
        }

        public async Task<bool> CreateRange(ICollection<Sale> entities)
        {

            _sales.AddRange(entities);
            return await Save();
        }

        public async Task<bool> Delete(Sale entity)
        {

            _sales.Remove(entity);
            return await Save();
        }

        public async Task<ICollection<Sale>> FindAll() => await  _sales.ToListAsync();

        public async Task<Sale> FindById(int id) => await _sales.SingleOrDefaultAsync(x => x.Id == id);

        public async Task<bool> Update(Sale entity)
        {
            _sales.Update(entity);
            return await Save();
        }

        public async Task<bool> Save()
        {
            var changes = await _context.SaveChangesAsync();
            return changes > 0;
        }

    }
}
