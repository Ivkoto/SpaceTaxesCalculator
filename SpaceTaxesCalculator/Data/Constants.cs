namespace SpaceTaxesCalculator.Data
{
    public static class Constants
    {
        public static class InitialTax
        {
            public const decimal CargoSpaceship = 10000;
            public const decimal FamilySpaceship = 5000;
        }

        public static class TaxIncreasingValue
        {
            public const int MilesStep = 1000;
            public const decimal CargoSpaceship = 1000;
            public const decimal FamilySpaceship = 100;
        }

        public static class TaxDeclinesValue
        {
            public const decimal CargoSpaceship = 736;
            public const decimal FamilySpaceship = 355;
        }

        public static class ValidationValues
        {
            public const int YearMinValue = 1;
            public const int YearMaxValue = int.MaxValue;
            public const long LightMilesMinValue = 0;
            public const long LightMilesMaxValue = long.MaxValue;
            public const int InitialTaxMinValue = 0;
            public const int TaxDueMinValue = 1;
        }
        
    }
}