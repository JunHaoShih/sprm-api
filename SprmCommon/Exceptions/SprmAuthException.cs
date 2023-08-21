using SprmCommon.Error;
using System.Runtime.Serialization;

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
