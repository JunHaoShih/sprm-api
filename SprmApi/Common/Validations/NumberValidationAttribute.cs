using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace SprmApi.Common.Validations
{
    /// <summary>
    /// Validate generic number in SPRM
    /// </summary>
    public class NumberValidationAttribute : ValidationAttribute
    {
        /// <summary>
        /// Minimum value of decimal
        /// </summary>
        public int MinNumberLength { get; set; } = 3;

        /// <summary>
        /// Validate generic number in SPRM
        /// </summary>
        /// <param name="value"></param>
        /// <param name="validationContext"></param>
        /// <returns></returns>
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return new ValidationResult(ErrorMessage ?? $"number cannot be null");
            }
            if (value is not string)
            {
                return new ValidationResult(ErrorMessage ?? $"{value} is not a string");
            }
            var username = (string)value;
            foreach (var validator in GetValidators())
            {
                var isValid = validator.Validate(username);
                if (!isValid)
                {
                    return new ValidationResult(ErrorMessage ?? $"{validator.Message}");
                }
            }

            return ValidationResult.Success;
        }

        private List<Validator> GetValidators()
        {
            return new List<Validator>
            {
                new Validator
                {
                    Validate = str => str.Length >= MinNumberLength && str.Length <= 50,
                    Message = "Number length must between 3 to 50"
                },
                new Validator
                {
                    Validate = str => new Regex(@"^[a-zA-Z0-9_-]*$", RegexOptions.None, TimeSpan.FromMilliseconds(100)).IsMatch(str),
                    Message = "Number cannot contains invalid characters"
                },
            };
        }
    }
}
