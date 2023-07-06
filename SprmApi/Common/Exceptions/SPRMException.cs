using SprmApi.Common.Error;

namespace SprmApi.Common.Exceptions
{
    /// <summary>
    /// Custom generic exception
    /// </summary>
    public class SPRMException : Exception
    {
        /// <summary>
        /// Error code
        /// </summary>
        public ErrorCode Code { get; set; }

        /// <summary>
        /// Error content
        /// </summary>
        public string Content { get; set; } = "";

        /// <summary>
        /// Basic exception constructor, don't use this
        /// </summary>
        public SPRMException()
            : base()
        {
        }

        /// <summary>
        /// Basic exception constructor, don't use this
        /// </summary>
        /// <param name="message"></param>
        public SPRMException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Basic exception constructor, don't use this
        /// </summary>
        /// <param name="message"></param>
        /// <param name="inner"></param>
        public SPRMException(string message, Exception inner)
            : base(message, inner)
        {
        }

        /// <summary>
        /// Exception with error code and content
        /// </summary>
        /// <param name="code"></param>
        /// <param name="content"></param>
        public SPRMException(ErrorCode code, string content)
            : base(code.GetMessage())
        {
            Code = code;
            Content = content;
        }
    }
}
