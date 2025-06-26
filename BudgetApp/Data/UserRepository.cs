using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BudgetApp.Models;

namespace BudgetApp.Data
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(BudgetContext context) : base(context)
        {
        }

        public Task<User?> FindByUsernameAsync(string username)
        {
            return _context.Users.FirstOrDefaultAsync(u => u.Username == username);
        }
    }
}
