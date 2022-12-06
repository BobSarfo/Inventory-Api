using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
namespace Inventory.Core.DAL.Repositories
{
    public interface IBaseRepository<T> where T : class
    {
        public Task<T> FindById(int id);
        public Task<ICollection<T>> FindAll();
        public Task<bool> isExists(int id);        
        public Task<bool> Create(T entity);
        public Task<bool> CreateRange(ICollection<T> entity);
        public Task<bool> Update(T entity);        
        public Task<bool> Delete(T entity);

    }
}
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.