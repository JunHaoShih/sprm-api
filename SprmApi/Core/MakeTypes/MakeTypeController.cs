using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NSwag.Annotations;
using SprmApi.Common.Response;
using SprmApi.Core.MakeTypes.Dto;

namespace SprmApi.Core.MakeTypes
{
    /// <summary>
    /// 製造類型controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [OpenApiTag("MakeType", Description = "製造類型")]
    public class MakeTypeController : ControllerBase
    {
        private readonly IMakeTypeService _makeTypeService;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="makeTypeService"></param>
        public MakeTypeController(IMakeTypeService makeTypeService) => _makeTypeService = makeTypeService;

        /// <summary>
        /// 取得所有製造類型
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// # 功能
        /// 取得所有製造類型
        /// </remarks>
        /// <response code="200">搜尋成功</response>
        /// <response code="500">搜尋失敗</response>
        /// <response code="401">驗證失敗</response>
        [ProducesResponseType(typeof(GenericResponse<IEnumerable<MakeTypeDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status401Unauthorized)]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            List<MakeTypeDto> dtos = await _makeTypeService.GetAll().ToListAsync();
            return Ok(GenericResponse<List<MakeTypeDto>>.Success(dtos));
        }
    }
}
