using Microsoft.EntityFrameworkCore;
using SpaceTaxesCalculator.Data.Models;

namespace SpaceTaxesCalculator.Data
{
    public class TaxCalculatorDbContext : DbContext
    {
        public DbSet<Spaceship> Spaceships { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            
            optionsBuilder.UseSqlServer(@"Server=(LocalDB)\MSSQLLocalDB;Database=TaxCalculator;Trusted_Connection=True;MultipleActiveResultSets=true");
        }
    }
}