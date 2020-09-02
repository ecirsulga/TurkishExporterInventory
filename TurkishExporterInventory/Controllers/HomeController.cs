using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TurkishExporterInventory.Database.Context;
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

        public IActionResult Index()
        {
            var test = _entityDbContext.Users.Where(q => q.Id == 5).FirstOrDefault();

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
