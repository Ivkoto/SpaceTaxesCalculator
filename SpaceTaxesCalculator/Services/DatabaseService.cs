using Microsoft.EntityFrameworkCore;
using SpaceTaxesCalculator.Data;
using SpaceTaxesCalculator.Services.Contracts;

namespace SpaceTaxesCalculator.Services
{
    public class DatabaseService : IDatabaseService
    {
        private readonly TaxCalculatorDbContext context;

        public DatabaseService(TaxCalculatorDbContext context)
        {
            this.context = context;
        }

        public void InitializeDatabase()
        {
            //this.context.Database.EnsureCreated();
            this.context.Database.Migrate();
        }
    }
}
