using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Inventory.Core.DAL.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly InventoryDbContext _context;
        private readonly DbSet<T> _db;

        public BaseRepository(InventoryDbContext context)
        {
            _context = context;
            _db = _context.Set<T>();
        }

        public async Task Create(T entity)
        {
            _db.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task CreateRange(ICollection<T> entity)
        {
            _db.AddRange(entity);
            await _context.SaveChangesAsync();
        }


        public void Delete(T entity)
        {
            _db.Remove(entity);
        }

        public async Task<T> Find(Expression<Func<T, bool>> expression, Func<IQueryable<T>, IIncludableQueryable<T, object>> includes = null)
        {
            IQueryable<T> query = _db;
            if (includes != null)
            {
                query = includes(query);
            }

            return await query.FirstOrDefaultAsync(expression);

        }

        public async Task<IList<T>> FindAll(Expression<Func<T, bool>> expression = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> includes = null
            )
        {
            IQueryable<T> query = _db;

            if (expression != null)
            {
                query = query.Where(expression);
            }

            if (includes != null)
            {
                query = includes(query);
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            return await query.ToListAsync();
        }

        public async Task<bool> isExists(Expression<Func<T, bool>> expression = null)
        {
            IQueryable<T> query = _db;
            return await query.AnyAsync(expression);
        }

        public async Task Update(T entity)
        {
            _db.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
