using Microsoft.EntityFrameworkCore;

namespace SprmCommon.Paginations
{
    /// <summary>
    /// Offset分頁資訊處理
    /// </summary>
    public class OffsetPagination<T>
    {
        private readonly IQueryable<T> _items;

        private readonly OffsetPaginationInput _input;

        /// <summary>
        /// OffsetPagination constructor
        /// </summary>
        /// <param name="items"></param>
        /// <param name="paginationInput"></param>
        public OffsetPagination(IQueryable<T> items, OffsetPaginationInput paginationInput)
        {
            _items = items;
            _input = paginationInput;
        }

        /// <summary>
        /// 取得目前分頁資訊
        /// </summary>
        /// <returns></returns>
        public async Task<List<T>> GetPagedListAsync()
        {
            if (_input.Page < 1)
            {
                _input.Page = 1;
            }
            return await _items.Skip((_input.Page - 1) * _input.PerPage).Take(_input.PerPage).ToListAsync();
        }

        /// <summary>
        /// 取得offset分頁回傳資訊
        /// </summary>
        /// <returns></returns>
        public OffsetPaginationResponse GetResponseHeader()
        {
            var totalCount = _items.Count();
            var totalPages = Math.Ceiling(totalCount / (decimal)_input.PerPage);
            return new OffsetPaginationResponse
            {
                Total = totalCount,
                TotalPages = (int)totalPages,
                Page = _input.Page,
                PerPage = _input.PerPage,
                PreviousPage = _input.Page > 1 ? _input.Page - 1 : null,
                NextPage = _input.Page < totalPages ? _input.Page + 1 : null,
            };
        }
    }
}
