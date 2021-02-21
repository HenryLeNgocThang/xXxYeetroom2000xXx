using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using xXxYeetroom2000xXx.Data;
using Microsoft.EntityFrameworkCore;

namespace xXxYeetroom2000xXx
{
    public class Startup
    {
        /// <summary>
        ///  Creates the app's pipeline(mechanism by which http requests are processed through the middlewares(software components which process and manipulate the requests) and configure the app's services .
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// Represents a set of key/value application configuration properties.
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// This method gets called in the initializing phase of the application. Use this method to add and configure services to the container.
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddDbContext<YeetroomContext>(options =>
            options.UseMySQL(Configuration.GetConnectionString("xXxYeetroom2000xXx"),
            MySQLOptionsAction: MySQLDbContextOptionsExtensions =>
            {
                
            }
            ));
        }

        /// <summary>
        /// This method gets called in the initializing phase of the application. It configures the HTTP request pipeline(e.g. registers the middlewares).
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
