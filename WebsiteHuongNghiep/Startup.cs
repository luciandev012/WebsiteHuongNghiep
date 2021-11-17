using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebsiteHuongNghiep.Application.Common;
using WebsiteHuongNghiep.Application.Services;
using WebsiteHuongNghiep.Application.Services.BlogService;
using WebsiteHuongNghiep.Application.Services.MBTI;
using WebsiteHuongNghiep.Application.Services.System;
using WebsiteHuongNghiep.Data.EF;
using WebsiteHuongNghiep.Data.Entities;

namespace WebsiteHuongNghiep
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
            services.AddDbContext<VocationalGuidanceDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("vocationalGuidanceDb")));

            services.AddIdentity<User, Role>()
                .AddEntityFrameworkStores<VocationalGuidanceDbContext>()
                .AddDefaultTokenProviders();
            services.AddSession(option => {
                option.IdleTimeout = TimeSpan.FromMinutes(30);
            });
            services.AddControllersWithViews();
            services.AddRazorPages();
            services.AddTransient<IManageHLTableServices, ManageHLTable>();
            services.AddTransient<IManageHLMultipleChoiceServices, ManageHLMultipleChoices>();
            services.AddTransient<IManageHLTrackerServices, ManageHLTracker>();
            services.AddTransient<IManageHLScoreServices, ManageHLScore>();
            services.AddTransient<IManageHLResultServices, ManageHLResult>();
            services.AddTransient<UserManager<User>, UserManager<User>>();
            services.AddTransient<SignInManager<User>, SignInManager<User>>();
            services.AddTransient<IUserServices, UserServices>();
            services.AddTransient<IStorageService, StorageService>();
            services.AddTransient<IManageBlogServices, ManageBlogService>();
            services.AddTransient<IManageMbtiTableServices, ManageMbtiTableServices>();
            services.AddTransient<IManageMbtiResultServices, ManageMbtiResultServices>();
            services.AddTransient<IManageMbtiTrackerServices, ManageMbtiTrackerService>();
            //services.AddTransient<RoleManager<Role>, RoleManager<Role>>();

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
            app.UseSession();
            app.UseEndpoints(endpoints =>
            {
                
                endpoints.MapControllerRoute(
                    name: "admin",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");


                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
