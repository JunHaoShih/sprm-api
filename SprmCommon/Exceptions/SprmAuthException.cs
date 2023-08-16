using System.Runtime.Serialization;
using SprmCommon.Error;

namespace SprmCommon.Exceptions
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
