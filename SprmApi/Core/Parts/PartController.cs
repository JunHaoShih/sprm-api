using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using SprmApi.Common.Paginations;
using SprmApi.Common.Response;
using SprmApi.Core.Parts.DTOs;

namespace SprmApi.Core.Parts
{
    /// <summary>
    /// 料件controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [OpenApiTag("Part", Description = "料件")]
    public class PartController : ControllerBase
    {
        private readonly IPartService _partService;

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="partService"></param>
        public PartController(IPartService partService) => _partService = partService;

        /// <summary>
        /// 新增料件
        /// </summary>
        /// <param name="createPartDTO"></param>
        /// <returns></returns>
        /// <response code="200">新增成功</response>
        /// <response code="500">新增失敗</response>
        /// <response code="401">驗證失敗</response>
        [ProducesResponseType(typeof(GenericResponse<PartDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status401Unauthorized)]
        [HttpPost]
        public async Task<IActionResult> Create(CreatePartDto createPartDTO)
        {
            Part part = await _partService.InsertAsync(createPartDTO);
            return Ok(GenericResponse<PartDto>.Success(PartDto.Parse(part)));
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
        [ProducesResponseType(typeof(GenericResponse<IEnumerable<PartDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status401Unauthorized)]
        [HttpGet("Search")]
        public async Task<IActionResult> FuzzySearch([FromQuery] string? pattern, [FromQuery] OffsetPaginationInput input)
        {
            var parts = await _partService.GetByPatternAsync(pattern, input);
            var partDTOs = parts.Select(part => PartDto.Parse(part)!);
            return Ok(GenericResponse<IEnumerable<PartDto>>.Success(partDTOs));
        }

        /// <summary>
        /// 用id取得料件
        /// </summary>
        /// <param name="id">料件id</param>
        /// <returns></returns>
        /// <response code="200">搜尋成功</response>
        /// <response code="500">搜尋失敗</response>
        /// <response code="401">驗證失敗</response>
        [ProducesResponseType(typeof(GenericResponse<PartDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status401Unauthorized)]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            Part? part = await _partService.GetByIdAsync(id);
            return Ok(GenericResponse<PartDto>.Success(PartDto.Parse(part)));
        }

        /// <summary>
        /// 刪除料件
        /// </summary>
        /// <param name="id">料件id</param>
        /// <returns></returns>
        /// <response code="200">刪除成功</response>
        /// <response code="500">刪除失敗</response>
        /// <response code="401">驗證失敗</response>
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status401Unauthorized)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            await _partService.DeleteAsync(id);
            return Ok(GenericResponse<string>.Success(""));
        }

        /// <summary>
        /// 簽出料件
        /// </summary>
        /// <param name="id">料件id</param>
        /// <returns></returns>
        /// <response code="200">簽出成功</response>
        /// <response code="500">簽出失敗</response>
        /// <response code="401">驗證失敗</response>
        [ProducesResponseType(typeof(GenericResponse<PartDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status401Unauthorized)]
        [HttpPost("{id}/CheckOut")]
        public async Task<IActionResult> CheckOut(long id)
        {
            Part checkout = await _partService.CheckOutAsync(id);
            return Ok(GenericResponse<PartDto>.Success(PartDto.Parse(checkout)));
        }

        /// <summary>
        /// 簽入料件
        /// </summary>
        /// <param name="id">料件id</param>
        /// <returns></returns>
        /// <response code="200">簽入成功</response>
        /// <response code="500">簽入失敗</response>
        /// <response code="401">驗證失敗</response>
        [ProducesResponseType(typeof(GenericResponse<PartDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status401Unauthorized)]
        [HttpPost("{id}/CheckIn")]
        public async Task<IActionResult> CheckIn(long id)
        {
            Part checkin = await _partService.CheckInAsync(id);
            return Ok(GenericResponse<PartDto>.Success(PartDto.Parse(checkin)));
        }

        /// <summary>
        /// 捨棄簽出資訊
        /// </summary>
        /// <param name="id">料件id</param>
        /// <returns></returns>
        /// <response code="200">捨棄簽出成功</response>
        /// <response code="500">捨棄簽出失敗</response>
        /// <response code="401">驗證失敗</response>
        [ProducesResponseType(typeof(GenericResponse<PartDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status401Unauthorized)]
        [HttpDelete("{id}/Discard")]
        public async Task<IActionResult> Discard(long id)
        {
            Part checkin = await _partService.DiscardAsync(id);
            return Ok(GenericResponse<PartDto>.Success(PartDto.Parse(checkin)));
        }
    }
}
