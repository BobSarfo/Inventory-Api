using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
namespace Inventory.Core.DAL.Repositories
{
    public interface IBaseRepository<T> where T : class
    {
        public Task Create(T entity);
        public Task CreateRange(ICollection<T> entity);
        public void Delete(T entity);
        public Task<T> Find(Expression<Func<T, bool>> expression, Func<IQueryable<T>, IIncludableQueryable<T, object>> includes = null);
        public Task<IList<T>> FindAll(Expression<Func<T, bool>> expression = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> includes = null
            );
        public Task<bool> isExists(Expression<Func<T, bool>> expression = null);
        public Task Update(T entity);
    }
}
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.