using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Serilog.Extensions.Logging.File;

namespace UruIT.GameOfDrones.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();
    
            CreateWebHostBuilder(args,configuration).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args,IConfiguration config) =>
            WebHost.CreateDefaultBuilder(args)
                .ConfigureLogging((hostingContext, builder) =>
                {
                    builder.AddFile("Logs/UruIT_GameOfDrones_Api-{Date}.txt");
                })
                .UseConfiguration(config)
                .UseStartup<Startup>();
    }
}
