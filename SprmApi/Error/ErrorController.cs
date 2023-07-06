using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Npgsql;
using SprmApi.Common.Error;
using SprmApi.Common.Exceptions;
using SprmApi.Common.Response;

namespace SprmApi.Error
{
    /// <summary>
    /// Error handling controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ErrorController : ControllerBase
    {
        private readonly ILogger logger;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="logger"></param>
        public ErrorController(ILogger<ErrorController> logger) => this.logger = logger;

        /// <summary>
        /// Where all the errors handled
        /// </summary>
        /// <returns></returns>
        public ActionResult<GenericResponse<string>> Error()
        {
            var context = HttpContext.Features.Get<IExceptionHandlerFeature>();
            var exception = context!.Error;
            int statusCode = StatusCodes.Status500InternalServerError;

            GenericResponse<string> apiErrorMessage = new GenericResponse<string>();

            if (exception is SPRMAuthException)
            {
                var apiException = (SPRMAuthException)exception;
                apiErrorMessage = new GenericResponse<string>
                {
                    Code = apiException.Code,
                    Message = apiException.Message,
                    Content = apiException.Content
                };
                statusCode = StatusCodes.Status401Unauthorized;
            }
            else if (exception is SPRMException)
            {
                var apiException = (SPRMException)exception;
                apiErrorMessage = new GenericResponse<string>
                {
                    Code = apiException.Code,
                    Message = apiException.Message,
                    Content = apiException.Content
                };
            }
            else if (exception.GetBaseException() is PostgresException)
            {
                apiErrorMessage = HandlePostgresException((PostgresException)exception.GetBaseException());
            }
            else
            {
                apiErrorMessage = new GenericResponse<string>
                {
                    Code = ErrorCode.Error,
                    Message = ErrorCode.Error.GetMessage(),
                    Content = exception.Message
                };
            }
            logger.LogError(exception, exception.Message);

            return StatusCode(statusCode, apiErrorMessage);
        }

        /// <summary>
		/// 專門處理PostgresException
		/// </summary>
		/// <param name="exception"></param>
		/// <returns></returns>
		private GenericResponse<string> HandlePostgresException(PostgresException exception)
        {
            GenericResponse<string> apiErrorMessage = new GenericResponse<string>();

            if (exception.SqlState == "23505")
            {
                apiErrorMessage = new GenericResponse<string>
                {
                    Code = ErrorCode.DbInsertDuplicate,
                    Message = ErrorCode.DbInsertDuplicate.GetMessage(),
                    Content = exception.ToString()
                };
            }
            else if (exception.SqlState == "23503")
            {
                apiErrorMessage = new GenericResponse<string>
                {
                    Code = ErrorCode.DbForeignKeyViolation,
                    Message = ErrorCode.DbForeignKeyViolation.GetMessage(),
                    Content = exception.ToString()
                };
            }
            else
            {
                apiErrorMessage = new GenericResponse<string>
                {
                    Code = ErrorCode.DbError,
                    Message = ErrorCode.DbError.GetMessage(),
                    Content = exception.ToString()
                };
            }
            return apiErrorMessage;
        }
    }
}
