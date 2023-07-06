using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using SprmApi.Common.Response;
using SprmApi.Core.AppUsers;
using SprmApi.Core.Auth.DTOs;

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
        private readonly IAuthenticationService _authenticationService;

        private readonly JWTService _jwtService;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="jwtService"></param>
        /// <param name="authenticationService"></param>
        public AuthenticationController(JWTService jwtService, IAuthenticationService authenticationService)
        {
            _jwtService = jwtService;
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
        [HttpPost]
        public async Task<IActionResult> Authenticate(AuthenticateDto authDTO)
        {
            AppUser appUser = await _authenticationService.Authenticate(authDTO);
            string token = _jwtService.GenerateToken(appUser);
            AuthenticateResponseDto responseDTO = new AuthenticateResponseDto
            {
                Token = token,
            };
            return Ok(GenericResponse<AuthenticateResponseDto>.Success(responseDTO));
        }
    }
}
