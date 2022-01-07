namespace SpaceTaxesCalculator.Services.Contracts
{
    public interface ICalculatorService
    {
        decimal CalculateTax(int purchaseYear, int yearOfTaxCalculations, long lightMilesTraveled, 
            decimal initialTax,  decimal taxIncreasingValue, decimal taxDecliningValue);
    }
}