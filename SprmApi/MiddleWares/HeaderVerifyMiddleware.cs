using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using SprmApi.Common.Error;
using SprmApi.Common.Exceptions;
using SprmApi.Common.Response;
using SprmApi.Core.Auth;

namespace SprmApi.MiddleWares
{
    /// <summary>
    /// Middleware for header verify
    /// </summary>
    public class HeaderVerifyMiddleware
    {
        private readonly RequestDelegate _next;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="next"></param>
        public HeaderVerifyMiddleware(RequestDelegate next) => _next = next;

        /// <summary>
        /// Middleware action
        /// </summary>
        /// <param name="context"></param>
        /// <param name="httpHeader"></param>
        /// <param name="jWTService"></param>
        /// <returns></returns>
        public async Task InvokeAsync(HttpContext context, HeaderData httpHeader, JwtService jWTService)
        {
            try
            {
                string? bearerToken = context.Request.Headers["Authorization"];
                if (string.IsNullOrWhiteSpace(bearerToken))
                {
                    await SetResponse(context.Response, 401, ErrorCode.InvalidToken, "No token found!");
                    return;
                }
                else
                {
                    httpHeader.Bearer = bearerToken.Split(' ')[1];
                }
                JwtPayload payload = jWTService.DecryptToken(httpHeader.Bearer);
                httpHeader.JWTPayload = payload;
            }
            catch (SprmAuthException e)
            {
                await SetResponse(context.Response, 401, e.Code, e.Content);
                return;
            }
            catch (Exception e)
            {
                await SetResponse(context.Response, 401, ErrorCode.Error, e.ToString());
                return;
            }
            await _next(context);
        }

        private static async Task SetResponse(HttpResponse response, int statusCode, ErrorCode code, string message)
        {
            DefaultContractResolver contractResolver = new DefaultContractResolver
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };
            response.StatusCode = statusCode;
            response.ContentType = "application/json";
            var responseObj = new GenericResponse<string>()
            {
                Code = code,
                Message = code.GetMessage(),
                Content = message,
            };
            var responseJson = JsonConvert.SerializeObject(responseObj, new JsonSerializerSettings
            {
                ContractResolver = contractResolver
            });
            await response.WriteAsync(responseJson);
        }
    }

    /// <summary>
    /// 將UseHeaderVerify extend 到 IApplicationBuilder
    /// </summary>
    public static class HeaderVerifyMiddlewareExtensions
    {
        /// <summary>
        /// 使用驗證Header資料的middleware
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseHeaderVerify(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<HeaderVerifyMiddleware>();
        }
    }
}
