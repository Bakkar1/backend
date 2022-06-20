using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebApp_mvc.Moddels;

namespace WebApp_mvc
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
            services.AddControllersWithViews();

            services.AddDbContextPool<AppDbContext>(
                options => options.UseSqlServer(Configuration.GetConnectionString("EmployeeDBConnection"))
            );

            services.AddIdentity <IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<AppDbContext>();

            //mvc services
            //services.AddMvc(options => options.EnableEndpointRouting = false);

             
            // registretion hna
            // b AddSingleton wala AddTransient wala AddScoped
            /*
                hna kat7adad wach IEmployeeRepository gahtkhdem b MockEmployeeReository
                wala b SQLEmployeeRepository
            */
            services.AddScoped<IEmployeeRepository, SQLEmployeeRepository>();
            //fach t3ayat 3la IEmployeeRepository kayraja3 lik instant mn MockEmployeeReository / SQLEmployeeRepository


            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequiredLength = 3;
                options.Password.RequiredUniqueChars = 0;
                options.Password.RequireNonAlphanumeric = false;
            });

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
                //app.UseStatusCodePages();

                //haka kan9dro nbayna wa7d lview b link liha fach ytra chi eroor
                // {0} this placeholder autmaticly resive de no succes status code
                //app.UseStatusCodePagesWithRedirects("/Error/{0}");

                //wala hadi, khdem 7san bhadi
                app.UseStatusCodePagesWithReExecute("/Error/{0}");

                // Global exception handling 
                app.UseExceptionHandler("/Error");
            }
            //app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();


            app.UseAuthentication();

            //default routing
            //darori UseMvcWithDefaultRoute ykon ba3d UseStaticFiles
            //app.UseMvcWithDefaultRoute();

            // custom routing
            // ? optional
            //app.UseMvc(routes => { routes.MapRoute("default", "{controller}/{action}/{id?}"); });
            //or
            //app.UseMvc(routes => { routes.MapRoute("default", "{controller = home}/{action = index}/{id?}"); });

            //attribute routing bach dir custom l route fl controller
            //app.UseMvc();


            //app.UseRouting();

            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            //app.Run(async context =>
            //{
            //    await context.Response.WriteAsync("Welcome");
            //});
        }
    }
}
