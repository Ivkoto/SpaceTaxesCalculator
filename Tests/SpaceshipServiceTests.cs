using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using SpaceTaxesCalculator.Services;
using SpaceTaxesCalculator.Services.Contracts;
using SpaceTaxesCalculator.Data;
using static SpaceTaxesCalculator.Data.Constants;

namespace SpaceTaxesCalculator.Tests
{
    [TestFixture]
    public class SpaceshipServiceTests
    {
        private ISpaceshipService spaceshipService;
        private TaxCalculatorDbContext context;
        private IValidationService validationService;
        

        [SetUp]
        public void SetUp()
        {
            this.context = new TaxCalculatorDbContext();
            this.validationService = new ValidationService();
            this.spaceshipService = new SpaceshipService(this.context, this.validationService);
        }

        [Test]
        public void EnsureReturnCorrectType()
        {
            //arrange
            var enteredType = "cargo";
            
            var stringReader = new StringReader(enteredType);
            Console.SetIn(stringReader);

            //act
            var output = this.spaceshipService.GetSpaceshipType();

            //assert
            Assert.AreEqual(enteredType, output);
        }

        [Test]
        public void EnsureReturnCorrectPurchaseYear()
        {
            //arrange
            var enteredPurchaseYear = "2505";

            var stringReader = new StringReader(enteredPurchaseYear);
            Console.SetIn(stringReader);

            //act
            var output = this.spaceshipService.GetSpaceshipPurchaseYear();

            //assert
            Assert.That(int.Parse(enteredPurchaseYear) == output);
        }

        [Test]
        public void EnsureReturnCorrectTaxCalculationYear()
        {
            //arrange
            var enteredPurchaseYear = 2505;
            var enteredTaxCalculationYear = "2638";

            var stringReader = new StringReader(enteredTaxCalculationYear);
            Console.SetIn(stringReader);

            //act
            var output = this.spaceshipService.GetTaxCalculationYear(enteredPurchaseYear);

            //assert
            Assert.AreEqual(int.Parse(enteredTaxCalculationYear), output);
        }

        [Test]
        public void EnsureReturnCorrectLightMilesTraveledValue()
        {
            //arrange
            var lightMilesTraveled = "5634256";

            var stringReader = new StringReader(lightMilesTraveled);
            Console.SetIn(stringReader);

            //act
            var output = this.spaceshipService.GetLightMilesTraveled();

            //assert
            Assert.AreEqual(int.Parse(lightMilesTraveled), output);
        }

        [Test]
        public void EnsureReturnCorrectFamilySpaceshipInitialTax()
        {
            //arrange
            var stringReader = new StringReader(InitialTax.FamilySpaceship.ToString("G"));
            Console.SetIn(stringReader);

            //act
            var output = this.spaceshipService.GetInitialTax(SpaceshipTypesEnum.family.ToString("G"));

            //assert
            Assert.AreEqual(InitialTax.FamilySpaceship, output);
        }

        [Test]
        public void EnsureReturnCorrectCargoSpaceshipInitialTax()
        {
            //arrange
            var stringReader = new StringReader(InitialTax.CargoSpaceship.ToString("G"));
            Console.SetIn(stringReader);

            //act
            var output = this.spaceshipService.GetInitialTax(SpaceshipTypesEnum.cargo.ToString("G"));

            //assert
            Assert.AreEqual(InitialTax.CargoSpaceship, output);
        }

        [Test]
        public void EnsureReturnCorrectIncreasingFamilySpaceshipTaxValue()
        {
            //arrange
            var stringReader = new StringReader(TaxIncreasingValue.FamilySpaceship.ToString("G"));
            Console.SetIn(stringReader);

            //act
            var output = this.spaceshipService.GetIncreasingTaxValue(SpaceshipTypesEnum.family.ToString("G"));

            //assert
            Assert.AreEqual(TaxIncreasingValue.FamilySpaceship, output);
        }

        [Test]
        public void EnsureReturnCorrectIncreasingCargoSpaceshipTaxValue()
        {
            //arrange
            var stringReader = new StringReader(TaxIncreasingValue.CargoSpaceship.ToString("G"));
            Console.SetIn(stringReader);

            //act
            var output = this.spaceshipService.GetIncreasingTaxValue(SpaceshipTypesEnum.cargo.ToString("G"));

            //assert
            Assert.AreEqual(TaxIncreasingValue.CargoSpaceship, output);
        }

        [Test]
        public void EnsureReturnCorrectFamilySpaceshipDecliningTaxValue()
        {
            //arrange
            var stringReader = new StringReader(TaxDeclinesValue.FamilySpaceship.ToString("G"));
            Console.SetIn(stringReader);

            //act
            var output = this.spaceshipService.GetDecliningTaxValue(SpaceshipTypesEnum.family.ToString("G"));

            //assert
            Assert.AreEqual(TaxDeclinesValue.FamilySpaceship, output);
        }

        [Test]
        public void EnsureReturnCorrectCargoSpaceshipDecliningTaxValue()
        {
            //arrange
            var stringReader = new StringReader(TaxDeclinesValue.CargoSpaceship.ToString("G"));
            Console.SetIn(stringReader);

            //act
            var output = this.spaceshipService.GetDecliningTaxValue(SpaceshipTypesEnum.cargo.ToString("G"));

            //assert
            Assert.AreEqual(TaxDeclinesValue.CargoSpaceship, output);
        }

        [Test]
        public void EnsureThatSpaceshipIsCreatedAndStoredInTheDatabase()
        {
            //arrange
            var spaceshipType = SpaceshipTypesEnum.family.ToString("G");
            var purchaseYear = 2505;
            var milesTraveled = 698946538974;
            var initialTax = InitialTax.FamilySpaceship;

            //act
            this.spaceshipService.CreateSpaceship(spaceshipType, purchaseYear, milesTraveled, initialTax);
            
            var result = this.context.Spaceships
                .Any(s => s.Type == spaceshipType
                          && s.PurchaseYear == purchaseYear
                          && s.MilesTraveled == milesTraveled
                          && s.InitialTax == initialTax);
            //assert
            Assert.IsTrue(result);
        }
    }
}
