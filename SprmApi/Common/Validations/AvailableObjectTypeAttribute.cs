using System.ComponentModel.DataAnnotations;
using SprmApi.Core.ObjectTypes;

namespace SprmApi.Common.Validations
{
    /// <summary>
    /// Check is input SprmObjectType is available
    /// </summary>
    public class AvailableObjectTypeAttribute : ValidationAttribute
    {
        private readonly SprmObjectType[] _sprmObjectTypes;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="args"></param>
        public AvailableObjectTypeAttribute(params SprmObjectType[] args)
        {
            _sprmObjectTypes = args;
        }

        /// <summary>
        /// 檢驗SprmObjectType
        /// </summary>
        /// <param name="value"></param>
        /// <param name="validationContext"></param>
        /// <returns></returns>
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return new ValidationResult(ErrorMessage ?? $"{validationContext.MemberName} cannot be null");
            }
            if (value is not SprmObjectType)
            {
                return new ValidationResult(ErrorMessage ?? $"{validationContext.MemberName}'s value: {value} is not a valid enum");
            }

            SprmObjectType objType = (SprmObjectType)value;
            if (!_sprmObjectTypes.Contains(objType))
            {
                return new ValidationResult(ErrorMessage ?? $"{validationContext.MemberName} is not a valid enum");
            }

            return ValidationResult.Success;
        }
    }
}
