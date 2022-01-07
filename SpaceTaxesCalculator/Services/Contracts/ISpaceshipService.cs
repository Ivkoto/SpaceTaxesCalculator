namespace SpaceTaxesCalculator.Services.Contracts
{
    public interface ISpaceshipService
    {
        string GetSpaceshipType();

        int GetSpaceshipPurchaseYear();

        int GetTaxCalculationYear(int purchaseYear);

        long GetLightMilesTraveled();

        decimal GetInitialTax(string spaceshipType);

        decimal GetIncreasingTaxValue(string spaceshipType);

        decimal GetDecliningTaxValue(string spaceshipType);
        
        void CreateSpaceship(string type, int purchaseYear, long milesTraveled, decimal initialTax);
    }
}