using System;
using System.Linq;
using Dashboard.API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Dashboard.API.Controllers
{
  public class CustomerController : Controller
  {
        private readonly ApiContext _context;
        ILogger<CustomerController> _logger;

    public CustomerController(ApiContext context, ILogger<CustomerController> logger)
    {
            _context = context;
            _logger = logger;
    }

    public IActionResult Index()
    {
      
      return View();
    }
  }
}

