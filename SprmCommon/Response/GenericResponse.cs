using SprmCommon.Error;
using System;
using System.Linq;

namespace SprmCommon.Response
{
    /// <summary>
    /// Generic response type
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class GenericResponse<T>
    {
        /// <summary>
        /// Error code
        /// </summary>
        public ErrorCode Code { get; set; }

        /// <summary>
        /// Error message
        /// </summary>
        public string Message { get; set; } = null!;

        /// <summary>
        /// Return content
        /// </summary>
        public T? Content { get; set; }

        /// <summary>
        /// Get default success response
        /// </summary>
        /// <param name="content">要回傳的內容</param>
        /// <returns></returns>
        public static GenericResponse<T> Success(T? content)
        {
            return new GenericResponse<T>
            {
                Code = ErrorCode.Success,
                Message = ErrorCode.Success.GetMessage(),
                Content = content,
            };
        }
    }
}
