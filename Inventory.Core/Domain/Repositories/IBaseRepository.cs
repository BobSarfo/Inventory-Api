using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
namespace Inventory.Core.Domain.Repository
{
    public interface IBaseRepository<T> where T : class
    {
        public Task<T?> FindById(int id);
        public Task<IList<T>> FindAll();  
        public Task<bool> Create(T entity);
        public Task<bool> CreateRange(ICollection<T> entity);
        public Task<bool> Update(T entity);        
        public Task<bool> Delete(T entity);
        Task<bool> Save();

    }
}
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.