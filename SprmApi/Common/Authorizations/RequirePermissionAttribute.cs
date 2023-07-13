using Microsoft.AspNetCore.Mvc;
using SprmApi.Core.ObjectTypes;

namespace SprmApi.Common.Authorizations
{
    /// <summary>
    /// 要求指定權限
    /// </summary>
    public class RequirePermissionAttribute : TypeFilterAttribute
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="types"></param>
        public RequirePermissionAttribute(params SprmObjectType[] types) : base(typeof(RequireBaseAttribute))
        {
            Arguments = new object[] { types };
        }
    }
}
