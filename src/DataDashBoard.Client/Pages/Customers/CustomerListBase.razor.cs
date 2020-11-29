using DataDashboard.Client.Contracts;
using DataDashboard.Client.Models;
using DataDashboard.Client.Static;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataDashboard.Client.Pages.Customers 
{
    public partial class CustomerListBase : IDisposable
    {
        private HubConnection _hubConnection;

        public IList<CustomerModel> Customers = new List<CustomerModel>();

        [Inject]
        public ICustomerRepository CustomerRepo { get; set; }

        protected async Task OnInitializedAsync()
        {
            await StartHubConnection();
            await CustomerRepo.GetAll(Endpoints.CustomersEndpoint);
            AddDataListener();
        }

        private async Task StartHubConnection()
        {
            _hubConnection = new HubConnectionBuilder()
                .WithUrl("/customerhub")
                .Build();

            await _hubConnection.StartAsync();
            if (_hubConnection.State == HubConnectionState.Connected)
            {
                Console.WriteLine("connection started");
            }
        }

        private void AddDataListener()
        {
            _hubConnection.On<IList<CustomerModel>>("", (data) =>
            {
                foreach (var item in data)
                {
                    Console.WriteLine($"Name: {item.Name}, Email: {item.Email}");
                }

                Customers = data;
            });
        }

        public void Dispose()
        {
            _hubConnection.DisposeAsync();
        }
    }
}
