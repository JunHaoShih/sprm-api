using SprmApi.Common.Error;

namespace SprmApi.Common.Response
{
    /// <summary>
    /// 所有response物件的基底類別
    /// </summary>
    public abstract class ResponseBase
    {
        /// <summary>
        /// Error code
        /// </summary>
        public ErrorCode Code { get; set; }

        /// <summary>
        /// Error message
        /// </summary>
        public string Message { get; set; } = null!;
    }
}
