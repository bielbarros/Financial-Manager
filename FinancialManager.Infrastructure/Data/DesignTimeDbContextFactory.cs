using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace FinancialManager.Infrastructure.Data
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<FinancialDbContext>
    {
        public FinancialDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<FinancialDbContext>();
            optionsBuilder.UseSqlite("Data Source=FinancialManager.db");

            return new FinancialDbContext(optionsBuilder.Options);
        }
    }
} 