using Microsoft.EntityFrameworkCore;
using MelonFinanceHelper.Models;

namespace MelonFinanceHelper.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Transaction> transactions { get; set; }
    }
}
