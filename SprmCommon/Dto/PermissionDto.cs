using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SprmCommon.Enumerations;

namespace SprmCommon.Dto
{
    /// <summary>
    /// 權限DTO
    /// </summary>
    public class PermissionDto
    {
        /// <summary>
        /// 物件類型
        /// </summary>
        public SprmObjectType ObjectType { get; set; }

        /// <summary>
        /// 允許建立
        /// </summary>
        public bool CreatePermitted { get; set; }

        /// <summary>
        /// 允許讀取
        /// </summary>
        public bool ReadPermitted { get; set; }

        /// <summary>
        /// 允許修改
        /// </summary>
        public bool UpdatePermitted { get; set; }

        /// <summary>
        /// 允許刪除
        /// </summary>
        public bool DeletePermitted { get; set; }
    }
}
