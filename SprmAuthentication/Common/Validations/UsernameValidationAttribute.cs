using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using SprmCommon.Validations;

namespace SprmAuthentication.Common.Validations
{
    /// <summary>
    /// Validate username
    /// </summary>
    public class UsernameValidationAttribute : ValidationAttribute
    {
        private readonly List<DataValidator> _validators = new()
        {
            new DataValidator
            {
                Validate = str => str.Length >= 6 && str.Length <= 20,
                Message = "Username length nust between 6 to 20"
            },
            new DataValidator
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
            foreach (DataValidator validator in _validators)
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
