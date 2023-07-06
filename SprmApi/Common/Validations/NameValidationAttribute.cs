using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace SprmApi.Common.Validations
{
    /// <summary>
    /// Validate generic name in SPRM
    /// </summary>
    public class NameValidationAttribute : ValidationAttribute
    {
        private readonly List<Validator> Validators = new List<Validator>
        {
            new Validator
            {
                Validate = str => str.Length >= 1 && str.Length <= 50,
                Message = "Name length cannot longer than 50"
            },
            new Validator
            {
                Validate = str => new Regex(@"^[^\\/:*?""<>|]+$", RegexOptions.None, TimeSpan.FromMilliseconds(100)).IsMatch(str),
                Message = "Name cannot contains invalid characters"
            },
        };

        /// <summary>
        /// Validate generic name in SPRM
        /// </summary>
        /// <param name="value"></param>
        /// <param name="validationContext"></param>
        /// <returns></returns>
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return new ValidationResult(ErrorMessage ?? $"name cannot be null");
            }
            if (value is not string)
            {
                return new ValidationResult(ErrorMessage ?? $"{value} is not a string");
            }
            var username = (string)value;
            foreach (var validator in Validators)
            {
                var isValid = validator.Validate(username);
                if (!isValid)
                {
                    return new ValidationResult(ErrorMessage ?? $"{validator.Message}");
                }
            }

            return ValidationResult.Success;
        }
    }
}
