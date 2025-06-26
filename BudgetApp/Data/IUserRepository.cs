using System.Threading.Tasks;
using BudgetApp.Models;

namespace BudgetApp.Data
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User?> FindByUsernameAsync(string username);
    }
}
