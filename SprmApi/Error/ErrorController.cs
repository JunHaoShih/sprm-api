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
        private readonly ILogger _logger;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="logger"></param>
        public ErrorController(ILogger<ErrorController> logger) => _logger = logger;

        /// <summary>
        /// Where all the errors handled
        /// </summary>
        /// <returns></returns>
        public ActionResult<GenericResponse<string>> Error()
        {
            IExceptionHandlerFeature? context = HttpContext.Features.Get<IExceptionHandlerFeature>();
            Exception exception = context!.Error;
            int statusCode = StatusCodes.Status500InternalServerError;

            GenericResponse<string> apiErrorMessage;

            if (exception is SprmAuthException authException)
            {
                apiErrorMessage = new GenericResponse<string>
                {
                    Code = authException.Code,
                    Message = authException.Message,
                    Content = authException.Content
                };
                statusCode = StatusCodes.Status401Unauthorized;
            }
            else if (exception is SprmException baseException)
            {
                apiErrorMessage = new GenericResponse<string>
                {
                    Code = baseException.Code,
                    Message = baseException.Message,
                    Content = baseException.Content
                };
            }
            else if (exception.GetBaseException() is PostgresException pgException)
            {
                apiErrorMessage = HandlePostgresException(pgException);
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
            _logger.LogError(exception, "Error catched by error handler: {Message}", exception.Message);

            return StatusCode(statusCode, apiErrorMessage);
        }

        /// <summary>
		/// 專門處理PostgresException
		/// </summary>
		/// <param name="exception"></param>
		/// <returns></returns>
		private static GenericResponse<string> HandlePostgresException(PostgresException exception)
        {
            GenericResponse<string> apiErrorMessage;

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
