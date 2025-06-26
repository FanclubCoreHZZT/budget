using BudgetApp.Models;

namespace BudgetApp.Data
{
    public class CategoryRepository : Repository<Category>
    {
        public CategoryRepository(BudgetContext context) : base(context)
        {
        }
    }
}
