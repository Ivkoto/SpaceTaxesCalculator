using System;
using System.Text;
using SpaceTaxesCalculator.IO;
using SpaceTaxesCalculator.Data;
using SpaceTaxesCalculator.Data.Models;
using SpaceTaxesCalculator.Services.Contracts;
using static SpaceTaxesCalculator.Data.Constants;
using static SpaceTaxesCalculator.Data.ExceptionMessages;

namespace SpaceTaxesCalculator.Services
{
    public class SpaceshipService : ISpaceshipService
    {
        private readonly TaxCalculatorDbContext context;
        private readonly IValidationService validationService;

        public SpaceshipService(TaxCalculatorDbContext context, IValidationService validationService)
        {
            this.context = context;
            this.validationService = validationService;
        }

        public string GetSpaceshipType()
        {
            var isSpaceshipTypeValid = false;
            var enteredType = string.Empty;

            while (!isSpaceshipTypeValid)
            {
                var spaceshipTypesCount = Enum.GetNames(typeof(SpaceshipTypesEnum)).Length;

                var initialTypesMessage = new StringBuilder();
                initialTypesMessage.Append("Available spaceship types are:");

                for (int i = 0; i < spaceshipTypesCount; i++)
                {
                    initialTypesMessage.Append(" | ");
                    var currentSpaceshipTypeName = Enum.GetName(typeof(SpaceshipTypesEnum), i);
                    initialTypesMessage.Append(currentSpaceshipTypeName);
                }

                OutputWriter.WriteLine(initialTypesMessage.ToString().Trim());

                OutputWriter.Write("Enter spaceship type: ");
                enteredType = InputReader.ReadLine();

                isSpaceshipTypeValid = this.validationService.ValidateSpaceshipType(enteredType);

                if (!isSpaceshipTypeValid)
                {
                    OutputWriter.DisplayExceptions(InvalidSpaceshipTypeException);
                }
            }

            return enteredType;
        }

        public int GetSpaceshipPurchaseYear()
        {
            var isPurchaseYearInCorrectFormat = false;
            var enteredPurchaseYear = string.Empty;

            while (!isPurchaseYearInCorrectFormat)
            {
                OutputWriter.Write("Enter spaceship purchase year:");
                enteredPurchaseYear = InputReader.ReadLine();

                isPurchaseYearInCorrectFormat = this.validationService.ValidateYear(enteredPurchaseYear);

                if (!isPurchaseYearInCorrectFormat)
                {
                    OutputWriter.DisplayExceptions(InvalidYearValueException);
                }
            }

            return int.Parse(enteredPurchaseYear);
        }

        public int GetTaxCalculationYear(int purchaseYear)
        {
            var isTaxCalculationYearInCorrectFormat = false;
            var isTaxCalculationYearAfterThePurchaseYear = false;
            var enteredTaxCalculationYear = string.Empty;

            while (!isTaxCalculationYearInCorrectFormat || !isTaxCalculationYearAfterThePurchaseYear)
            {
                OutputWriter.Write("Enter year of tax calculation:");
                enteredTaxCalculationYear = InputReader.ReadLine();
                isTaxCalculationYearInCorrectFormat = this.validationService.ValidateYear(enteredTaxCalculationYear);

                if (!isTaxCalculationYearInCorrectFormat)
                {
                    OutputWriter.DisplayExceptions(InvalidYearValueException);
                    continue;
                }

                isTaxCalculationYearAfterThePurchaseYear =
                    this.validationService.ValidateTaxCalculationYearValue(int.Parse(enteredTaxCalculationYear), purchaseYear);

                if (!isTaxCalculationYearAfterThePurchaseYear)
                {
                    OutputWriter.DisplayExceptions(InvalidTaxCalculationValueException);
                }
            }

            return int.Parse(enteredTaxCalculationYear);
        }

        public long GetLightMilesTraveled()
        {
            var isLightMilesInCorrectFormat = false;
            var lightMilesTraveled = string.Empty;

            while (!isLightMilesInCorrectFormat)
            {
                OutputWriter.Write("Enter light miles traveled:");
                lightMilesTraveled = InputReader.ReadLine();

                isLightMilesInCorrectFormat = this.validationService.ValidateLightMiles(lightMilesTraveled);

                if (!isLightMilesInCorrectFormat)
                {
                    OutputWriter.DisplayExceptions(InvalidLightMilesFormatException);
                }
            }

            return long.Parse(lightMilesTraveled);
        }

        public decimal GetInitialTax(string spaceshipType)
        {
            if (spaceshipType == SpaceshipTypesEnum.cargo.ToString("G"))
            {
                return InitialTax.CargoSpaceship;
            }
            if (spaceshipType == SpaceshipTypesEnum.family.ToString("G"))
            {
                return InitialTax.FamilySpaceship;
            }

            throw new ArgumentException(InvalidSpaceshipTypeException);
        }

        public decimal GetIncreasingTaxValue(string spaceshipType)
        {
            if (spaceshipType == SpaceshipTypesEnum.cargo.ToString("G"))
            {
                return TaxIncreasingValue.CargoSpaceship;
            }

            if (spaceshipType == SpaceshipTypesEnum.family.ToString("G"))
            {
                return TaxIncreasingValue.FamilySpaceship;
            }

            throw new ArgumentException(InvalidSpaceshipTypeException);
        }

        public decimal GetDecliningTaxValue(string spaceshipType)
        {
            if (spaceshipType == SpaceshipTypesEnum.cargo.ToString("G"))
            {
                return TaxDeclinesValue.CargoSpaceship;
            }

            if (spaceshipType == SpaceshipTypesEnum.family.ToString("G"))
            {
                return TaxDeclinesValue.FamilySpaceship;
            }

            throw new ArgumentException(InvalidSpaceshipTypeException);
        }

        public void CreateSpaceship(string type, int purchaseYear, long milesTraveled, decimal initialTax)
        {
            var spaceShip = new Spaceship()
            {
                Type = type,
                PurchaseYear = purchaseYear,
                MilesTraveled = milesTraveled,
                InitialTax = initialTax
            };

            this.context.Add(spaceShip);
            this.context.SaveChanges();
        }

    }
}