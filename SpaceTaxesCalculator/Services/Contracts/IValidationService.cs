namespace SpaceTaxesCalculator.Services
{
    public interface IValidationService
    {
        bool ValidateSpaceshipType(string spaceshipType);

        bool ValidateYear(string year);

        bool ValidateTaxCalculationYearValue(int taxCalculationYear, int purchaseYear);

        bool ValidateLightMiles(string lightMilesTraveled);
    }
}
