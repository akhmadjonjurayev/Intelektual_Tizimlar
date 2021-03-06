using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Intelektual_Tizimlar_Amaliyot
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    if(!string.IsNullOrEmpty(webBuilder.GetSetting("ASPNETCORE_URLS")))
                    {
                        webBuilder.UseSetting("https_port", webBuilder.GetSetting("ASPNETCORE_URLS"));
                    }
                    webBuilder.UseStartup<Startup>();
                });
    }
}
