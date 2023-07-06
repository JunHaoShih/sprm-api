namespace SprmApi.Common.Extensions
{
    /// <summary>
    /// DateTime extension for better quality of life
    /// </summary>
    public static class DateTimeExtensions
    {
        /// <summary>
        /// 取得UnixTimestamp(毫秒)
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static long GetUnixTimestampMilliseconds(this DateTime dateTime)
        {
            DateTimeOffset dateTimeOffset = new DateTimeOffset(dateTime);
            return dateTimeOffset.ToUnixTimeMilliseconds();
        }

        /// <summary>
        /// 取得UnixTimestamp(秒)
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static long GetUnixTimestamp(this DateTime dateTime)
        {
            DateTimeOffset dateTimeOffset = new DateTimeOffset(dateTime);
            return dateTimeOffset.ToUnixTimeSeconds();
        }
    }
}
