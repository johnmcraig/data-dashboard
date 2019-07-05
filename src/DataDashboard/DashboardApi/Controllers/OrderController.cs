using System;
using System.Linq;
using DashboardApi.Data;
using DashboardApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DashboardApi.Controllers
{
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly ApiContext _context;
        ILogger<OrderController> _logger;

        public OrderController(ApiContext context, ILogger<OrderController> logger)
        {
            _context = context;
            _logger = logger;
        }

        /*
        Pagination for the server
        GET api/order/pageNumber/pageSize
         */
        [HttpGet("{pageIndex:int}/{pageSize:int}")]
        public IActionResult Get(int pageIndex, int pageSize)
        {
            var data = _context.Orders
                    .Include(o => o.Customer)
                    .OrderByDescending(c => c.Placed);

            var page = new PaginatedResponse<Order>(data, pageIndex, pageSize);

            var totalCount = data.Count();
            var totalPages = Math.Ceiling((double)totalCount / pageSize);

            var response = new
            {
                Page = page,
                TotalPages = totalPages
            };

            return Ok(response);
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
                }).OrderByDescending(res => res.Total) //descending number of Customers in order
                .Take(n)
                .ToList();

            return Ok(groupResult);
        }

        [HttpGet("GetOrder/{id}", Name = "GetOrder")]
        public IActionResult GetOrder(int id)
        {
            var order = _context.Orders.Include(o => o.Customer)
            .First(o => o.Id == id);

            return Ok(order);
        }

    }
}
