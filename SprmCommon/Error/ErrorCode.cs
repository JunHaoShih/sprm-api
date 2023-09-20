using SprmCommon.Exceptions;
using System.ComponentModel;
using System.Reflection;

namespace SprmCommon.Error
{
    /// <summary>
    /// API error code
    /// </summary>
    public enum ErrorCode
    {
        /// <summary>
        /// Success
        /// </summary>
        [Description("Success")]
        Success = 0,
        /// <summary>
        /// Generic error
        /// </summary>
        [Description("Unknown Error")]
        Error = 1,

        /// <summary>
        /// Invalid token
        /// </summary>
        [Description("Invalid token")]
        InvalidToken = 100,
        /// <summary>
        /// Username or password error
        /// </summary>
        [Description("Username or password error")]
        IncorrectUsernameOrPassword = 101,
        /// <summary>
        /// Model binding error
        /// </summary>
        [Description("Model binding error, please check your parameters")]
        ModelBindingError = 102,
        /// <summary>
        /// Access denied
        /// </summary>
        [Description("Access denied")]
        AccessDenied = 103,

        /// <summary>
        /// Username already exist
        /// </summary>
        [Description("Username already exist")]
        UsernameExist = 200,
        /// <summary>
        /// User not exist
        /// </summary>
        [Description("User not exist")]
        UserNotExist = 201,

        /// <summary>
        /// Database error occured
        /// </summary>
        [Description("Database error occured")]
        DbError = 300,
        /// <summary>
        /// Duplicate data found when insert data to database
        /// </summary>
        [Description("Duplicate data found when insert data to database")]
        DbInsertDuplicate = 301,
        /// <summary>
        /// Data does not exist inside database
        /// </summary>
        [Description("Data does not exist inside database")]
        DbDataNotFound = 302,
        /// <summary>
        /// Foreign key violation
        /// </summary>
        [Description("Foreign key violation")]
        DbForeignKeyViolation = 303,

        /// <summary>
        /// Data already checkout
        /// </summary>
        [Description("Data already checkout")]
        DataAlreadyCheckout = 400,
        /// <summary>
        /// Data does not checkout
        /// </summary>
        [Description("Data does not checkout")]
        DataDoesNotCheckout = 401,
        /// <summary>
        /// Cannot found latest version
        /// </summary>
        [Description("Cannot found latest version")]
        LatestVersionNotFound = 402,
        /// <summary>
        /// Cannot found draft version
        /// </summary>
        [Description("Cannot found draft version")]
        DraftVersionNotFound = 403,
    }

    /// <summary>
    /// Error code extension for better quality of life
    /// </summary>
    public static class ErrorCodeExtension
    {
        /// <summary>
        /// Get error code message
        /// </summary>
        /// <param name="errorCode"></param>
        /// <returns></returns>
        public static string GetMessage(this ErrorCode errorCode)
        {
            var enumType = typeof(ErrorCode);
            var enumName = Enum.GetName(enumType, errorCode);
            if (enumName == null)
            {
                throw new SprmException(ErrorCode.Error, "Error occured while getting error code message");
            }
            DescriptionAttribute attr = enumType.GetField(enumName)!.GetCustomAttributes<DescriptionAttribute>().First();
            return attr.Description;
        }
    }
}
