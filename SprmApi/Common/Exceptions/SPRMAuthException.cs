using System.Runtime.Serialization;
using SprmApi.Common.Error;

namespace SprmApi.Common.Exceptions
{
    /// <summary>
    /// Authentication exception
    /// </summary>
    public class SprmAuthException : SprmException, ISerializable
    {
        /// <inheritdoc/>
        public SprmAuthException(ErrorCode code, string content)
            : base(code.GetMessage())
        {
            Code = code;
            Content = content;
        }
    }
}
