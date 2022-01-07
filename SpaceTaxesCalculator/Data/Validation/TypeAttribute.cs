using System;
using System.ComponentModel.DataAnnotations;

namespace SpaceTaxesCalculator.Data.Validation
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    internal class TypeAttribute : ValidationAttribute
    {
        public TypeAttribute()
        {
            base.ErrorMessage = "Spaceship type must be one of the listed types!";
        }
        public override bool IsValid(object value)
        {
            var spaceshipType = value as string;
            return Enum.IsDefined(typeof(SpaceshipTypesEnum), spaceshipType);
        }
    }
}
