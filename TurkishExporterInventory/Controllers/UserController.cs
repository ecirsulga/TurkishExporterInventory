using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TurkishExporterInventory.Database.Context;
using TurkishExporterInventory.Database.Models;
using TurkishExporterInventory.Models;

namespace TurkishExporterInventory.Controllers
{
    public class UserController : Controller
    {

        private readonly ILogger<UserController> _logger;
        private readonly EntityDbContext _entityDbContext;


        public UserController(ILogger<UserController> logger, EntityDbContext entityDbContext)
        {
            _logger = logger;
            _entityDbContext = entityDbContext;
        }

        public IActionResult Index()
        {
            return View();
        }



        public IActionResult AddUser()
        {
            return View();
        }

        public IActionResult UserList()
        {
            var users = _entityDbContext.Users.Select(q => new UserListModel()
            {
                UserId = q.Id,
                UserName = q.Name,
                UserSurname = q.Surname,
                UserDepartment = q.Department,
                UserItemCount = q.Allocations.Count,
                UserPosition = q.Position,
                UserRecordCreateTime = q.RecordCreateTime,
                UserTotalValue = 0,
                UserLastItem = 0
            });

            return View(users.ToList());
        }
    }
}