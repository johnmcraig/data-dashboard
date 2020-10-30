using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace DataDashboard.Api.Hubs
{
    public class CustomerHub : Hub
    {
        public async Task SendMessage()
        {
            await Clients.All.SendAsync("ReceiveMessage");
        }
    }
}
