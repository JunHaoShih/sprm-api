using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using SprmApi.Common.Authorizations;
using SprmApi.Common.Error;
using SprmApi.Common.Exceptions;
using SprmApi.Common.Paginations;
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

        private readonly PaginationData _paginationData;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="appUserService"></param>
        /// <param name="headerData"></param>
        /// <param name="paginationData"></param>
        public AppUserController(IAppUserService appUserService, HeaderData headerData, PaginationData paginationData)
        {
            _appUserService = appUserService;
            _headerData = headerData;
            _paginationData = paginationData;
        }

        /// <summary>
        /// Get current user
        /// </summary>
        /// <returns></returns>
        /// <exception cref="SprmAuthException"></exception>
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
        /// Get user by id
        /// </summary>
        /// <param name="id">User id</param>
        /// <returns></returns>
        /// <exception cref="SprmException"></exception>
        /// <response code="200">成功取得當前使用者資訊</response>
        /// <response code="500">存取發生錯誤</response>
        /// <response code="401">驗證失敗</response>
        [ProducesResponseType(typeof(GenericResponse<AppUserDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status401Unauthorized)]
        [RequireAdmin]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            AppUser? appUser = await _appUserService.GetByIdAsync(id);
            if (appUser == null)
            {
                throw new SprmException(ErrorCode.UserNotExist, "Cannot find user");
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

        /// <summary>
        /// 簡易模糊搜尋
        /// </summary>
        /// <param name="pattern">搜尋pattern</param>
        /// <param name="input">分頁資訊</param>
        /// <returns></returns>
        /// <remarks>
        /// # 功能
        /// 此搜尋會依照傳入的pattern去找符合的編號與名稱
        /// # 注意事項
        /// 1. 此API有分頁，請注意
        /// </remarks>
        /// <response code="200">簡易模糊搜尋成功</response>
        /// <response code="500">搜尋失敗</response>
        /// <response code="401">驗證失敗</response>
        [ProducesResponseType(typeof(GenericResponse<IEnumerable<AppUserDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status401Unauthorized)]
        [RequireAdmin]
        [HttpGet("Search")]
        public async Task<IActionResult> FuzzySearch([FromQuery] string? pattern, [FromQuery] OffsetPaginationInput input)
        {
            OffsetPagination<AppUserDto> usersPagination = _appUserService.GetByPattern(pattern, input);
            List<AppUserDto> pagingList = await usersPagination.GetPagedListAsync();
            _paginationData.PaginationHeader = usersPagination.GetResponseHeader();
            return Ok(GenericResponse<IEnumerable<AppUserDto>>.Success(pagingList));
        }
    }
}
