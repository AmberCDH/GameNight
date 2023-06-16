using System.ComponentModel.DataAnnotations;


namespace Avondspel.Domain.DataAnnotation
{
    public class TimeValidation : ValidationAttribute
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
                var min = DateTime.Now;
                var msg = string.Format("Geef een datum op voor de toekomst");
                if (date < min)
                {
                    return new ValidationResult(msg);
                }
            }
            return ValidationResult.Success;
        }
    }
}
