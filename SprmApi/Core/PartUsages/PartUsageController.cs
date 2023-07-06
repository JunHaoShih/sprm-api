using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using SprmApi.Common.Response;
using SprmApi.Core.PartUsages.Dto;

namespace SprmApi.Core.PartUsages
{
    /// <summary>
    /// Part usage controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [OpenApiTag("PartUsage", Description = "料件使用關係")]
    public class PartUsageController : ControllerBase
    {
        private readonly IPartUsageService _partUsageService;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="partUsageService"></param>
        public PartUsageController(IPartUsageService partUsageService)
        {
            _partUsageService = partUsageService;
        }

        /// <summary>
        /// 建立多筆料件使用關係
        /// </summary>
        /// <param name="usagesDTO">建立資料</param>
        /// <returns></returns>
        /// <returns></returns>
        /// <response code="200">建立成功</response>
        /// <response code="500">建立失敗</response>
        /// <response code="401">驗證失敗</response>
        [ProducesResponseType(typeof(GenericResponse<IEnumerable<PartUsageUsesDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status401Unauthorized)]
        [HttpPost]
        public async Task<IActionResult> Post(CreatePartUsagesDto usagesDTO)
        {
            IEnumerable<PartUsage> newUsages = await _partUsageService.InsertAsync(usagesDTO);
            IEnumerable<PartUsageUsesDto> newUsageDTOs = newUsages.Select(usage => PartUsageUsesDto.Parse(usage)!);
            return Ok(GenericResponse<IEnumerable<PartUsageUsesDto>>.Success(newUsageDTOs));
        }

        /// <summary>
        /// 用父料件版本id取得其使用的料件
        /// </summary>
        /// <param name="id">父料件版本id</param>
        /// <returns></returns>
        /// <response code="200">搜尋成功</response>
        /// <response code="500">搜尋失敗</response>
        /// <response code="401">驗證失敗</response>
        [ProducesResponseType(typeof(GenericResponse<IEnumerable<PartUsageUsesDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status401Unauthorized)]
        [HttpGet("ByParent/{id}")]
        public async Task<IActionResult> GetByParentId(long id)
        {
            IEnumerable<PartUsage> usages = await _partUsageService.GetByPartVersionIdAsync(id);
            IEnumerable<PartUsageUsesDto> usageDTOs = usages.Select(usage => PartUsageUsesDto.Parse(usage)!);
            return Ok(GenericResponse<IEnumerable<PartUsageUsesDto>>.Success(usageDTOs));
        }

        /// <summary>
        /// 用使用關係id取得料件使用關係
        /// </summary>
        /// <param name="id">得料件使用關係id</param>
        /// <returns></returns>
        /// <response code="200">搜尋成功</response>
        /// <response code="500">搜尋失敗</response>
        /// <response code="401">驗證失敗</response>
        [ProducesResponseType(typeof(GenericResponse<PartUsageUsesDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status401Unauthorized)]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            PartUsage? usage = await _partUsageService.GetById(id);
            return Ok(GenericResponse<PartUsageUsesDto>.Success(PartUsageUsesDto.Parse(usage)));
        }

        /// <summary>
        /// 用使用關係id刪除料件使用關係
        /// </summary>
        /// <param name="id">得料件使用關係id</param>
        /// <returns></returns>
        /// <response code="200">刪除成功</response>
        /// <response code="500">刪除失敗</response>
        /// <response code="401">驗證失敗</response>
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status401Unauthorized)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteById(long id)
        {
            await _partUsageService.DeleteById(id);
            return Ok(GenericResponse<string>.Success(""));
        }
        /// <summary>
        /// 更新使用關係
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updateDto"></param>
        /// <returns></returns>
        /// <response code="200">更新成功</response>
        /// <response code="500">更新失敗</response>
        /// <response code="401">更新失敗</response>
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status401Unauthorized)]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateById(long id, UpdatePartUsageDto updateDto)
        {
            await _partUsageService.UpdateById(id, updateDto);
            return Ok(GenericResponse<string>.Success(""));
        }
    }
}
