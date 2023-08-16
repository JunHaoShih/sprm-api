using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using SprmApi.Common.Authorizations;
using SprmCommon.Response;
using SprmApi.Core.ObjectTypes;
using SprmApi.Core.RoutingUsages.Dto;

namespace SprmApi.Core.RoutingUsages
{
    /// <summary>
    /// 工藝路徑使用關係 controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [OpenApiTag("RoutingUsage", Description = "工藝路徑使用關係")]
    public class RoutingUsageController : ControllerBase
    {
        private readonly IRoutingUsageService _routingUsageService;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="routingUsageService"></param>
        public RoutingUsageController(IRoutingUsageService routingUsageService)
        {
            _routingUsageService = routingUsageService;
        }

        /// <summary>
        /// 新增工藝路徑使用關係
        /// </summary>
        /// <param name="createDto"></param>
        /// <returns></returns>
        /// <response code="200">新增成功</response>
        /// <response code="500">新增失敗</response>
        /// <response code="401">驗證失敗</response>
        [ProducesResponseType(typeof(GenericResponse<RoutingUsageDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status401Unauthorized)]
        [RequirePermission(SprmObjectType.RoutingUsage, Crud.Create)]
        [HttpPost]
        public async Task<IActionResult> Post(CreateRoutingUsageDto createDto)
        {
            RoutingUsageDto newUsage = await _routingUsageService.InsertAsync(createDto);
            return Ok(GenericResponse<RoutingUsageDto>.Success(newUsage));
        }

        /// <summary>
        /// 取得工藝路徑版本的所有工藝路徑使用關係
        /// </summary>
        /// <param name="id">工藝路徑版本id</param>
        /// <returns></returns>
        /// <response code="200">搜尋成功</response>
        /// <response code="500">搜尋失敗</response>
        /// <response code="401">驗證失敗</response>
        [ProducesResponseType(typeof(GenericResponse<IEnumerable<RoutingUsageDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status401Unauthorized)]
        [RequirePermission(SprmObjectType.RoutingUsage, Crud.Read)]
        [HttpGet("~/api/RoutingVersion/{id}/RoutingUsage")]
        public async Task<IActionResult> GetByRootVersionId(long id)
        {
            IEnumerable<RoutingUsageDto> usages = await _routingUsageService.GetByRootVersionIdAsync(id);
            return Ok(GenericResponse<IEnumerable<RoutingUsageDto>>.Success(usages));
        }

        /// <summary>
        /// 用id刪除工藝路徑使用關係
        /// </summary>
        /// <param name="id">工藝路徑使用關係id</param>
        /// <returns></returns>
        /// <response code="200">刪除成功</response>
        /// <response code="500">刪除失敗</response>
        /// <response code="401">驗證失敗</response>
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status401Unauthorized)]
        [RequirePermission(SprmObjectType.RoutingUsage, Crud.Delete)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            await _routingUsageService.DeleteAsync(id);
            return Ok(GenericResponse<string>.Success(""));
        }

        /// <summary>
        /// 更新工藝路徑使用關係
        /// </summary>
        /// <param name="id">工藝路徑使用關係id</param>
        /// <param name="dto">更新資料</param>
        /// <returns></returns>
        /// <response code="200">更新成功</response>
        /// <response code="500">更新失敗</response>
        /// <response code="401">驗證失敗</response>
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status401Unauthorized)]
        [RequirePermission(SprmObjectType.RoutingUsage, Crud.Update)]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateById(long id, UpdateRoutingUsageDto dto)
        {
            await _routingUsageService.UpdateById(id, dto);
            return Ok(GenericResponse<string>.Success(""));
        }
    }
}
