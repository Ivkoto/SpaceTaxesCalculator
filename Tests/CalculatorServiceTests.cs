using NUnit.Framework;
using SpaceTaxesCalculator.Services;
using SpaceTaxesCalculator.Services.Contracts;

namespace SpaceTaxesCalculator.Tests
{
    [TestFixture]
    public class CalculatorServiceTests
    {
        private ICalculatorService taxCalculatorService;

        [SetUp]
        public void Setup()
        {
            this.taxCalculatorService = new CalculatorService();
        }

        [Test]
        public void EnsureCalculatorReturnCorrectResultForFamilyShip()
        {
            const int shipPurchaseYear = 2300;
            const int yearOfTaxCalculations = 2307;
            const long lightMilesTraveled = 2344;
            const decimal familyShipInitialTax = 5000;
            const decimal taxIncreasingValue = 100;
            const decimal taxDecliningValue = 355;
            const decimal desiredResult = 2715;

            var tacDue = this.taxCalculatorService.CalculateTax(shipPurchaseYear, yearOfTaxCalculations,
                lightMilesTraveled, familyShipInitialTax, taxIncreasingValue, taxDecliningValue);

            Assert.That(tacDue, Is.EqualTo(desiredResult));
        }
        

        [Test]
        public void EnsureCalculatorReturnCorrectResultForCargoShip()
        {
            const int shipPurchaseYear = 2332;
            const int yearOfTaxCalculations = 2369;
            const long lightMilesTraveled = 344789;
            const decimal cargoShipInitialTax = 10000;
            const decimal taxIncreasingValue = 1000;
            const decimal taxDecliningValue = 736;
            const decimal desiredResult = 326768;

            var tacDue = this.taxCalculatorService.CalculateTax(shipPurchaseYear, yearOfTaxCalculations,
                lightMilesTraveled, cargoShipInitialTax, taxIncreasingValue, taxDecliningValue);

            Assert.That(tacDue, Is.EqualTo(desiredResult));
        }

        [Test]
        public void EnsureCalculatorReturnCorrectResultForLongTimeUsage()
        {
            /* this case show us that, if you're using the spaceship for a long time
            and have been traveled less, you will not due any money to the BigSister
            even your final tax due will be negative number. This is because for every 
            year of using, spaceship tax declines with given value */

            const int shipPurchaseYear = 1234;
            const int yearOfTaxCalculations = 3456;
            const long lightMilesTraveled = 123456;
            const decimal cargoShipInitialTax = 10000;
            const decimal taxIncreasingValue = 1000;
            const decimal taxDecliningValue = 736;

            var taxDue = this.taxCalculatorService.CalculateTax(shipPurchaseYear, yearOfTaxCalculations,
                lightMilesTraveled, cargoShipInitialTax, taxIncreasingValue, taxDecliningValue);

            Assert.That(taxDue < 0);
        }
    }
}