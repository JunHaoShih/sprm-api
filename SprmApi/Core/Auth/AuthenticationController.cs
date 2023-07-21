using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using SprmApi.Common.Error;
using SprmApi.Common.Exceptions;
using SprmApi.Common.Response;
using SprmApi.Core.AppUsers;
using SprmApi.Core.Auth.Dto;

namespace SprmApi.Core.Auth
{
    /// <summary>
    /// Authentication controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [OpenApiTag("Authentication", Description = "使用者驗證")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAppUserService _appUserService;

        private readonly JwtService _jwtService;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="jwtService"></param>
        /// <param name="appUserService"></param>
        public AuthenticationController(JwtService jwtService, IAppUserService appUserService)
        {
            _jwtService = jwtService;
            _appUserService = appUserService;
        }

        /// <summary>
        /// 身分驗證
        /// </summary>
        /// <param name="authDTO"></param>
        /// <returns></returns>
        /// <exception cref="SprmException"></exception>
        /// <response code="200">登入成功</response>
        /// <response code="500">登入失敗</response>
        [ProducesResponseType(typeof(GenericResponse<AuthenticateResponseDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status500InternalServerError)]
        [HttpPost]
        public async Task<IActionResult> Authenticate(AuthenticateDto authDTO)
        {
            AppUser? appUser = await _appUserService.GetByAuthenticateAsync(authDTO.Username, authDTO.Password);
            if (appUser == null)
            {
                throw new SprmException(ErrorCode.IncorrectUsernameOrPassword, "");
            }
            string token = await _jwtService.GenerateAccessToken(appUser);
            string refreshToken = _jwtService.GenerateRefreshToken(appUser);
            AuthenticateResponseDto responseDTO = new()
            {
                Token = token,
                RefreshToken = refreshToken,
            };
            return Ok(GenericResponse<AuthenticateResponseDto>.Success(responseDTO));
        }

        /// <summary>
        /// Refresh access token
        /// </summary>
        /// <param name="refreshDto"></param>
        /// <returns></returns>
        /// <exception cref="SprmException"></exception>
        /// <response code="200">Refresh成功</response>
        /// <response code="500">Refresh失敗</response>
        /// <response code="401">驗證失敗</response>
        [ProducesResponseType(typeof(GenericResponse<AuthenticateResponseDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status401Unauthorized)]
        [HttpPost("Refresh")]
        public async Task<IActionResult> Refresh(RefreshTokenDto refreshDto)
        {
            JwtBasePayload payload = _jwtService.DecryptToken<JwtBasePayload>(refreshDto.RefreshToken);
            AppUser? appUser = await _appUserService.GetByUsernameAsync(payload.Subject);
            if (appUser == null)
            {
                throw new SprmAuthException(ErrorCode.UserNotExist, "");
            }
            string token = await _jwtService.GenerateAccessToken(appUser);
            AuthenticateResponseDto responseDTO = new()
            {
                Token = token,
                RefreshToken = refreshDto.RefreshToken,
            };
            return Ok(GenericResponse<AuthenticateResponseDto>.Success(responseDTO));
        }
    }
}
