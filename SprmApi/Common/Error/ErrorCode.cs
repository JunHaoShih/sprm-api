using System.Reflection;
using SprmApi.Common.Exceptions;

namespace SprmApi.Common.Error
{
    /// <summary>
    /// API error code
    /// </summary>
    public enum ErrorCode
    {
        /// <summary>
        /// Success
        /// </summary>
        [ErrorMessage("Success")]
        Success = 0,
        /// <summary>
        /// Generic error
        /// </summary>
        [ErrorMessage("Unknown Error")]
        Error = 1,

        /// <summary>
        /// Invalid token
        /// </summary>
        [ErrorMessage("Invalid token")]
        InvalidToken = 100,
        /// <summary>
        /// Username or password error
        /// </summary>
        [ErrorMessage("Username or password error")]
        IncorrectUsernameOrPassword = 101,
        /// <summary>
        /// Model binding error
        /// </summary>
        [ErrorMessage("Model binding error, please check your parameters")]
        ModelBindingError = 102,

        /// <summary>
        /// Username already exist
        /// </summary>
        [ErrorMessage("Username already exist")]
        UsernameExist = 200,
        /// <summary>
        /// User not exist
        /// </summary>
        [ErrorMessage("User not exist")]
        UserNotExist = 201,

        /// <summary>
        /// Database error occured
        /// </summary>
        [ErrorMessage("Database error occured")]
        DbError = 300,
        /// <summary>
        /// Duplicate data found when insert data to database
        /// </summary>
        [ErrorMessage("Duplicate data found when insert data to database")]
        DbInsertDuplicate = 301,
        /// <summary>
        /// Data does not exist inside database
        /// </summary>
        [ErrorMessage("Data does not exist inside database")]
        DbDataNotFound = 302,
        /// <summary>
        /// Foreign key violation
        /// </summary>
        [ErrorMessage("Foreign key violation")]
        DbForeignKeyViolation = 303,

        /// <summary>
        /// Data already checkout
        /// </summary>
        [ErrorMessage("Data already checkout")]
        DataAlreadyCheckout = 400,
        /// <summary>
        /// Data does not checkout
        /// </summary>
        [ErrorMessage("Data does not checkout")]
        DataDoesNotCheckout = 401,
        /// <summary>
        /// Cannot found latest version
        /// </summary>
        [ErrorMessage("Cannot found latest version")]
        LatestVersionNotFound = 402,
        /// <summary>
        /// Cannot found draft version
        /// </summary>
        [ErrorMessage("Cannot found draft version")]
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
            var attr = enumType.GetField(enumName)!.GetCustomAttributes<ErrorMessageAttribute>().First();
            return attr.Message;
        }
    }
}
