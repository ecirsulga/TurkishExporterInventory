﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.Options;

namespace TurkishExporterInventory.Helpers
{
    public class PostConfigureCookieAuthenticationOptions : IPostConfigureOptions<CookieAuthenticationOptions>
    {
        private readonly IDataProtectionProvider _dp;

        public PostConfigureCookieAuthenticationOptions(IDataProtectionProvider dataProtection)
        {
            _dp = dataProtection;
        }

        /// <summary>
        /// Invoked to post configure a TOptions instance.
        /// </summary>
        /// <param name="name">The name of the options instance being configured.</param>
        /// <param name="options">The options instance to configure.</param>
        public void PostConfigure(string name, CookieAuthenticationOptions options)
        {
            options.DataProtectionProvider = options.DataProtectionProvider ?? _dp;

            if (string.IsNullOrEmpty(options.Cookie.Name))
            {
                options.Cookie.Name = CookieAuthenticationDefaults.CookiePrefix + name;
            }
            if (options.TicketDataFormat == null)
            {
                // Note: the purpose for the data protector must remain fixed for interop to work.
                var dataProtector = options.DataProtectionProvider.CreateProtector(typeof(PostConfigureCookieAuthenticationOptions).FullName, name, "v2");
                options.TicketDataFormat = new TicketDataFormat(dataProtector);
            }
            if (options.CookieManager == null)
            {
                options.CookieManager = new ChunkingCookieManager();
            }
            if (!options.LoginPath.HasValue)
            {
                options.LoginPath = CookieAuthenticationDefaults.LoginPath;
            }
            if (!options.LogoutPath.HasValue)
            {
                options.LogoutPath = CookieAuthenticationDefaults.LogoutPath;
            }
            if (!options.AccessDeniedPath.HasValue)
            {
                options.AccessDeniedPath = CookieAuthenticationDefaults.AccessDeniedPath;
            }
        }
    }
}
