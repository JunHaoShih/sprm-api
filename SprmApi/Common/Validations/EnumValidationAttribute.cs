using System.ComponentModel.DataAnnotations;

namespace SprmApi.Common.Validations
{
    /// <summary>
    /// 驗證enum用attribute
    /// </summary>
    public class EnumValidationAttribute : ValidationAttribute
    {
        /// <summary>
        /// 檢驗enum
        /// </summary>
        /// <param name="value"></param>
        /// <param name="validationContext"></param>
        /// <returns></returns>
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return ValidationResult.Success;
            }

            var type = value.GetType();

            if (!(type.IsEnum && Enum.IsDefined(type, value)))
            {
                return new ValidationResult(ErrorMessage ?? $"{value} is not a valid value for type {type.Name}");
            }

            return ValidationResult.Success;
        }
    }
}
