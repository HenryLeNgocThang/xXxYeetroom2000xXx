using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace xXxYeetroom2000xXx
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Initially the application is a console-application which creates and runs a desktop- or web-application through a configured host.
            CreateHostBuilder(args).Build().Run();
        }

        /// <summary>
        /// Calls a CreateHostBuilder method to create and configure a builder object.
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
