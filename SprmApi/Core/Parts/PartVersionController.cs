using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using SprmApi.Common.Authorizations;
using SprmApi.Common.Paginations;
using SprmApi.Core.ObjectTypes;
using SprmApi.Core.Parts.Dto;
using SprmCommon.Response;

namespace SprmApi.Core.Parts
{
    /// <summary>
    /// 料件版本controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [OpenApiTag("PartVersion", Description = "料件版本")]
    public class PartVersionController : ControllerBase
    {
        private readonly IPartVersionService _partVersionService;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="partVersionService"></param>
        public PartVersionController(IPartVersionService partVersionService) => _partVersionService = partVersionService;

        /// <summary>
        /// 取得產品版本
        /// </summary>
        /// <param name="id">要取得的產品版本id</param>
        /// <returns></returns>
        /// <response code="200">取得成功</response>
        /// <response code="500">取得失敗</response>
        /// <response code="401">驗證失敗</response>
        [ProducesResponseType(typeof(GenericResponse<PartVersionDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status401Unauthorized)]
        [RequirePermission(SprmObjectType.PartVersion, Crud.Read)]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            PartVersion? partVersion = await _partVersionService.GetByIdAsync(id, true);
            return Ok(GenericResponse<PartVersionDto>.Success(PartVersionDto.Parse(partVersion)));
        }

        /// <summary>
        /// 更新產品版本資訊
        /// </summary>
        /// <param name="id">要更新的產品版本id</param>
        /// <param name="versionDTO">產品版本更新資訊</param>
        /// <returns></returns>
        /// <response code="200">更新成功</response>
        /// <response code="500">更新失敗</response>
        /// <response code="401">驗證失敗</response>
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status401Unauthorized)]
        [RequirePermission(SprmObjectType.PartVersion, Crud.Update)]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, UpdatePartVersionDto versionDTO)
        {
            await _partVersionService.UpdateAsync(id, versionDTO);
            return Ok(GenericResponse<string>.Success(string.Empty));
        }

        /// <summary>
        /// 取得指定料件的版本清單
        /// </summary>
        /// <param name="partId">料件id</param>
        /// <param name="input">分頁資訊</param>
        /// <returns></returns>
        /// <remarks>
        /// # 功能
        /// 此搜尋會依照傳入的料件id去搜尋所有版本資訊
        /// # 注意事項
        /// 1. 此API有分頁，請注意
        /// </remarks>
        /// <response code="200">取得成功</response>
        /// <response code="500">取得失敗</response>
        /// <response code="401">驗證失敗</response>
        [ProducesResponseType(typeof(GenericResponse<IEnumerable<PartVersionDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status401Unauthorized)]
        [RequirePermission(SprmObjectType.PartVersion, Crud.Read)]
        [HttpGet("~/api/Part/{partId}/PartVersion")]
        public async Task<IActionResult> GetPartVersions(long partId, [FromQuery] OffsetPaginationInput input)
        {
            IEnumerable<PartVersion> versions = await _partVersionService.GetPartVersions(partId, input);
            IEnumerable<PartVersionDto?> partVersionDTOs = versions.Select(version => PartVersionDto.Parse(version));
            return Ok(GenericResponse<IEnumerable<PartVersionDto?>>.Success(partVersionDTOs));
        }
    }
}
