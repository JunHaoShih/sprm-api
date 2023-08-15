using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SprmCommon.Paginations;

namespace SprmCommon.MiddleWares
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
