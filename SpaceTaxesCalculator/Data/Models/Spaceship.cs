using System;
using System.ComponentModel.DataAnnotations;
using SpaceTaxesCalculator.Data.Validation;
using static SpaceTaxesCalculator.Data.Constants.ValidationValues;

namespace SpaceTaxesCalculator.Data.Models
{
    public class Spaceship
    {
        [Key]
        public string Id { get; init; } = Guid.NewGuid().ToString();

        [Required]
        [Type]
        public string Type { get; init; }

        [Required]
        [Range(YearMinValue, YearMaxValue, ErrorMessage = "The value for the {0} should be between {1} and {2}")]
        public int PurchaseYear { get; set; }

        [Required]
        [Range(LightMilesMinValue, LightMilesMaxValue, ErrorMessage = "The value for the {0} should be between {1} and {2}")]
        public long MilesTraveled { get; set; }

        [Required]
        [MinLength(InitialTaxMinValue, ErrorMessage = "The value for the {0} should be positive number and equal or bigger than {1}")]
        public decimal InitialTax { get; set; }

        [Range(YearMinValue, YearMaxValue, ErrorMessage = "The value for the {0} should be between {1} and {2}")]
        public int TaxCalculationYear { get; set; }
        
        [MinLength(TaxDueMinValue, ErrorMessage = "The value for the {0} should be positive number and equal or bigger than {1}")]
        public decimal TaxDue { get; set; }
    }
}