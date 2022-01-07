using NUnit.Framework;
using SpaceTaxesCalculator.Data;
using SpaceTaxesCalculator.Services;
using SpaceTaxesCalculator.Services.Contracts;

namespace SpaceTaxesCalculator.Tests
{
    [TestFixture]
    public class DatabaseServiceTests
    {
        private IDatabaseService databaseService;
        private TaxCalculatorDbContext context;

        [SetUp]
        public void Setup()
        {
            this.context = new TaxCalculatorDbContext();
            this.databaseService = new DatabaseService(context);
        }

        [Test]
        public void EnsureDatabaseIsCreated()
        {
            this.databaseService.InitializeDatabase();

            Assert.IsFalse(this.context.Database.EnsureCreated());
        }
    }
}
