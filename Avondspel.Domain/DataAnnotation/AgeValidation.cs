using System.ComponentModel.DataAnnotations;

namespace Avondspel.Domain.DataAnnotation
{
    public class AgeValidation : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            DateTime date;
            bool parsed = DateTime.TryParse(value?.ToString(), out date);

            if (!parsed)
            {
                return new ValidationResult("Invalid Date");
            }
            else
            {
                var min = DateTime.Now.AddYears(-16);
                var max = DateTime.Now.AddYears(-99);
                var msg = string.Format("Geef een datum op tussen {0:MM/dd/yyyy} and {1:MM/dd/yyyy}", max, min);

                if (date > min || date < max)
                {
                    return new ValidationResult(msg);
                }
            }
            return ValidationResult.Success;
        }
    }
}
