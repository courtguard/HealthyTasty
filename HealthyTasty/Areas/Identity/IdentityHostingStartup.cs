using System;
using HealthyTasty.Areas.Identity.Data;
using HealthyTasty.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(HealthyTasty.Areas.Identity.IdentityHostingStartup))]
namespace HealthyTasty.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<HealthyTastyDbContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("HealthyTastyDbContextConnection")));

                services.AddDefaultIdentity<HealthyTastyUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<HealthyTastyDbContext>();
            });
        }
    }
}