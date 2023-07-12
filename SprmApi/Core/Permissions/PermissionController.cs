using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using SprmApi.Common.Response;
using SprmApi.Core.Permissions.Dto;

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

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="permissionService"></param>
        public PermissionController(IPermissionService permissionService)
        {
            _permissionService = permissionService;
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
        [HttpGet("~/api/AppUser/{userId}/Permission")]
        public async Task<IActionResult> GetByUserId(long userId)
        {
            IEnumerable<PermissionDto> permissions = await _permissionService.GetByUserIdAsync(userId);
            return Ok(GenericResponse<IEnumerable<PermissionDto>>.Success(permissions));
        }
    }
}
