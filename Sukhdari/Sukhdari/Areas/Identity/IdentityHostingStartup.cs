﻿using System;
using DataAccess.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(Sukhdari.Areas.Identity.IdentityHostingStartup))]
namespace Sukhdari.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {

        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }

}




