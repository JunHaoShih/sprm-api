using SprmCommon.Validations;

namespace SprmCommon.Paginations
{
    /// <summary>
    /// 使用者傳入的offset分頁資訊
    /// </summary>
    public class OffsetPaginationInput
    {
        /// <summary>
        /// 第幾頁(預設為1)
        /// </summary>
        [IntMinMaxValidation(MinValue = 1)]
        public int Page { get; set; } = 1;

        /// <summary>
        /// 每頁物件數量(預設20，最大100)
        /// </summary>
        [IntMinMaxValidation(MinValue = 20, MaxValue = 100)]
        public int PerPage { get; set; } = 20;
    }
}
