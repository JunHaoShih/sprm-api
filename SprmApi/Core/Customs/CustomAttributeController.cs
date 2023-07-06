using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using SprmApi.Common.Response;
using SprmApi.Core.Customs.Dto;

namespace SprmApi.Core.Customs
{
    /// <summary>
    /// 自定屬性
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [OpenApiTag("CustomAttribute", Description = "自定屬性")]
    public class CustomAttributeController : ControllerBase
    {
        private readonly ICustomAttributeService _customAttributeService;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="customAttributeService"></param>
        public CustomAttributeController(ICustomAttributeService customAttributeService) => _customAttributeService = customAttributeService;

        /// <summary>
        /// 取得所有自定屬性
        /// </summary>
        /// <returns></returns>
        /// <response code="200">取得自訂屬性成功</response>
        /// <response code="500">取得自訂屬性失敗</response>
        /// <response code="401">驗證失敗</response>
        [ProducesResponseType(typeof(GenericResponse<IEnumerable<CustomAttributeDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status401Unauthorized)]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var attributes = await _customAttributeService.GetAllAsync();
            var attributeDTOs = attributes.Select(attr => CustomAttributeDto.Parse(attr));
            return Ok(GenericResponse<IEnumerable<CustomAttributeDto>>.Success(attributeDTOs));
        }

        /// <summary>
        /// 新增一筆自定屬性
        /// </summary>
        /// <param name="createDTO"></param>
        /// <returns></returns>
        /// <response code="200">新增自訂屬性成功</response>
        /// <response code="500">新增自訂屬性失敗</response>
        /// <response code="401">驗證失敗</response>
        [ProducesResponseType(typeof(GenericResponse<CustomAttributeDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status401Unauthorized)]
        [HttpPost]
        public async Task<IActionResult> Create(CreateCustomAttributeDto createDTO)
        {
            var customAttribute = await _customAttributeService.InsertAsync(createDTO);
            return Ok(GenericResponse<CustomAttributeDto>.Success(CustomAttributeDto.Parse(customAttribute)));
        }

        /// <summary>
        /// 更新一筆自定屬性
        /// </summary>
        /// <param name="id">自定屬性id</param>
        /// <param name="updateDTO">更新物件</param>
        /// <returns></returns>
        /// <response code="200">更新自訂屬性成功</response>
        /// <response code="500">更新自訂屬性失敗</response>
        /// <response code="401">驗證失敗</response>
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status401Unauthorized)]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, UpdateCustomAttributeDto updateDTO)
        {
            await _customAttributeService.UpdateAsync(id, updateDTO);
            return Ok(GenericResponse<string>.Success(""));
        }

        /// <summary>
        /// 刪除一筆自定屬性
        /// </summary>
        /// <param name="id">要刪除的自定屬性id</param>
        /// <returns></returns>
        /// <response code="200">刪除自訂屬性成功</response>
        /// <response code="500">刪除自訂屬性失敗</response>
        /// <response code="401">驗證失敗</response>
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status401Unauthorized)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            await _customAttributeService.DeleteAsync(id);
            return Ok(GenericResponse<string>.Success(""));
        }
    }
}
