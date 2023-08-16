using System.ComponentModel.DataAnnotations;

namespace SprmApi.Common.Validations
{
    /// <summary>
    /// Validate password
    /// </summary>
    public class PasswordValidationAttribute : ValidationAttribute
    {
        private readonly List<Validator> _validators = new()
        {
            new Validator
            {
                Validate = str => str.Length >= 6,
                Message = "Password need at least 6 characters"
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
