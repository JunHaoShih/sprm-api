using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SprmApi.Common.Error;
using SprmApi.Common.Response;
using SprmApi.MiddleWares;

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
        public RequireAdminAttribute() : base(typeof(RequireAdminBaseAttribute)) { }

        /// <summary>
        /// Base attribute of RequireAdminAttribute
        /// </summary>
        /// <remarks>
        /// The only reason why this class is public is because it is the only way to make it testable
        /// </remarks>
        public class RequireAdminBaseAttribute : IAuthorizationFilter
        {
            private readonly HeaderData _headerData;

            /// <summary>
            /// Constructor
            /// </summary>
            /// <param name="headerData"></param>
            public RequireAdminBaseAttribute(HeaderData headerData)
            {
                _headerData = headerData;
            }

            /// <inheritdoc/>
            public void OnAuthorization(AuthorizationFilterContext context)
            {
                if (!_headerData.JWTPayload.IsAdmin)
                {
                    context.Result = new ObjectResult(new GenericResponse<string>
                    {
                        Code = ErrorCode.AccessDenied,
                        Message = ErrorCode.AccessDenied.GetMessage(),
                    })
                    {
                        StatusCode = StatusCodes.Status403Forbidden
                    };
                }
            }
        }
    }
}
