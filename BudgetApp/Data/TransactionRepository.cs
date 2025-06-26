using BudgetApp.Models;

namespace BudgetApp.Data
{
    public class TransactionRepository : Repository<Transaction>
    {
        public TransactionRepository(BudgetContext context) : base(context)
        {
        }
    }
}
