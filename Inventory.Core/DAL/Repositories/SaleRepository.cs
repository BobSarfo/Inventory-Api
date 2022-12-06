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
            
        public Task<bool> ExistsAsync(string name)
            => _sales.AnyAsync(x => x.Name == name);

        public Task<Sale> GetAsync(int id)
            => _sales.SingleOrDefaultAsync(x => x.Id == id);

        public async Task AddAsync(Sale sale)
        {
            await _sales.AddAsync(sale);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Sale sale)
        {
            _sales.Update(sale);
            await _context.SaveChangesAsync();
        }
    }
}
