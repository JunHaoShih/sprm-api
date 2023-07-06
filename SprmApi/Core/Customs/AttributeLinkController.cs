using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using SprmApi.Common.Response;
using SprmApi.Common.Validations;
using SprmApi.Core.Customs.Dto;
using SprmApi.Core.ObjectTypes;

namespace SprmApi.Core.Customs
{
    /// <summary>
    /// 自定屬性關聯controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [OpenApiTag("AttributeLink", Description = "自定屬性關聯")]
    public class AttributeLinkController : ControllerBase
    {
        private readonly IAttributeLinkService _attributeLinkService;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="attributeLinkService"></param>
        public AttributeLinkController(IAttributeLinkService attributeLinkService) => _attributeLinkService = attributeLinkService;

        /// <summary>
        /// 取得物件類型對應屬性
        /// </summary>
        /// <param name="objectTypeId"></param>
        /// <returns></returns>
        /// <response code="200">新增自訂屬性成功</response>
        /// <response code="500">新增自訂屬性失敗</response>
        /// <response code="401">驗證失敗</response>
        [ProducesResponseType(typeof(GenericResponse<AttributeLinksDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status401Unauthorized)]
        [HttpGet("ByObjectType")]
        public async Task<IActionResult> GetByObjectType([Required][EnumValidation] SprmObjectType objectTypeId)
        {
            var links = await _attributeLinkService.GetByObjectTypeIdAsync(objectTypeId);
            return Ok(GenericResponse<AttributeLinksDto>.Success(AttributeLinksDto.Parse(objectTypeId, links)));
        }

        /// <summary>
        /// 新增一到多筆自定屬性關聯
        /// </summary>
        /// <param name="createDTO"></param>
        /// <returns></returns>
        /// <response code="200">新增自定屬性關聯成功</response>
        /// <response code="500">新增自定屬性關聯失敗</response>
        /// <response code="401">驗證失敗</response>
        [ProducesResponseType(typeof(GenericResponse<AttributeLinksDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status401Unauthorized)]
        [HttpPost]
        public async Task<IActionResult> Post(CreateAttributeLinksDto createDTO)
        {
            var newLink = await _attributeLinkService.Insert(createDTO);
            return Ok(GenericResponse<AttributeLinksDto>.Success(AttributeLinksDto.Parse(createDTO.ObjectTypeId, newLink)));
        }

        /// <summary>
        /// 刪除一到多筆自定屬性關聯
        /// </summary>
        /// <param name="deleteDTO"></param>
        /// <returns></returns>
        /// <response code="200">刪除自定屬性關聯成功</response>
        /// <response code="500">刪除自定屬性關聯失敗</response>
        /// <response code="401">驗證失敗</response>
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status401Unauthorized)]
        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteAttributeLinksDto deleteDTO)
        {
            await _attributeLinkService.DeleteAsync(deleteDTO);
            return Ok(GenericResponse<string>.Success(string.Empty));
        }
    }
}
