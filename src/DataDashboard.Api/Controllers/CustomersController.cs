using System;
using System.Linq;
using DataDashboard.Infrastructure.Data;
using DataDashboard.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using DataDashboard.Core.Interfaces;
using Microsoft.AspNetCore.Http;

namespace DataDashboard.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ApiContext _context;
        ILogger<CustomersController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public CustomersController(ILogger<CustomersController> logger,
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
            _logger.LogInformation($"Attempting to get all customer records");

            try
            {
                var customers = await _unitOfWork.Customers.ListAllAsync();

                return Ok(customers);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Could not find records please see the following: {ex.Message}");
                return BadRequest();
            }
            
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetById(int id)
        {
            _logger.LogInformation($"Attempting to get a singe customer record");
            try
            {
                var customer = await _unitOfWork.Customers.GetByIdAsync(id);
                
                if (customer == null)
                    return NotFound();

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
        public IActionResult Create([FromBody] Customer customer)
        {
            if (customer == null)
            {
                return BadRequest();
            }
            
            _context.Customers.Add(customer);
            _context.SaveChanges();

            return CreatedAtRoute("GetCustomer", new
            {
                id = customer.Id
            }, customer);
        }
    }
}