using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using TurkishExporterInventory.Database.Context;
using TurkishExporterInventory.Database.Models;

namespace TurkishExporterInventory.Controllers
{
    public class LoginController : Controller
    {
        private readonly EntityDbContext _context;

        public LoginController(EntityDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
           

            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Login([Bind] User user)
        {
            
            List<User> users = new List<User>();
            users = _context.Users.ToList();
            if (users.Any(u => u.Email== user.Email))
            {
                var userClaims = new List<Claim>()
                {
                new Claim(ClaimTypes.Email, user.Email),
                 };

                var user_Identity = new ClaimsIdentity(userClaims, "User Identity");

                var userPrincipal = new ClaimsPrincipal(new[] { user_Identity });

                HttpContext.SignInAsync(userPrincipal);

                return RedirectToAction("Index", "Home");
            }

            return View(user);
        }


    }
}
