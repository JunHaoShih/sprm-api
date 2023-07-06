using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace SprmApi.Common.Validations
{
    /// <summary>
    /// Validate username
    /// </summary>
    public class UsernameValidationAttribute : ValidationAttribute
    {
        private readonly List<Validator> Validators = new List<Validator>
        {
            new Validator
            {
                Validate = str => str.Length >= 6 && str.Length <= 20,
                Message = "Username length nust between 6 to 20"
            },
            new Validator
            {
                Validate = str => new Regex(@"^[a-zA-Z0-9]+$", RegexOptions.None, TimeSpan.FromMilliseconds(100)).IsMatch(str),
                Message = "Cannot contains invalid characters"
            },
            new Validator
            {
                Validate = str => !str.StartsWith('_') && !str.StartsWith('-'),
                Message = "Username cannot start with hyphen or underscore"
            },
            new Validator
            {
                Validate = str => !str.EndsWith('_') && !str.EndsWith('-'),
                Message = "Username cannot end with hyphen or underscore"
            },
            new Validator
            {
                Validate = str => new Regex(@"^(?!.*[_-]{2}).+$", RegexOptions.None, TimeSpan.FromMilliseconds(100)).IsMatch(str),
                Message = "Username cannot contains two or more consecutive special characters"
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
