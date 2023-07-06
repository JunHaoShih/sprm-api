namespace SprmApi.Common.Paginations
{
    /// <summary>
    /// Offset分頁資訊，會放入response header回傳
    /// </summary>
    public class OffsetPaginationResponse
    {
        /// <summary>
        /// 當前頁面
        /// </summary>
        public long Page { get; set; }

        /// <summary>
        /// 每頁物件數量
        /// </summary>
        public int PerPage { get; set; }

        /// <summary>
        /// 下一頁，若為null表示現在是最後一頁
        /// </summary>
        public long? NextPage { get; set; }

        /// <summary>
        /// 上一頁，若為null表示現在是第一頁
        /// </summary>
        public long? PreviousPage { get; set; }

        /// <summary>
        /// 總物件數量
        /// </summary>
        public long Total { get; set; }

        /// <summary>
        /// 總頁數
        /// </summary>
        public long TotalPages { get; set; }
    }
}
