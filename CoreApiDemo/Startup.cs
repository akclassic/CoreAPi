using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreApiDemo.BAL.Implementation;
using CoreApiDemo.BAL.Shared;
using CoreApiDemo.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace CoreApiDemo
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
            services.AddControllers();
            services.AddDbContext<CompanyDbContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("Default")));

            services.AddTransient<IEmployeeManager, EmployeeManager>();
            services.AddTransient<IDepartmentManager, DepartmentManager>();
            services.AddTransient<ILaptopManager, LaptopManager>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            //sir ye baad mai add kiya tha ye yahan pehle se nahi tha
            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllerRoute(
            //        name: "default",
            //        pattern: "{controller=Department}/{action=Get}/{id?}");
            //});
        }
    }
}
