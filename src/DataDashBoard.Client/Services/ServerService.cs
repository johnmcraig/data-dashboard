using Blazored.LocalStorage;
using DataDashboard.Client.Contracts;
using DataDashboard.Client.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace DataDashboard.Client.Services
{
    public class ServerService : RepositoryService<ServerModel>, IServerRepository
    {
        private readonly HttpClient _client;
        private readonly ILogger<ServerService> _logger;
        private readonly ILocalStorageService _localStorage;

        public ServerService(HttpClient client,
            ILogger<ServerService> logger,
            ILocalStorageService localStorage) : base(client, logger, localStorage)
        {
            _client = client;
            _logger = logger;
            _localStorage = localStorage;
        }
    }
}
