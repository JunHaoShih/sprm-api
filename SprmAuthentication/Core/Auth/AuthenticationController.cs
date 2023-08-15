using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using SprmAuthentication.Core.Auth.Dto;
using SprmCommon.Response;

namespace SprmAuthentication.Core.Auth
{
    /// <summary>
    /// Authentication controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [OpenApiTag("Authentication", Description = "使用者驗證")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="authenticationService"></param>
        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        /// <summary>
        /// 身分驗證
        /// </summary>
        /// <param name="authDTO"></param>
        /// <returns></returns>
        /// <response code="200">登入成功</response>
        /// <response code="500">登入失敗</response>
        [ProducesResponseType(typeof(GenericResponse<AuthenticateResponseDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status500InternalServerError)]
        [HttpPost("Login")]
        public async Task<IActionResult> Authenticate(AuthenticateRequestDto authDTO)
        {
            AuthenticateResponseDto response = await _authenticationService.Authenticate(authDTO);
            return Ok(GenericResponse<AuthenticateResponseDto>.Success(response));
        }

        /// <summary>
        /// ReAuthenticate access token to inner token
        /// </summary>
        /// <param name="reauthDto"></param>
        /// <returns></returns>
        /// <response code="200">ReAuthenticate成功</response>
        /// <response code="500">ReAuthenticate失敗</response>
        /// <response code="401">驗證失敗</response>
        [ProducesResponseType(typeof(GenericResponse<ReAuthenticateResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status401Unauthorized)]
        [HttpPost]
        public IActionResult ReAuthenticate(ReAuthenticateRequest reauthDto)
        {
            ReAuthenticateResponse response = _authenticationService.ReAuthenticate(reauthDto);
            return Ok(GenericResponse<ReAuthenticateResponse>.Success(response));
        }

        /// <summary>
        /// Refresh access token
        /// </summary>
        /// <param name="refreshDto"></param>
        /// <returns></returns>
        /// <response code="200">Refresh成功</response>
        /// <response code="500">Refresh失敗</response>
        /// <response code="401">驗證失敗</response>
        [ProducesResponseType(typeof(GenericResponse<AuthenticateResponseDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status401Unauthorized)]
        [HttpPost("Refresh")]
        public async Task<IActionResult> Refresh(RefreshTokenDto refreshDto)
        {
            AuthenticateResponseDto response = await _authenticationService.Refresh(refreshDto);
            return Ok(GenericResponse<AuthenticateResponseDto>.Success(response));
        }
    }
}
