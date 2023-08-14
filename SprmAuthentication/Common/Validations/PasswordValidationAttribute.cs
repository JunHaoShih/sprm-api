using System.ComponentModel.DataAnnotations;
using SprmCommon.Validations;

namespace SprmAuthentication.Common.Validations
{
    /// <summary>
    /// Validate password
    /// </summary>
    public class PasswordValidationAttribute : ValidationAttribute
    {
        private readonly List<DataValidator> _validators = new()
        {
            new DataValidator
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
