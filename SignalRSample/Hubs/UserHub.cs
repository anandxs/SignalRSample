using Microsoft.AspNetCore.SignalR;

namespace SignalRSample.Hubs
{
    public class UserHub : Hub
    {
        public static int TotalViews { get; set; } = 0;
        public static int TotalUsers { get; set; } = 0;

        public override async Task OnConnectedAsync()
        {
            TotalUsers++;
            await Clients.All.SendAsync("updateTotalUsers", TotalUsers);
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            TotalUsers--;
            await Clients.All.SendAsync("updateTotalUsers", TotalUsers);
            await base.OnDisconnectedAsync(exception);
        }

        public async Task<string> WindowLoaded(string name)
        {
            TotalViews++;

            await Clients.All.SendAsync("updateTotalViews", TotalViews);

            return $"Total views: {TotalViews}; From: {name}";
        }
    }
}
