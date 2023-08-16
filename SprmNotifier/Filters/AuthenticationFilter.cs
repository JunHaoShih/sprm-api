using Jose;
using Microsoft.AspNetCore.SignalR;
using System.Text;
using System.Text.Json;

namespace SprmNotifier.Filters
{
    public class AuthenticationFilter : IHubFilter
    {
        private readonly Settings.JwtSettings _settings;

        public AuthenticationFilter(Settings.JwtSettings settings)
        {
            _settings = settings;
        }

        public Task OnConnectedAsync(HubLifetimeContext context, Func<HubLifetimeContext, Task> next)
        {
            HttpContext? httpCtx = context.Context.GetHttpContext();
            if (httpCtx == null)
            {
                context.Context.Abort();
                return Task.CompletedTask;
            }

            string? bearer = httpCtx.Request.Headers["Authorization"];
            if (string.IsNullOrWhiteSpace(bearer))
            {
                context.Context.Abort();
                return Task.CompletedTask;
            }
            try
            {
                string token = bearer.Split(' ')[1];
                JwtBasePayload payload = DecryptToken<JwtBasePayload>(token, _settings.SignKey);
                httpCtx.Request.Headers["Subject"] = payload.Subject;
            }
            catch (Exception ex)
            {
                context.Hub.Clients.Client(context.Context.ConnectionId).SendAsync("Error", "So buggy~~~").Wait();
                context.Context.Abort();
                return Task.CompletedTask;
            }
            return next(context);
        }

        public static T DecryptToken<T>(string token, string signKey) where T : JwtBasePayload
        {
            string json = JWT.Decode(token, Encoding.UTF8.GetBytes(signKey), JwsAlgorithm.HS256);
            T? payload = JsonSerializer.Deserialize<T>(json);
            if (payload == null)
            {
                throw new InvalidOperationException("Token is null");
            }
            /* long nowUnixTimestamp = DateTime.Now.GetUnixTimestamp();
            if (payload.Expiration < nowUnixTimestamp)
            {
                throw new InvalidOperationException("Token expired!");
            } */
            return payload;
        }
    }
}
