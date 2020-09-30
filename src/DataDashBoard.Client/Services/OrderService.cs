using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using DataDashboard.Client.Contracts;
using DataDashboard.Client.Models;
using Microsoft.Extensions.Logging;

namespace DataDashboard.Client.Services
{
    public class OrderService : RepositoryService<OrderModel>, IOrderRepository
    {
        private readonly HttpClient _client;
        private readonly ILogger<OrderService> _logger;
        private readonly ILocalStorageService _localStorage;

        public OrderService(HttpClient client, 
            ILogger<OrderService> logger, 
            ILocalStorageService localStorage) : base(client, logger, localStorage)
        {
            _client = client;
            _logger = logger;
            _localStorage = localStorage;
        }
    }
}