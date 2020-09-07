using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
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
            var  isUser = _context.Users.Any(u => u.Email == user.Email);
            if (isUser)
            {

                var entityUser= _context.Users.Where(u => u.Email == user.Email).Select(q=>new { q.Id, q.Email,q.Name, q.Password}).FirstOrDefault();
                if (user.Password!=entityUser.Password)
                {
                    ViewBag.Message = "Hatalı parola girdiniz. Lütfen parolanızı doğru girdiğinizden emin olun!";
                    return View(user);
                }

                CookieOptions option = new CookieOptions();

                Response.Cookies.Append("loggedinuser", entityUser.Id.ToString(), option);

                var userClaims = new List<Claim>()
                {
                new Claim(ClaimTypes.Email, user.Email),
                 };

                var user_Identity = new ClaimsIdentity(userClaims, "User Identity");

                var userPrincipal = new ClaimsPrincipal(new[] { user_Identity });

                HttpContext.SignInAsync(userPrincipal);

                return RedirectToAction("Index", "Home");
            }
            ViewBag.Message = "Kullanıcı bulunamadı. Bilgilerinizi tekrar kontrol edin!";
            return View(user);
        }

    }
}
