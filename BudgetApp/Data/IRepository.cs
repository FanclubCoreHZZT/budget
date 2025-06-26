using System.Collections.Generic;
using System.Threading.Tasks;

namespace BudgetApp.Data
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T?> GetAsync(int id);
        Task AddAsync(T entity);
        void Update(T entity);
        void Remove(T entity);
    }
}
