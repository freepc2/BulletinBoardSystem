using Bbs.Bll;
using Bbs.IDAL;
using Bbs.Models;
using Bbs.MSSQL.DAL;
using Bbs.MSSQL.DAL.DataContext;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Logging;
using Asp.NetCore.Mvc.Services;
using System;

namespace Asp.NetCore.Mvc
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            /* 의존성 주입
             * 1. .AddSingleton<T>();
             *  - 프로그램 시작시에 생성되며, 프로그램 종료시까지 메모리 상에 유지되는 객체
             * 2. .AddScoped<T>();
             *  - 웹사이트가 시작되어 1번의 요청이 있을 때, 메모리 상에 유지되는 객체 
             * 3. .AddTransient<T>(); <추천>
             *  - 웹사이트가 시작되어 각 요청마다 새롭게 생성되는 객체 주입
             *  - 필요시마다 생성되고 사용하지 않으면 삭제된다
             *  - ligthweight, stateless services
             */

            // 의존성 주입 UserBll

            services.AddTransient<UserBll>();
            services.AddTransient<IUserDal, UserDal>();

            services.AddTransient<NoteBll>();
            services.AddTransient<INoteDal, NoteDal>();

            // Add Singleton & DB context
            services.AddSingleton<IConfiguration>(Configuration);
            services.AddDbContext<BbsDbContext>();
            services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<BbsDbContext>();
            services.Configure<DataProtectionTokenProviderOptions>(o =>
                   o.TokenLifespan = TimeSpan.FromHours(1));

            services.AddControllersWithViews();
            services.AddRazorPages();


            services.AddIdentityCore<User>()
                .AddRoles<UserRole>()
                .AddEntityFrameworkStores<BbsDbContext>()
                .AddSignInManager()
                .AddDefaultTokenProviders();


            services.AddAuthentication(o =>
            {
                o.DefaultScheme = IdentityConstants.ApplicationScheme;
                o.DefaultSignInScheme = IdentityConstants.ExternalScheme;
            });
            //.AddIdentityCookies(o =>
            //{
            //});

            services.ConfigureApplicationCookie(options =>
            {
                // Cookie settings
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(5);

              //  options.LoginPath = "/Identity/Account/Login";
              //  options.AccessDeniedPath = "/Identity/Account/AccessDenied";
                options.SlidingExpiration = true;
            });

            // Add application services.
            //    services.AddTransient<IEmailSender, AuthMessageSender>();
            //    services.AddTransient<ISmsSender, AuthMessageSender>();


           // services.AddDatabaseDeveloperPageExceptionFilter();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
