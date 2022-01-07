using System;
using SpaceTaxesCalculator.IO;
using SpaceTaxesCalculator.Services.Contracts;

namespace SpaceTaxesCalculator.Core
{
    public class Engine
    {
        private readonly ICalculatorService calculatorService;
        private readonly ISpaceshipService spaceshipService;
        private readonly IDatabaseService databaseService;

        //spaceship details variables
        private string spaceshipType;
        private int spaceshipPurchaseYear;
        private int taxCalculationYear;
        private long lightMilesTraveled;
        private decimal initialTax;
        private decimal taxIncreasingValue;
        private decimal taxDecliningValue;
        private decimal taxDue;

        public Engine(ICalculatorService calculatorService, ISpaceshipService spaceshipService, IDatabaseService databaseService)
        {
            this.calculatorService = calculatorService;
            this.spaceshipService = spaceshipService;
            this.databaseService = databaseService;
        }

        public void Run()
        {
            this.databaseService.InitializeDatabase();

            GetSpaceshipDetails();

            spaceshipService.CreateSpaceship(spaceshipType, spaceshipPurchaseYear, lightMilesTraveled, initialTax);

            this.taxDue = this.calculatorService.CalculateTax(spaceshipPurchaseYear, taxCalculationYear,
                lightMilesTraveled, initialTax, taxIncreasingValue, taxDecliningValue);

            OutputTaxDue();

            Run();
        }

        private void GetSpaceshipDetails()
        {
            this.spaceshipType = this.spaceshipService.GetSpaceshipType();
            this.spaceshipPurchaseYear = this.spaceshipService.GetSpaceshipPurchaseYear();
            this.taxCalculationYear = this.spaceshipService.GetTaxCalculationYear(spaceshipPurchaseYear);
            this.lightMilesTraveled = this.spaceshipService.GetLightMilesTraveled();
            this.initialTax = this.spaceshipService.GetInitialTax(this.spaceshipType);
            this.taxIncreasingValue = this.spaceshipService.GetIncreasingTaxValue(this.spaceshipType);
            this.taxDecliningValue = this.spaceshipService.GetDecliningTaxValue(this.spaceshipType);
        }

        private void OutputTaxDue()
        {
            OutputWriter.Write($"You must pay Big Sister ");

            ConsoleColor currentConsoleFontColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            OutputWriter.Write($"{this.taxDue} ");
            Console.ForegroundColor = currentConsoleFontColor;

            OutputWriter.WriteLine("DevOceanites for your traveling!" + Environment.NewLine);
        }
    }
}