using SprmApi.Common.Paginations;

namespace SprmApi.MiddleWares
{
    /// <summary>
    /// 分頁middleware資料
    /// </summary>
    public class PaginationData
    {
        /// <summary>
        /// 
        /// </summary>
        public OffsetPaginationResponse? PaginationHeader { get; set; }
    }
}
