using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text;
using Blazored.LocalStorage;
using Blazored.Toast;
using DataDashboard.Client.Contracts;
using DataDashboard.Client.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace DataDashboard.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            builder.Services.AddBlazoredToast();
            builder.Services.AddBlazoredLocalStorage();
            
            builder.Services.AddTransient(typeof(IRepositoryBase<>), typeof(RepositoryService<>));
            builder.Services.AddTransient<IOrderRepository, OrderService>();
            builder.Services.AddTransient<ICustomerRepository, CustomerService>();
            builder.Services.AddTransient<IServerRepository, ServerService>();

            builder.Services.AddOptions();
            
            await builder.Build().RunAsync();
        }
    }
}
