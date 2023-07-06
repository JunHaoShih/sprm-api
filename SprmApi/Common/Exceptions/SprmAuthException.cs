using System.Runtime.Serialization;
using SprmApi.Common.Error;

namespace SprmApi.Common.Exceptions
{
    /// <summary>
    /// Authentication exception
    /// </summary>
    [Serializable]
    public class SprmAuthException : SprmException
    {
        /// <inheritdoc/>
        public SprmAuthException(ErrorCode code, string content)
            : base(code.GetMessage())
        {
            Code = code;
            Content = content;
        }

        /// <inheritdoc/>
        protected SprmAuthException(SerializationInfo info, StreamingContext context)
        : base(info, context)
        { }
    }
}
