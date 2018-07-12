using System;
using System.Linq;
using Dashboard.API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Dashboard.API.Controllers
{
  public class OrderController : Controller
  {
        private readonly ApiContext _context;
        ILogger<OrderController> _logger;

    public OrderController(ApiContext context, ILogger<OrderController> logger)
    {
            _context = context;
            _logger = logger;
    }

    [HttpGet]
    public IActionResult Get()
    {
      var orders = _context.Orders.OrderBy(o => o.Id);

      return Ok(orders);
    }
  }
}
