using System;
using DataDashboard.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using DataDashboard.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;
using DataDashboard.Api.Hubs;

namespace DataDashboard.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ILogger<CustomersController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHubContext<CustomerHub> _customerHub;

        public CustomersController(ILogger<CustomersController> logger, 
            IUnitOfWork unitOfWork, IHubContext<CustomerHub> customerHub)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _customerHub = customerHub;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAll(string search, int page = 1, int pageSize = 20)
        {
            _logger.LogInformation("Attempting to get all records");

            try
            {
                if (string.IsNullOrWhiteSpace(search))
                {
                    var customers = await _unitOfWork.Customers.ListAllWithPaging(page, pageSize);

                    return Ok(customers);
                }
                else
                {
                    var customers = await _unitOfWork.Customers.ListAllWithSearchingAndPaging(search, page, pageSize);

                    return Ok(customers);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Could not find any records! Please see the following: {ex.Message}");
                return BadRequest();
            }
            
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetById(int id)
        {
            _logger.LogInformation("Attempting to get a single customer record");

            try
            {
                var customer = await _unitOfWork.Customers.GetByIdAsync(id);
                
                if (customer == null) return NotFound();

                return Ok(customer);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Could not find the record with Id: {id}. Please see the following: {ex.Message}");
                return BadRequest();
            } 
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateCustomer([FromBody] Customer customer)
        {
            if (customer == null)
            {
                return BadRequest();
            }

            await _unitOfWork.Customers.Create(customer);

            await _customerHub.Clients.All.SendAsync("CreateCustomer");

            return Created("CreateCustomer", new
            {
                Message = "Request completed",
                customer
            });
               
        }
    }
}