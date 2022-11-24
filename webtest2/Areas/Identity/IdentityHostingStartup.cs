using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using webtest2.Areas.Identity.Data;
using webtest2.Data;

[assembly: HostingStartup(typeof(webtest2.Areas.Identity.IdentityHostingStartup))]
namespace webtest2.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<webtest2DbContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("webtest2DbContextConnection")));

                services.AddDefaultIdentity<webtest2ApplicationUser>(options => {
                    options.SignIn.RequireConfirmedAccount = false;
                })
                    .AddEntityFrameworkStores<webtest2DbContext>();
            });
        }
    }
}