using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TurkishExporterInventory.Database.Context;
using TurkishExporterInventory.Database.Models;

namespace TurkishExporterInventory.Helpers
{
    public class DataHelper
    {
        private readonly EntityDbContext _entityDbContext;
        private readonly User _dataHelper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public DataHelper(EntityDbContext entityDbContext,IHttpContextAccessor httpContextAccessor)
        {
            _entityDbContext = entityDbContext;
            _httpContextAccessor = httpContextAccessor;
        }
        public LayoutModel GetCurrentUser()
        {
            var cookieUserId = int.Parse(_httpContextAccessor.HttpContext.Request.Cookies["loggedinuser"]);

            var loggedInUser = _entityDbContext.Users.Where(q => q.Id == cookieUserId).Select(c => new LayoutModel
            {
                Name = c.Name,
                Surname = c.Surname,
                Email = c.Email
            }
            ).FirstOrDefault();

            return loggedInUser;
        }
        

    }
}
