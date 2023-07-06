using SprmApi.Common.Error;

namespace SprmApi.Common.Response
{
    /// <summary>
    /// Generic response type
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class GenericResponse<T> : ResponseBase
    {
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
