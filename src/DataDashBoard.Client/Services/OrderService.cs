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
        private readonly ILogger<RepositoryService<OrderModel>> _logger;
        private readonly ILocalStorageService _localStorage;

        protected OrderService(HttpClient client, 
            ILogger<RepositoryService<OrderModel>> logger, 
            ILocalStorageService localStorage) : base(client, logger, localStorage)
        {
            _client = client;
            _logger = logger;
            _localStorage = localStorage;
        }
    }
}