using System;
using System.Linq;
using System.Threading.Tasks;
using DataDashboard.Core.Entities;
using DataDashboard.Core.Interfaces;
using DataDashboard.Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DataDashboard.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        ILogger<OrdersController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public OrdersController(ILogger<OrdersController> logger,
            IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAll()
        {
            _logger.LogInformation("Attempting to get all orders");

            try
            {
                var orders = await _unitOfWork.Orders.ListAllAsync();

                _logger.LogInformation("Successfully retreived all records");

                return Ok(orders);
            }
            catch (Exception ex)
            {
                _logger.LogError($"There was an error: {ex.Message}");
                
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetById(int id)
        {
            _logger.LogInformation("Attempting to get a single order record by Id");

            try
            {
                var order = await _unitOfWork.Orders.GetByIdAsync(id);

                if (order == null)
                    return NotFound();

                _logger.LogInformation($"Successfully found record of Id: {id}");

                return Ok(order);
            }
            catch (Exception ex)
            {
                _logger.LogError($"There was an error trying to get a record by Id: {id} - {ex.Message}");
                return BadRequest();
            } 
        }
    }
}