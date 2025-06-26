using System.Threading.Tasks;
using BudgetApp.Models;

namespace BudgetApp.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BudgetContext _context;
        public IUserRepository Users { get; }
        public Repository<Category> Categories { get; }
        public Repository<Transaction> Transactions { get; }

        public UnitOfWork(BudgetContext context)
        {
            _context = context;
            Users = new UserRepository(context);
            Categories = new CategoryRepository(context);
            Transactions = new TransactionRepository(context);
        }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }

    public interface IUnitOfWork
    {
        IUserRepository Users { get; }
        Repository<Category> Categories { get; }
        Repository<Transaction> Transactions { get; }
        Task<int> CompleteAsync();
    }
}
