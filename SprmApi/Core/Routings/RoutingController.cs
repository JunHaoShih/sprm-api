using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using SprmApi.Common.Paginations;
using SprmApi.Common.Response;
using SprmApi.Core.Routings.DTOs;
using SprmApi.MiddleWares;

namespace SprmApi.Core.Routings
{
    /// <summary>
    /// 工藝路徑 controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [OpenApiTag("Routing", Description = "工藝路徑")]
    public class RoutingController : ControllerBase
    {
        private readonly IRoutingService _routingService;

        private readonly PaginationData _paginationData;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="routingService"></param>
        /// <param name="paginationData"></param>
        public RoutingController(IRoutingService routingService, PaginationData paginationData)
        {
            _routingService = routingService;
            _paginationData = paginationData;
        }

        /// <summary>
        /// 新增工藝路徑
        /// </summary>
        /// <param name="createDTO"></param>
        /// <returns></returns>
        /// <response code="200">新增成功</response>
        /// <response code="500">新增失敗</response>
        /// <response code="401">驗證失敗</response>
        [ProducesResponseType(typeof(GenericResponse<RoutingDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status401Unauthorized)]
        [HttpPost]
        public async Task<IActionResult> CreateRouting(CreateRoutingDto createDTO)
        {
            RoutingDto newRouting = await _routingService.InsertAsync(createDTO);
            return Ok(GenericResponse<RoutingDto>.Success(newRouting));
        }

        /// <summary>
        /// 用id取得工藝路徑
        /// </summary>
        /// <param name="id">工藝路徑id</param>
        /// <returns></returns>
        /// <response code="200">取得成功</response>
        /// <response code="500">取得失敗</response>
        /// <response code="401">驗證失敗</response>
        [ProducesResponseType(typeof(GenericResponse<RoutingDto?>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status401Unauthorized)]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            RoutingDto? routing = await _routingService.GetByIdAsync(id);
            return Ok(GenericResponse<RoutingDto?>.Success(routing));
        }

        /// <summary>
        /// 取得指定料件的工藝路徑清單
        /// </summary>
        /// <param name="partId">料件id</param>
        /// <param name="input">offset分頁資訊</param>
        /// <returns></returns>
        /// <response code="200">取得成功</response>
        /// <response code="500">取得失敗</response>
        /// <response code="401">驗證失敗</response>
        /// <remarks>此API有分頁，請注意</remarks>
        [ProducesResponseType(typeof(GenericResponse<IEnumerable<RoutingDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status401Unauthorized)]
        [HttpGet("~/api/Part/{partId}/Routing")]
        public async Task<IActionResult> GetByPartId(long partId, [FromQuery] OffsetPaginationInput input)
        {
            OffsetPagination<RoutingDto> routingsPagination = _routingService.GetByPartIdAsync(partId, input);
            List<RoutingDto> pagingList = await routingsPagination.GetPagedListAsync();
            _paginationData.PaginationHeader = routingsPagination.GetResponseHeader();
            return Ok(GenericResponse<IEnumerable<RoutingDto>>.Success(pagingList));
        }

        /// <summary>
        /// 簽出工藝路徑
        /// </summary>
        /// <param name="id">工藝路徑id</param>
        /// <returns></returns>
        /// <response code="200">簽出成功</response>
        /// <response code="500">簽出失敗</response>
        /// <response code="401">驗證失敗</response>
        /// <remarks>此API有分頁，請注意</remarks>
        [ProducesResponseType(typeof(GenericResponse<RoutingDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status401Unauthorized)]
        [HttpPost("{id}/CheckOut")]
        public async Task<IActionResult> CheckOut(long id)
        {
            RoutingDto routingDTO = await _routingService.CheckOutAsync(id);
            return Ok(GenericResponse<RoutingDto>.Success(routingDTO));
        }

        /// <summary>
        /// 簽入工藝路徑
        /// </summary>
        /// <param name="id">工藝路徑id</param>
        /// <returns></returns>
        /// <response code="200">簽入成功</response>
        /// <response code="500">簽入失敗</response>
        /// <response code="401">驗證失敗</response>
        /// <remarks>此API有分頁，請注意</remarks>
        [ProducesResponseType(typeof(GenericResponse<RoutingDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status401Unauthorized)]
        [HttpPost("{id}/CheckIn")]
        public async Task<IActionResult> CheckIn(long id)
        {
            RoutingDto routingDTO = await _routingService.CheckInAsync(id);
            return Ok(GenericResponse<RoutingDto>.Success(routingDTO));
        }

        /// <summary>
        /// 捨棄簽出的工藝路徑
        /// </summary>
        /// <param name="id">工藝路徑id</param>
        /// <returns></returns>
        /// <response code="200">捨棄成功</response>
        /// <response code="500">捨棄失敗</response>
        /// <response code="401">驗證失敗</response>
        /// <remarks>此API有分頁，請注意</remarks>
        [ProducesResponseType(typeof(GenericResponse<RoutingDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status401Unauthorized)]
        [HttpDelete("{id}/Discard")]
        public async Task<IActionResult> Discard(long id)
        {
            RoutingDto routingDTO = await _routingService.DiscardAsync(id);
            return Ok(GenericResponse<RoutingDto>.Success(routingDTO));
        }
    }
}
