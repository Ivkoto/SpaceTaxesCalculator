using static SpaceTaxesCalculator.Data.Constants.ValidationValues;

namespace SpaceTaxesCalculator.Data
{
    public static class ExceptionMessages
    {
        public static readonly string InvalidSpaceshipTypeException
            = "Invalid spaceship type! Please choose from available types listed!";

        public static readonly string InvalidYearValueException
            = $"Invalid purchase year! Please input correct value between {YearMinValue} and {YearMaxValue}";

        public static readonly string InvalidLightMilesFormatException
            = $"Invalid light miles format! Please input correct value between {LightMilesMinValue} and {LightMilesMaxValue}";

        public static readonly string InvalidTaxCalculationValueException
            = $"The tax calculation year should be after or equal to the purchase year";
    }
}
