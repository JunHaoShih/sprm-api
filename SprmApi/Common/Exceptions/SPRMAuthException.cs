using SprmApi.Common.Error;

namespace SprmApi.Common.Exceptions
{
    /// <summary>
    /// Authentication exception
    /// </summary>
    public class SPRMAuthException : SPRMException
    {
        /// <inheritdoc/>
        public SPRMAuthException(ErrorCode code, string content)
            : base(code.GetMessage())
        {
            Code = code;
            Content = content;
        }
    }
}
