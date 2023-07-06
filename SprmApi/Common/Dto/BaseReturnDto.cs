using SprmApi.Core;

namespace SprmApi.Common.Dto
{
    /// <summary>
    /// 回傳用DTO基底
    /// </summary>
    public abstract class BaseReturnDto
    {
        /// <summary>
        /// id
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 建立者
        /// </summary>
        public string CreateUser { get; set; } = null!;

        /// <summary>
        /// 建立日期
        /// </summary>
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// 修改者
        /// </summary>
        public string UpdateUser { get; set; } = null!;

        /// <summary>
        /// 修改日期
        /// </summary>
        public DateTime UpdateDate { get; set; }

        /// <summary>
        /// 備註
        /// </summary>
        public string? Remarks { get; set; }

        /// <summary>
        /// Populate DTO with base SPRMObject
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        protected BaseReturnDto Populate(SPRMObject obj)
        {
            Id = obj.Id;
            CreateUser = obj.CreateUser;
            CreateDate = obj.CreateDate;
            UpdateUser = obj.UpdateUser;
            UpdateDate = obj.UpdateDate;
            Remarks = obj.Remarks;
            return this;
        }
    }
}
