using System;
using System.Linq;
using System.Threading.Tasks;
using DataDashboard.Core.Entities;
using DataDashboard.Core.Interfaces;
using DataDashboard.Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DataDashboard.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServersController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        ILogger<ServersController> _logger;

        public ServersController(IUnitOfWork unitOfWork, ILogger<ServersController> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAll()
        {
            var response = await _unitOfWork.Servers.ListAllAsync();

            return Ok(response);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetById(int id)
        {
            var response = _unitOfWork.Servers.GetByIdAsync(id);
            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Message(int id, [FromForm] ServerMessage msg)
        {
            var server = await _unitOfWork.Servers.GetByIdAsync(id);
            
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

            //_context.SaveChanges();
            return new NoContentResult();
        }
    }
}