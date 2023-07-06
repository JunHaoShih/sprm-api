using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using SprmApi.Common.Response;
using SprmApi.Core.ObjectTypes.Dto;

namespace SprmApi.Core.ObjectTypes
{
    /// <summary>
    /// 物件類型 controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [OpenApiTag("ObjectType", Description = "物件類型")]
    public class ObjectTypeController : ControllerBase
    {
        private readonly IObjectTypeService _objectTypeService;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="objectTypeService"></param>
        public ObjectTypeController(IObjectTypeService objectTypeService) => _objectTypeService = objectTypeService;

        /// <summary>
        /// 取得所有物件類型
        /// </summary>
        /// <returns></returns>
        /// <response code="200">取得成功</response>
        /// <response code="500">取得失敗</response>
        /// <response code="401">驗證失敗</response>
        [ProducesResponseType(typeof(GenericResponse<IEnumerable<ObjectTypeDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status401Unauthorized)]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var objectTypes = await _objectTypeService.GetAllAsync();
            var objectTypeDTOs = objectTypes.Select(objType => ObjectTypeDto.Parse(objType));
            return Ok(GenericResponse<IEnumerable<ObjectTypeDto>>.Success(objectTypeDTOs));
        }
    }
}
