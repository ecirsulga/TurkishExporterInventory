using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TurkishExporterInventory.Database.Context;
using TurkishExporterInventory.Database.Models;


namespace TurkishExporterInventory.Helpers
{
    public class DataHelper
    {
        private readonly EntityDbContext _entityDbContext;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public DataHelper(EntityDbContext entityDbContext,IHttpContextAccessor httpContextAccessor)
        {
            _entityDbContext = entityDbContext;
            _httpContextAccessor = httpContextAccessor;
        }
        public LayoutModel GetCurrentUser(string Email)
        {


            //var provider = DataProtectionProvider.Create(new DirectoryInfo(@"C:\temp-keys\"));

            //string cookieValue = _httpContextAccessor.HttpContext.Request.Cookies["loggedinuser"];

            ////Get a data protector to use with either approach
            //var dataProtector = provider.CreateProtector(typeof(PostConfigureCookieAuthenticationOptions).FullName, "loggedinuser", "v2");


            ////Get the decrypted cookie as plain text
            //UTF8Encoding specialUtf8Encoding = new UTF8Encoding(encoderShouldEmitUTF8Identifier: false, throwOnInvalidBytes: true);
            //byte[] protectedBytes = Base64UrlTextEncoder.Decode(cookieValue);
            //byte[] plainBytes = dataProtector.Unprotect(protectedBytes);
            //string plainText = specialUtf8Encoding.GetString(plainBytes);


            ////Get the decrypted cookie as a Authentication Ticket
            //TicketDataFormat ticketDataFormat = new TicketDataFormat(dataProtector);
            //AuthenticationTicket ticket = ticketDataFormat.Unprotect(cookieValue);

            
            var loggedinuser = _entityDbContext.Users.Where(q => q.Email == Email).Select(c => new LayoutModel
            {
                Name = c.Name,
                Surname = c.Surname,
                Email = c.Email
            }
            ).FirstOrDefault();

            return loggedinuser;
        }
        

    }
}
