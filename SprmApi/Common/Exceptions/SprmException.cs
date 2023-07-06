using System.Runtime.Serialization;
using SprmApi.Common.Error;

namespace SprmApi.Common.Exceptions
{
    /// <summary>
    /// Custom generic exception
    /// </summary>
    [Serializable]
    public class SprmException : Exception
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
        public SprmException()
            : base()
        {
        }

        /// <summary>
        /// Basic exception constructor, don't use this
        /// </summary>
        /// <param name="message"></param>
        public SprmException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Basic exception constructor, don't use this
        /// </summary>
        /// <param name="message"></param>
        /// <param name="inner"></param>
        public SprmException(string message, Exception inner)
            : base(message, inner)
        {
        }

        /// <summary>
        /// Exception with error code and content
        /// </summary>
        /// <param name="code"></param>
        /// <param name="content"></param>
        public SprmException(ErrorCode code, string content)
            : base(code.GetMessage())
        {
            Code = code;
            Content = content;
        }

        /// <inheritdoc/>
        protected SprmException(SerializationInfo info, StreamingContext context)
        : base(info, context)
        { }
    }
}
