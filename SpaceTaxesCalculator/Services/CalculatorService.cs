using SpaceTaxesCalculator.Services.Contracts;
using static SpaceTaxesCalculator.Data.Constants;

namespace SpaceTaxesCalculator.Services
{
    public class CalculatorService : ICalculatorService
    {
        public decimal CalculateTax(int purchaseYear, int yearOfTaxCalculations, long lightMilesTraveled, 
            decimal initialTax, decimal taxIncreasingValue, decimal taxDecliningValue)
        {
            var taxIncreasingMultiplier = lightMilesTraveled / TaxIncreasingValue.MilesStep;
            var taxDecliningMultiplier = yearOfTaxCalculations - purchaseYear;

            var taxDue = initialTax + (taxIncreasingMultiplier * taxIncreasingValue) - (taxDecliningMultiplier * taxDecliningValue);

            return taxDue;
        }
    }
}