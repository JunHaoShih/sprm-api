namespace SprmApi.Common.Error
{
    /// <summary>
    /// Error message attribute, purely for ErrorCode
    /// </summary>
    [AttributeUsage(AttributeTargets.Field)]
    public class ErrorMessageAttribute : Attribute
    {
        /// <summary>
        /// Error code message
        /// </summary>
        public string Message { get; private set; }

        /// <summary>
        /// Set error message attribute
        /// </summary>
        /// <param name="message"></param>
        public ErrorMessageAttribute(string message) => Message = message;
    }
}
