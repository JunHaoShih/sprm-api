using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace SprmApi.Common.Validations
{
    /// <summary>
    /// Validate username
    /// </summary>
    public class UsernameValidationAttribute : ValidationAttribute
    {
        private readonly List<Validator> _validators = new()
        {
            new Validator
            {
                Validate = str => str.Length >= 6 && str.Length <= 20,
                Message = "Username length nust between 6 to 20"
            },
            new Validator
            {
                Validate = str => new Regex(@"^[a-zA-Z0-9_]+$", RegexOptions.None, TimeSpan.FromMilliseconds(100)).IsMatch(str),
                Message = "Cannot contains invalid characters"
            },
        };

        /// <summary>
        /// Validate username
        /// </summary>
        /// <param name="value"></param>
        /// <param name="validationContext"></param>
        /// <returns></returns>
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is not string)
            {
                return new ValidationResult(ErrorMessage ?? $"{value} is not a string");
            }
            string username = (string)value;
            foreach (Validator validator in _validators)
            {
                bool isValid = validator.Validate(username);
                if (!isValid)
                {
                    return new ValidationResult(ErrorMessage ?? $"{validator.Message}");
                }
            }
            return ValidationResult.Success;
        }
    }
}
