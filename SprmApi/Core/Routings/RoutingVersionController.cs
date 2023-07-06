using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using SprmApi.Common.Paginations;
using SprmApi.Common.Response;
using SprmApi.Core.Routings.DTOs;
using SprmApi.MiddleWares;

namespace SprmApi.Core.Routings
{
    /// <summary>
    /// 工藝路徑版本 controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [OpenApiTag("RoutingVersion", Description = "工藝路徑版本")]
    public class RoutingVersionController : ControllerBase
    {
        private readonly IRoutingVersionService _routingVersionService;

        private readonly PaginationData _paginationData;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="routingVersionService"></param>
        /// <param name="paginationData"></param>
        public RoutingVersionController(IRoutingVersionService routingVersionService, PaginationData paginationData)
        {
            _routingVersionService = routingVersionService;
            _paginationData = paginationData;
        }

        /// <summary>
        /// 取得工藝路徑的所有版本
        /// </summary>
        /// <param name="id">工藝路徑id</param>
        /// <param name="input">offset分頁資訊</param>
        /// <returns></returns>
        /// <response code="200">取得成功</response>
        /// <response code="500">取得失敗</response>
        /// <response code="401">驗證失敗</response>
        [ProducesResponseType(typeof(GenericResponse<IEnumerable<RoutingVersionDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status401Unauthorized)]
        [HttpGet("~/api/Routing/{id}/RoutingVersion")]
        public async Task<IActionResult> GetVersionsByMasterId(long id, [FromQuery] OffsetPaginationInput input)
        {
            OffsetPagination<RoutingVersionDto> versionsPagination = await _routingVersionService.GetByMasterId(id, input);
            List<RoutingVersionDto> pagingList = await versionsPagination.GetPagedListAsync();
            _paginationData.PaginationHeader = versionsPagination.GetResponseHeader();
            return Ok(GenericResponse<IEnumerable<RoutingVersionDto>>.Success(pagingList));
        }

        /// <summary>
        /// 用id取得工藝路徑版本
        /// </summary>
        /// <param name="id">工藝路徑版本id</param>
        /// <returns></returns>
        /// <response code="200">取得成功</response>
        /// <response code="500">取得失敗</response>
        /// <response code="401">驗證失敗</response>
        [ProducesResponseType(typeof(GenericResponse<RoutingVersionDto?>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status401Unauthorized)]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            RoutingVersionDto? target = await _routingVersionService.GetAsync(id);
            return Ok(GenericResponse<RoutingVersionDto?>.Success(target));
        }

        /// <summary>
        /// 更新工藝路徑版本
        /// </summary>
        /// <param name="id">工藝路徑版本id</param>
        /// <param name="updateDto">更新資料</param>
        /// <returns></returns>
        /// <response code="200">更新成功</response>
        /// <response code="500">更新失敗</response>
        /// <response code="401">驗證失敗</response>
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status401Unauthorized)]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, UpdateRoutingVersionDTO updateDto)
        {
            await _routingVersionService.UpdateAsync(id, updateDto);
            return Ok(GenericResponse<string>.Success(""));
        }
    }
}
