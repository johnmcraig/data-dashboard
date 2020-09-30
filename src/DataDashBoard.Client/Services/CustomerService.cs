using System.Net.Http;
using Blazored.LocalStorage;
using DataDashboard.Client.Contracts;
using DataDashboard.Client.Models;
using Microsoft.Extensions.Logging;

namespace DataDashboard.Client.Services
{
    public class CustomerService : RepositoryService<CustomerModel>, ICustomerRepository
    {
        private readonly HttpClient _client;
        private readonly ILogger<CustomerService> _logger;
        private readonly ILocalStorageService _localStorage;

        public CustomerService(HttpClient client, 
            ILogger<CustomerService> logger, 
            ILocalStorageService localStorage) : base(client, logger, localStorage)
        {
            _client = client;
            _logger = logger;
            _localStorage = localStorage;
        }
    }
}