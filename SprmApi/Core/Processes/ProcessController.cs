using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using SprmApi.Common.Authorizations;
using SprmApi.Common.Paginations;
using SprmCommon.Response;
using SprmApi.Core.ObjectTypes;
using SprmApi.Core.Processes.Dto;
using SprmApi.MiddleWares;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SprmApi.Core.Processes
{
    /// <summary>
    /// 製程 controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [OpenApiTag("Process", Description = "製程")]
    public class ProcessController : ControllerBase
    {
        private readonly IProcessService _processService;

        private readonly PaginationData _paginationData;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="processService"></param>
        /// <param name="paginationData"></param>
        public ProcessController(
            IProcessService processService,
            PaginationData paginationData)
        {
            _processService = processService;
            _paginationData = paginationData;
        }

        /// <summary>
        /// 新增製程
        /// </summary>
        /// <param name="createDTO"></param>
        /// <returns></returns>
        /// <response code="200">新增成功</response>
        /// <response code="500">新增失敗</response>
        /// <response code="401">驗證失敗</response>
        [ProducesResponseType(typeof(GenericResponse<ProcessDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status401Unauthorized)]
        [RequirePermission(SprmObjectType.Process, Crud.Create)]
        [HttpPost]
        public async Task<IActionResult> Post(CreateProcessDto createDTO)
        {
            ProcessDto newProcess = await _processService.InsertAsync(createDTO);
            return Ok(GenericResponse<ProcessDto>.Success(newProcess));
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
        [ProducesResponseType(typeof(GenericResponse<IEnumerable<ProcessDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status401Unauthorized)]
        [RequirePermission(SprmObjectType.Process, Crud.Read)]
        [HttpGet("Search")]
        public async Task<IActionResult> FuzzySearch([FromQuery] string? pattern, [FromQuery] OffsetPaginationInput input)
        {
            OffsetPagination<ProcessDto> processesPagination = _processService.GetByPattern(pattern, input);
            List<ProcessDto> pagingList = await processesPagination.GetPagedListAsync();
            _paginationData.PaginationHeader = processesPagination.GetResponseHeader();
            return Ok(GenericResponse<IEnumerable<ProcessDto>>.Success(pagingList));
        }

        /// <summary>
        /// 刪除製程
        /// </summary>
        /// <param name="id">要刪除的製程id</param>
        /// <returns></returns>
        /// <response code="200">刪除成功</response>
        /// <response code="500">刪除失敗</response>
        /// <response code="401">驗證失敗</response>
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status401Unauthorized)]
        [RequirePermission(SprmObjectType.Process, Crud.Delete)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            await _processService.DeleteAsync(id);
            return Ok(GenericResponse<string>.Success(""));
        }

        /// <summary>
        /// 更新製程
        /// </summary>
        /// <param name="id">製程id</param>
        /// <param name="updateDTO">更新資料</param>
        /// <returns></returns>
        /// <response code="200">更新成功</response>
        /// <response code="500">更新失敗</response>
        /// <response code="401">驗證失敗</response>
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status401Unauthorized)]
        [RequirePermission(SprmObjectType.Process, Crud.Update)]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, UpdateProcessDto updateDTO)
        {
            await _processService.UpdateAsync(id, updateDTO);
            return Ok(GenericResponse<string>.Success(""));
        }

        /// <summary>
        /// 用id取得製程
        /// </summary>
        /// <param name="id">製程id</param>
        /// <returns></returns>
        /// <response code="200">搜尋成功</response>
        /// <response code="500">搜尋失敗</response>
        /// <response code="401">驗證失敗</response>
        [ProducesResponseType(typeof(GenericResponse<ProcessDto?>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status401Unauthorized)]
        [RequirePermission(SprmObjectType.Process, Crud.Read)]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            ProcessDto? process = await _processService.GetAsync(id);
            return Ok(GenericResponse<ProcessDto>.Success(process));
        }
    }
}
