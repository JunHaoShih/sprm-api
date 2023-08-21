using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using SprmApi.Common.Authorizations;
using SprmApi.Core.Permissions.Dto;
using SprmApi.MiddleWares;
using SprmCommon.Response;

namespace SprmApi.Core.Permissions
{
    /// <summary>
    /// 權限controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [OpenApiTag("Permission", Description = "權限")]
    public class PermissionController : ControllerBase
    {
        private readonly IPermissionService _permissionService;

        private readonly HeaderData _headerData;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="permissionService"></param>
        /// <param name="headerData"></param>
        public PermissionController(IPermissionService permissionService, HeaderData headerData)
        {
            _permissionService = permissionService;
            _headerData = headerData;
        }

        /// <summary>
        /// 取得使用者的權限
        /// </summary>
        /// <param name="userId">使用者id</param>
        /// <returns></returns>
        /// <response code="200">取得成功</response>
        /// <response code="500">取得失敗</response>
        /// <response code="401">驗證失敗</response>
        [ProducesResponseType(typeof(GenericResponse<IEnumerable<PermissionDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status401Unauthorized)]
        [RequireAdmin]
        [HttpGet("~/api/AppUser/{userId}/Permission")]
        public async Task<IActionResult> GetByUserId(long userId)
        {
            IEnumerable<PermissionDto> permissions = await _permissionService.GetByUserIdAsync(userId);
            return Ok(GenericResponse<IEnumerable<PermissionDto>>.Success(permissions));
        }

        /// <summary>
        /// 更新使用者的權限
        /// </summary>
        /// <param name="userId">使用者id</param>
        /// <param name="permissionDtos">更新資料</param>
        /// <returns></returns>
        /// <response code="200">更新成功</response>
        /// <response code="500">更新失敗</response>
        /// <response code="401">驗證失敗</response>
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status401Unauthorized)]
        [RequireAdmin]
        [HttpPut("~/api/AppUser/{userId}/Permission")]
        public async Task<IActionResult> SaveByUserId(long userId, IEnumerable<SavePermissionDto> permissionDtos)
        {
            await _permissionService.SaveAsync(permissionDtos, userId, _headerData.JWTPayload.Subject);
            return Ok(GenericResponse<string>.Success(string.Empty));
        }

        /// <summary>
        /// 取得當前使用者的權限
        /// </summary>
        /// <returns></returns>
        /// <response code="200">取得成功</response>
        /// <response code="500">取得失敗</response>
        /// <response code="401">驗證失敗</response>
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status401Unauthorized)]
        [HttpGet("~/api/AppUser/Me/Permission")]
        public async Task<IActionResult> GetCurrentUserPermissions()
        {
            IEnumerable<PermissionDto> permissions = await _permissionService.GetByUserNameAsync(_headerData.JWTPayload.Subject);
            return Ok(GenericResponse<IEnumerable<PermissionDto>>.Success(permissions));
        }
    }
}
