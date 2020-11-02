using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;

namespace DataDashboard.Api.Hubs
{
    public class CustomerHub : Hub
    {
        public override async Task OnConnectedAsync()
        {
            await base.OnConnectedAsync();
            await SendMessage();
        }

        public async Task SendMessage()
        {
            await Clients.All.SendAsync("Message", "Successfully connected");
        }

        public override async Task OnDisconnectedAsync(Exception ex)
        {
            await Clients.All.SendAsync("Message", "Successfully disconnected");
            await base.OnDisconnectedAsync(ex);
        }
    }
}
