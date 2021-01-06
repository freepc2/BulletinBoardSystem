using System;
using Bbs.Models;
using Bbs.MSSQL.DAL.DataContext;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(Asp.NetCore.Mvc.Areas.Identity.IdentityHostingStartup))]
namespace Asp.NetCore.Mvc.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            //builder.ConfigureServices((context, services) => {
            //    services.AddDbContext<BbsDbContext>(options =>
            //        options.UseSqlServer(
            //            context.Configuration.GetConnectionString("BbsDbConnection")));

            //    services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = true)
            //        .AddEntityFrameworkStores<BbsDbContext>();
            //});
        }
    }
}