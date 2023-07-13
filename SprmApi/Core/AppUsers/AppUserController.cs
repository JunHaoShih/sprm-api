﻿using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using SprmApi.Common.Authorizations;
using SprmApi.Common.Error;
using SprmApi.Common.Exceptions;
using SprmApi.Common.Response;
using SprmApi.Core.AppUsers.Dto;
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
        private readonly IAppUserService _appUserService;

        private readonly HeaderData _headerData;

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
        /// <exception cref="SprmException"></exception>
        /// <response code="200">成功取得當前使用者資訊</response>
        /// <response code="500">存取發生錯誤</response>
        /// <response code="401">驗證失敗</response>
        [ProducesResponseType(typeof(GenericResponse<AppUserDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status401Unauthorized)]
        [HttpGet("Me")]
        public async Task<IActionResult> GetCurrentUser()
        {
            AppUser? appUser = await _appUserService.GetByUsernameAsync(_headerData.JWTPayload.Subject);
            if (appUser == null)
            {
                throw new SprmAuthException(ErrorCode.Error, "Cannot find current user");
            }
            return Ok(GenericResponse<AppUserDto>.Success(AppUserDto.Parse(appUser)));
        }

        /// <summary>
        /// 建立使用者
        /// </summary>
        /// <param name="dto">新使用者資料</param>
        /// <returns></returns>
        [ProducesResponseType(typeof(GenericResponse<AppUserDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status401Unauthorized)]
        [RequireAdmin]
        [HttpPost]
        public async Task<IActionResult> Post(CreateAppUserDto dto)
        {
            AppUser newUser = await _appUserService.CreateAppUserAsync(dto);
            return Ok(GenericResponse<AppUserDto>.Success(AppUserDto.Parse(newUser)));
        }
    }
}
