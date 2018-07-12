using System;
using System.Linq;
using Dashboard.API.Data;
using Dashboard.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Dashboard.API.Controllers
{
    [Route("api/[controller]")]
    public class OrderController : Controller
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

            return Ok(data);
        }
    }
}
