using System;
using System.Linq;
using DataDashboard.Core.Entities;
using DataDashboard.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DataDashboard.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServersController : ControllerBase
    {
        private readonly ApiContext _context;
        ILogger<ServersController> _logger;

        public ServersController(ApiContext context, ILogger<ServersController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var response = _context.Servers.OrderBy(s => s.Id).ToList();

            return Ok(response);
        }

        [HttpGet("{id}", Name = "GetServer")]
        public IActionResult Get(int id)
        {
            var response = _context.Servers.Find(id);
            return Ok(response);
        }

        [HttpPut("{id}")]
        public IActionResult Message(int id, [FromForm] ServerMessage msg)
        {
            var server = _context.Servers.Find(id);

            if (server == null)
            {
                return NotFound();
            }

            // TODO: refactor into a service class
            if (msg.Payload == "activate")
            {
                server.IsOnline = true;
            }

            if (msg.Payload == "deactivate")
            {
                server.IsOnline = false;
            }

            _context.SaveChanges();
            return new NoContentResult();
        }
    }
}