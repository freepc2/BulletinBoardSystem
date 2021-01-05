using Bbs.Bll;
using Bbs.IDAL;
using Bbs.Models;
using Bbs.MSSQL.DAL;
using Bbs.MSSQL.DAL.DataContext;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.NetCore.Mvc6
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
            /* ������ ����
             * 1. .AddSingleton<T>();
             *  - ���α׷� ���۽ÿ� �����Ǹ�, ���α׷� ����ñ��� �޸� �� �����Ǵ� ��ü
             * 2. .AddScoped<T>();
             *  - ������Ʈ�� ���۵Ǿ� 1���� ��û�� ���� ��, �޸� �� �����Ǵ� ��ü 
             * 3. .AddTransient<T>(); <��õ>
             *  - ������Ʈ�� ���۵Ǿ� �� ��û���� ���Ӱ� �����Ǵ� ��ü ����
             *  - �ʿ�ø��� �����ǰ� ������� ������ �����ȴ�
             *  - ligthweight, stateless services
             */

            // DB Add
            services.AddSingleton<IConfiguration>(Configuration);
            services.AddDbContext<BbsDbContext>();

            // Bll Add
            services.AddTransient<UserBll>();
            services.AddTransient<IUserDal, UserDal>();

            services.AddTransient<NoteBll>();
            services.AddTransient<INoteDal, NoteDal>();

            // User Admin
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();
            services.ConfigureApplicationCookie(options =>
            {
                options.ExpireTimeSpan = TimeSpan.FromHours(1);
                options.LoginPath = "/Account/LogIn";
                options.LogoutPath = "/Account/LogOut";
                options.AccessDeniedPath = "/Home/Index";
            });

            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
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
               // endpoints.MapRazorPages();
            });
        }
    }
}
