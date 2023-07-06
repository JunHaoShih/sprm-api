using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using SprmApi.Common.Error;
using SprmApi.Common.Exceptions;
using SprmApi.Common.Response;
using SprmApi.Core.AppUsers.DTOs;
using SprmApi.MiddleWares;

namespace SprmApi.Core.AppUsers
{
    /// <summary>
    /// AppUser controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [OpenApiTag("AppUser", Description = "App使用者")]
    public class AppUserController : ControllerBase
    {
        private IAppUserService _appUserService;

        private HeaderData _headerData;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="appUserService"></param>
        /// <param name="headerData"></param>
        public AppUserController(IAppUserService appUserService, HeaderData headerData)
        {
            _appUserService = appUserService;
            _headerData = headerData;
        }

        /// <summary>
        /// Get current user
        /// </summary>
        /// <returns></returns>
        /// <exception cref="SPRMException"></exception>
        /// <response code="200">成功取得當前使用者資訊</response>
        /// <response code="500">存取發生錯誤</response>
        /// <response code="401">驗證失敗</response>
        [ProducesResponseType(typeof(GenericResponse<AppUserDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status401Unauthorized)]
        [HttpGet("Me")]
        public async Task<IActionResult> GetCurrentUser()
        {
            AppUser? appUser = await _appUserService.GetByUsernameAsync(_headerData.JWTPayload.Subject);
            if (appUser == null)
            {
                throw new SPRMAuthException(ErrorCode.Error, "Cannot find current user");
            }
            return Ok(GenericResponse<AppUserDTO>.Success(AppUserDTO.Parse(appUser)));
        }
    }
}
