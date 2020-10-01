using System;
using System.Linq;
using DataDashboard.Infrastructure.Data;
using DataDashboard.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using DataDashboard.Core.Interfaces;

namespace DataDashboard.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ApiContext _context;
        ILogger<CustomersController> _logger;
        private readonly ICustomerRepository _repo;
        private readonly IUnitOfWork _unitOfWork;

        public CustomersController(ApiContext context, 
        ILogger<CustomersController> logger,
        ICustomerRepository repo,
        IUnitOfWork unitOfWork)
        {
            _context = context;
            _logger = logger;
            _repo = repo;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var customers = await _unitOfWork.Customers.ListAllAsync();

            return Ok(customers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
           var customer = await _unitOfWork.Customers.GetByIdAsync(id);

            return Ok(customer);
        }

        [HttpPost]
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