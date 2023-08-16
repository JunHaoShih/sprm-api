using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Primitives;

namespace SprmNotifier.Notifiers
{
    public class NotifierHub : Hub
    {
        public override Task OnConnectedAsync()
        {
            HttpContext? httpCtx = Context.GetHttpContext();
            if (httpCtx == null)
            {
                Context.Abort();
                return Task.CompletedTask;
            }
            string? userName = httpCtx.Request.Headers["Subject"];
            if (userName == null)
            {
                Context.Abort();
                return Task.CompletedTask;
            }

            // Add user to its own group
            Groups.AddToGroupAsync(Context.ConnectionId, userName);
            return base.OnConnectedAsync();
        }
    }
}
