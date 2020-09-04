using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TurkishExporterInventory.Database.Context;
using TurkishExporterInventory.Database.Models;
using TurkishExporterInventory.Models;

namespace TurkishExporterInventory.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly EntityDbContext _entityDbContext;

        
        
        public HomeController(ILogger<HomeController> logger, EntityDbContext entityDbContext)
        {
            
            _logger = logger;
            _entityDbContext = entityDbContext;
        }

        [Authorize]
        public ActionResult Users()
        {
            List<User> users = new List<User>();
            users = _entityDbContext.Users.ToList();

            return View();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
