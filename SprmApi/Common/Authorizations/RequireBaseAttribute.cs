using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SprmApi.Core.ObjectTypes;
using SprmApi.MiddleWares;

namespace SprmApi.Common.Authorizations
{
    /// <summary>
    /// 權限基底attribute
    /// </summary>
    public class RequireBaseAttribute : IAuthorizationFilter
    {
        private readonly HeaderData _headerData;
        private readonly SprmObjectType[] _objectTypes;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="headerData"></param>
        /// <param name="types"></param>
        public RequireBaseAttribute(HeaderData headerData, SprmObjectType[] types)
        {
            _headerData = headerData;
            _objectTypes = types;
        }

        /// <inheritdoc/>
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (!_headerData.JWTPayload.IsAdmin)
            {
                context.Result = new UnauthorizedObjectResult("user is unauthorized");
            }
        }
    }
}
