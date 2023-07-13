using System.Text.Json;

namespace SprmApi.MiddleWares
{
    /// <summary>
    /// 
    /// </summary>
    public class PaginationMiddleware
    {
        private readonly RequestDelegate _next;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="next"></param>
        public PaginationMiddleware(RequestDelegate next) => _next = next;

        /// <summary>
        /// Middleware action
        /// </summary>
        /// <param name="context"></param>
        /// <param name="paginationData"></param>
        /// <returns></returns>
        public async Task InvokeAsync(HttpContext context, PaginationData paginationData)
        {
            context.Response.OnStarting((state) =>
            {
                if (paginationData.PaginationHeader != null)
                {
                    var httpContext = (HttpContext)state;
                    var serializeOptions = new JsonSerializerOptions
                    {
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    };
                    var responseJson = JsonSerializer.Serialize(paginationData.PaginationHeader, serializeOptions);
                    httpContext.Response.Headers.Add("X-Pagination", new[] { responseJson });
                }
                return Task.CompletedTask;
            }, context);
            await _next(context);
        }
    }

    /// <summary>
    /// 將UseHeaderVerify extend 到 IApplicationBuilder
    /// </summary>
    public static class PaginationMiddlewareExtensions
    {
        /// <summary>
        /// 使用驗證Header資料的middleware
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static IApplicationBuilder UsePagination(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<PaginationMiddleware>();
        }
    }
}
