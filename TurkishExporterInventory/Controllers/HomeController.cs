using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TurkishExporterInventory.Database.Context;
using TurkishExporterInventory.Database.Models;
using TurkishExporterInventory.Models;
using System.Web;
using RestSharp;

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
            //read cookie from Request object  


            //var model = _entityDbContext.Users.Find(int.Parse(cookieUserId)).;
            //model.Email = loggedInUser.Email;
            //model.Name = loggedInUser.Name;
            //model.Surname = loggedInUser.Surname;

            if (User.Claims.Select(q => q.Value).FirstOrDefault() != null && HttpContext.Session.GetString("UserLoginEmail") == User.Claims.Select(q => q.Value).FirstOrDefault())
            {
                return View();
            }
            return RedirectToAction("Logout", "Login");
        }

        public IActionResult Privacy()
        {
            if (User.Claims.Select(q => q.Value).FirstOrDefault() != null && HttpContext.Session.GetString("UserLoginEmail") == User.Claims.Select(q => q.Value).FirstOrDefault())
            {
                return View();
            }
            return RedirectToAction("Logout", "Login");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            if (User.Claims.Select(q => q.Value).FirstOrDefault() != null && HttpContext.Session.GetString("UserLoginEmail") == User.Claims.Select(q => q.Value).FirstOrDefault())
            {
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
            return RedirectToAction("Logout", "Login");
        }
    }
}
