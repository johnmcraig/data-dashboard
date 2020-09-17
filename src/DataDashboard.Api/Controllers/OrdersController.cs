using System;
using System.Linq;
using System.Threading.Tasks;
using DataDashboard.Core.Entities;
using DataDashboard.Core.Interfaces;
using DataDashboard.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DataDashboard.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly ApiContext _context;
        private readonly IOrderRepository _repo;
        ILogger<OrdersController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public OrdersController(ApiContext context,
            IOrderRepository repo,
            ILogger<OrdersController> logger,
            IUnitOfWork unitOfWork)
        {
            _context = context;
            _repo = repo;
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        /*
        Pagination for the server
        GET api/order/pageNumber/pageSize
         */
        [HttpGet] //("{pageIndex:int}/{pageSize:int}") int pageIndex, int pageSize
        public async Task<IActionResult> GetAll()
        {
            _logger.LogInformation("Attempting to get all orders");

            try
            {
                var data = await _unitOfWork.Orders.ListAllAsync();

                _logger.LogInformation("Successfully retrived all records");

                return Ok(data);
            }
            catch (System.Exception ex)
            {
                _logger.LogError($"There was an error: {ex.Message}");
                
                return BadRequest(ex.Message);
            }
            
            // var data = _context.Orders
            //     .Include(o => o.Customer)
            //     .OrderByDescending(c => c.Placed);

            // var page = new PaginatedResponse<Order>(data, pageIndex, pageSize);

            // var totalCount = data.Count();
            // var totalPages = Math.Ceiling((double)totalCount / pageSize);

            // var response = new
            // {
            //     Page = page,
            //     TotalPages = totalPages
            // };

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            // var order = _context.Orders.Include(o => o.Customer)
            //     .First(o => o.Id == id);

            var order = await _unitOfWork.Orders.GetByIdAsync(id);

            if (order == null)
                return NotFound();

            return Ok(order);
        }

        [HttpGet("ByState")]
        public IActionResult ByState()
        {
            var orders = _context.Orders.Include(o => o.Customer).ToList();

            var groupResult = orders.GroupBy(o => o.Customer.State)
                .ToList()
                .Select(grp => new
                {
                    State = grp.Key,
                        Total = grp.Sum(x => x.Total)
                }).OrderByDescending(res => res.Total) //descending number of States in order
                .ToList();

            return Ok(groupResult);
        }

        [HttpGet("ByCustomer")]
        public IActionResult ByCustomer(int n)
        {
            var orders = _context.Orders.Include(o => o.Customer).ToList();

            var groupResult = orders.GroupBy(o => o.Customer.State)
                .ToList()
                .Select(grp => new
                {
                    Name = _context.Customers.Find(grp.Key).Name,
                        Total = grp.Sum(x => x.Total)
                }).OrderByDescending(res => res.Total)
                .Take(n)
                .ToList();

            return Ok(groupResult);
        }

    }
}