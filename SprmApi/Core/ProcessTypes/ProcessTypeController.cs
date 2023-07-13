using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NSwag.Annotations;
using SprmApi.Common.Authorizations;
using SprmApi.Common.Response;
using SprmApi.Core.ObjectTypes;
using SprmApi.Core.ProcessTypes.Dto;

namespace SprmApi.Core.ProcessTypes
{
    /// <summary>
    /// 製程類型controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [OpenApiTag("ProcessType", Description = "製程類型")]
    public class ProcessTypeController : ControllerBase
    {
        private readonly IProcessTypeService _processTypeService;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="processTypeService"></param>
        public ProcessTypeController(IProcessTypeService processTypeService) => _processTypeService = processTypeService;

        /// <summary>
        /// 取得所有製程類型
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// # 功能
        /// 取得所有製程類型
        /// </remarks>
        /// <response code="200">搜尋成功</response>
        /// <response code="500">搜尋失敗</response>
        /// <response code="401">驗證失敗</response>
        [ProducesResponseType(typeof(GenericResponse<IEnumerable<ProcessTypeDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status401Unauthorized)]
        [RequirePermission(SprmObjectType.Process, Crud.Read)]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            List<ProcessTypeDto> dtos = await _processTypeService.GetAll().ToListAsync();
            return Ok(GenericResponse<IEnumerable<ProcessTypeDto>>.Success(dtos));
        }
    }
}
