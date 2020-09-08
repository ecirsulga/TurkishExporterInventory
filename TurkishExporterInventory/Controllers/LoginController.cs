using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
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

        [HttpGet]
        public ActionResult Login()
        {

            return View();
        }

        [HttpPost]
        public async Task<ActionResult> LoginAsync(string Email, string Password)
        {
            
           

            var isUser = _context.Users.Any(u => u.Email == Email);
            if (isUser)
            {

                var entityUser = _context.Users.Where(u => u.Email == Email).Select(q => new { q.Id, q.Email, q.Name, q.Password }).FirstOrDefault();
                if (Password != entityUser.Password)
                {
                    ViewBag.Message = "Hatalı parola girdiniz. Lütfen parolanızı doğru girdiğinizden emin olun!";
                    return View();
                }
                HttpContext.Session.SetString("UserLoginEmail", Email);

                List<Claim> claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.Email, Email));
                claims.Add(new Claim(ClaimTypes.Role, "user"));
                ClaimsIdentity identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                ClaimsPrincipal principal = new ClaimsPrincipal(identity);
                await HttpContext.SignInAsync(principal);
                return RedirectToAction("Index", "Home");

            }
            ViewBag.Message = "Kullanıcı bulunamadı. Bilgilerinizi tekrar kontrol edin!";
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Login", "Login");
        }

    }
}
