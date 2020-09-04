using System;
using System.Linq;
using DashboardApi.Data;
using DashboardApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DataDashboard.Api.Controllers
{
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ApiContext _context;
        ILogger<CustomerController> _logger;

        public CustomerController(ApiContext context, ILogger<CustomerController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var data = _context.Customers.OrderBy(c => c.Id);

            return Ok(data);
        }

        [HttpGet("{id}", Name = "Getcustomer")]
        public IActionResult Get(int id)
        {
            var customer = _context.Customers.Find(id);
            return Ok(customer);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Customer customer)
        {
            if (customer == null)
            {
                return BadRequest();
            }
            _context.Customers.Add(customer);
            _context.SaveChanges();

            return CreatedAtRoute("GetCsutomer", new
            {
                id = customer.Id
            }, customer);
        }
    }
}