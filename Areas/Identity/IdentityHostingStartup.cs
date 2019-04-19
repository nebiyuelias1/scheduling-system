using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SchedulingSystem.Persistence;

[assembly: HostingStartup(typeof(SchedulingSystem.Areas.Identity.IdentityHostingStartup))]
namespace SchedulingSystem.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<SchedulingDbContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("Default")));

                services.AddIdentity<IdentityUser, IdentityRole>()
                    .AddEntityFrameworkStores<SchedulingDbContext>();

                // services.AddDefaultIdentity<IdentityUser>()
                //     .AddEntityFrameworkStores<SchedulingDbContext>();
            });
        }
    }
}