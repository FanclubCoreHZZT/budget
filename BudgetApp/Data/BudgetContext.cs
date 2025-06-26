using Microsoft.EntityFrameworkCore;
using BudgetApp.Models;

namespace BudgetApp.Data
{
    public class BudgetContext : DbContext
    {
        public DbSet<User> Users => Set<User>();
        public DbSet<Category> Categories => Set<Category>();
        public DbSet<Transaction> Transactions => Set<Transaction>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Database=budget;Username=user;Password=pass");
        }
    }
}
