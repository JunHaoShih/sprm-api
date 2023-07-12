using Microsoft.AspNetCore.Mvc;

namespace SprmApi.Common.Authorizations
{
    /// <summary>
    /// 要求管理員權限
    /// </summary>
    public class RequireAdminAttribute : TypeFilterAttribute
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public RequireAdminAttribute() : base(typeof(RequireBaseAttribute)) { }
    }
}
