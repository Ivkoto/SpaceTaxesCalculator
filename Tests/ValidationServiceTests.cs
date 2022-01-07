using NUnit.Framework;
using SpaceTaxesCalculator.Services;

namespace SpaceTaxesCalculator.Tests
{
    [TestFixture]
    public class ValidationServiceTests
    {
        private IValidationService validationService;

        [SetUp]
        public void Setup()
        {
            this.validationService = new ValidationService();
        }

        [TestCase("family")]
        [TestCase("cargo")]
        [TestCase("FAMILY")]
        [TestCase("CARGO")]
        public void EnsureTrueIfSpaceshipTypesEnumContainsEnteredType(string enteredType)
        {
            Assert.IsTrue(this.validationService.ValidateSpaceshipType(enteredType));
        }

        [TestCase("private")]
        [TestCase("wrongType")]
        [TestCase("")]
        [TestCase("5282sjgd614")]
        public void EnsureFalseIfSpaceshipTypesEnumDoNotContainsEnteredType(string enteredType)
        {
            Assert.IsFalse(this.validationService.ValidateSpaceshipType(enteredType));
        }

        [Test]
        public void EnsureTrueIfValidatedYearIsANumber()
        {
            const string enteredYear= "2565";

            var result = this.validationService.ValidateYear(enteredYear);

            Assert.IsTrue(result);
        }

        [Test]
        public void EnsureFalseIfValidatedYearIsNonANumber()
        {
            const string enteredYear = "thisIsNotANumber123";

            var result = this.validationService.ValidateYear(enteredYear);

            Assert.IsFalse(result);
        }

        [TestCase("0")]
        [TestCase("-3")]
        public void EnsureFalseIfYearIsZeroOrNegativeNumber(string enteredYear)
        {
            var result = this.validationService.ValidateYear(enteredYear);

            Assert.IsFalse(result);
        }

        [Test]
        public void EnsureFalseIfTaxCalculationYearIsBeforePurchaseYear()
        {
            const int purchaseYear = 2505;
            const int taxCalculationYear = 2408;

            var result = this.validationService.ValidateTaxCalculationYearValue(taxCalculationYear, purchaseYear);

            Assert.IsFalse(result);
        }

        [Test]
        public void EnsureTrueIfTaxCalculationYearIsAfterPurchaseYear()
        {
            const int purchaseYear = 2513;
            const int taxCalculationYear = 2605;

            var result = this.validationService.ValidateTaxCalculationYearValue(taxCalculationYear, purchaseYear);

            Assert.IsTrue(result);
        }

        [TestCase("123456789")]
        [TestCase("10")]
        public void EnsureTrueIfLightMilesAreNumber(string lightMiles)
        {
            var result = this.validationService.ValidateLightMiles(lightMiles);

            Assert.IsTrue(result);
        }

        [TestCase("123456789")]
        [TestCase("10")]
        public void EnsureTrueIfLightMilesIsPositiveValue(string lightMiles)
        {
            var result = this.validationService.ValidateLightMiles(lightMiles);

            Assert.IsTrue(result);
        }

        [TestCase("NotANumber")]
        [TestCase("SeamsLikeANumber102648")]
        public void EnsureFalseIfLightMilesAreNuN(string lightMiles)
        {
            var result = this.validationService.ValidateLightMiles(lightMiles);

            Assert.IsFalse(result);
        }

        [TestCase("-104568468")]
        public void EnsureFalseIfLightMilesIsNegativeValue(string lightMiles)
        {
            var result = this.validationService.ValidateLightMiles(lightMiles);

            Assert.IsFalse(result);
        }
        
    }
}
