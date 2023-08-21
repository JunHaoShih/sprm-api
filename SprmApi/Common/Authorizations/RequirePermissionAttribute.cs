using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SprmApi.Core.ObjectTypes;
using SprmApi.Core.Permissions.Dto;
using SprmApi.MiddleWares;
using SprmCommon.Error;
using SprmCommon.Response;

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
        /// <param name="type"></param>
        /// <param name="cruds"></param>
        public RequirePermissionAttribute(SprmObjectType type, params Crud[] cruds) : base(typeof(RequirePermissionBaseAttribute))
        {
            Arguments = new object[] { type, cruds };
        }

        /// <summary>
        /// Base attribute of RequirePermissionAttribute
        /// </summary>
        /// <remarks>
        /// The only reason why this class is public is because it is the only way to make it testable
        /// </remarks>
        public class RequirePermissionBaseAttribute : IAuthorizationFilter
        {
            private readonly HeaderData _headerData;

            private readonly SprmObjectType _objectType;

            private readonly Crud[] _cruds;

            /// <summary>
            /// Constructor
            /// </summary>
            /// <param name="headerData"></param>
            /// <param name="objectType"></param>
            /// <param name="cruds"></param>
            public RequirePermissionBaseAttribute(HeaderData headerData, SprmObjectType objectType, Crud[] cruds)
            {
                _headerData = headerData;
                _objectType = objectType;
                _cruds = cruds;
            }

            /// <inheritdoc/>
            public void OnAuthorization(AuthorizationFilterContext context)
            {
                if (_headerData.JWTPayload.IsAdmin)
                {
                    return;
                }
                IEnumerable<PermissionDto> permissions = _headerData.JWTPayload.Permissions;
                PermissionDto? targetPermission = permissions.SingleOrDefault(p => p.ObjectType == _objectType);
                if (targetPermission == null)
                {
                    AccessDenied(context);
                    return;
                }
                Dictionary<Crud, bool> crudsPermission = new Dictionary<Crud, bool>
                {
                    { Crud.Create, targetPermission.CreatePermitted },
                    { Crud.Read, targetPermission.ReadPermitted },
                    { Crud.Update, targetPermission.UpdatePermitted },
                    { Crud.Delete, targetPermission.DeletePermitted }
                };
                foreach (Crud crud in _cruds)
                {
                    if (!crudsPermission[crud])
                    {
                        AccessDenied(context);
                        return;
                    }
                }
            }

            private static void AccessDenied(AuthorizationFilterContext context)
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

    /// <summary>
    /// CRUD enumeration
    /// </summary>
    public enum Crud
    {
        /// <summary>
        /// Create
        /// </summary>
        Create = 0,
        /// <summary>
        /// Read
        /// </summary>
        Read = 1,
        /// <summary>
        /// Update
        /// </summary>
        Update = 2,
        /// <summary>
        /// Delete
        /// </summary>
        Delete = 3,
    }
}
