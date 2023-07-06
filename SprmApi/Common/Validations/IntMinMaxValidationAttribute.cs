using System.ComponentModel.DataAnnotations;

namespace SprmApi.Common.Validations
{
    /// <summary>
    /// 
    /// </summary>
    public class IntMinMaxValidationAttribute : ValidationAttribute
    {
        /// <summary>
        /// Minimum value of decimal
        /// </summary>
        public int MinValue { get; set; } = int.MinValue;


        /// <summary>
        /// Maximum value of decimal
        /// </summary>
        public int MaxValue { get; set; } = int.MaxValue;

        /// <summary>
        /// Determine if int is nullable
        /// </summary>
        public bool Nullable { get; set; } = false;

        /// <summary>
        /// 檢驗enum
        /// </summary>
        /// <param name="value"></param>
        /// <param name="validationContext"></param>
        /// <returns></returns>
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (Nullable && value == null)
            {
                return ValidationResult.Success;
            }
            if (value == null)
            {
                return new ValidationResult(ErrorMessage ?? $"{validationContext.MemberName} cannot be null");
            }
            if (value is not int)
            {
                return new ValidationResult(ErrorMessage ?? $"{validationContext.MemberName}'s value: {value} is not a integer");
            }

            var number = (int)value;
            if (MinValue > number)
            {
                return new ValidationResult(ErrorMessage ?? $"{validationContext.MemberName} cannot be smaller than {MinValue}");
            }
            if (MaxValue < number)
            {
                return new ValidationResult(ErrorMessage ?? $"{value} cannot be bigger than {MaxValue}");
            }

            return ValidationResult.Success;
        }
    }
}
