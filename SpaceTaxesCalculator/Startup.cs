using System;
using SpaceTaxesCalculator.IO;
using SpaceTaxesCalculator.Core;
using SpaceTaxesCalculator.Data;
using SpaceTaxesCalculator.Services;

namespace SpaceTaxesCalculator
{
    public static class Startup
    {
        public static void Main()
        {
            try
            {
                using var context = new TaxCalculatorDbContext();
                
                var databaseService = new DatabaseService(context);
                var validationService = new ValidationService();
                var spaceShipService = new SpaceshipService(context, validationService);
                var calculatorService = new CalculatorService();

                var engine = new Engine(calculatorService, spaceShipService, databaseService);

                engine.Run();
            }
            catch (Exception e)
            {
                 OutputWriter.WriteLine(e.Message);
            }
        }
    }
}
