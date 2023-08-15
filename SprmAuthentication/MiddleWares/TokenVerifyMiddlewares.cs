using SprmAuthentication.Settings;
using SprmCommon.Authentications;
using SprmCommon.Error;
using SprmCommon.Exceptions;
using SprmCommon.MiddleWares;
using SprmCommon.Response;

namespace SprmAuthentication.MiddleWares
{
    /// <summary>
    /// Middleware used to handle token
    /// </summary>
    public class TokenVerifyMiddlewares
    {
        private readonly RequestDelegate _next;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="next"></param>
        public TokenVerifyMiddlewares(RequestDelegate next) => _next = next;

        /// <summary>
        /// Middleware action
        /// </summary>
        /// <param name="context"></param>
        /// <param name="httpHeader"></param>
        /// <param name="settings"></param>
        /// <returns></returns>
        public async Task InvokeAsync(HttpContext context, HeaderData httpHeader, ApiSettings settings)
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
                JwtAccessPayload payload = JwtBasePayload.DecryptToken<JwtAccessPayload>(httpHeader.Bearer, settings.JwtSettings.InnerSignKey);
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
            response.StatusCode = statusCode;
            response.ContentType = "application/json";
            var responseObj = new GenericResponse<string>()
            {
                Code = code,
                Message = code.GetMessage(),
                Content = message,
            };
            await response.WriteAsJsonAsync(responseObj);
        }
    }

    /// <summary>
    /// 將UseHeaderVerify extend 到 IApplicationBuilder
    /// </summary>
    public static class TokenVerifyMiddlewareExtensions
    {
        /// <summary>
        /// 使用驗證Header資料的middleware
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseTokenVerify(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<TokenVerifyMiddlewares>();
        }
    }
}
