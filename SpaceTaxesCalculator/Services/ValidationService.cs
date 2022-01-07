using System;
using SpaceTaxesCalculator.Data;
using static SpaceTaxesCalculator.Data.Constants.ValidationValues;

namespace SpaceTaxesCalculator.Services
{
    public class ValidationService : IValidationService
    {
        
        public bool ValidateSpaceshipType(string spaceshipType)
            => Enum.IsDefined(typeof(SpaceshipTypesEnum), spaceshipType.ToLower());
        

        public bool ValidateYear(string year)
        {
            var isTheCurrentYearANumber = int.TryParse(year, out int givenYear);

            if (!isTheCurrentYearANumber)
            {
                return false;
            }

            if (givenYear < YearMinValue)
            {
                return false;
            }

            return true;
        }

        public bool ValidateTaxCalculationYearValue(int taxCalculationYear, int purchaseYear)
        {
            if (taxCalculationYear < purchaseYear)
            {
                return false;
            }

            return true;
        }


        public bool ValidateLightMiles(string lightMilesTraveled)
        {
            var isTheLightMilesANumber = long.TryParse(lightMilesTraveled, out var lightMiles);

            if (!isTheLightMilesANumber)
            {
                return false;
            }

            if (lightMiles < LightMilesMinValue)
            {
                return false;
            }

            return true;
        }
    }
}
