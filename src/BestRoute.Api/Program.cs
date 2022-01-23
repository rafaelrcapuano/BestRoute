using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;
using System.Linq;

namespace BestRoute.Api
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            if (!ValidateArgs(args))
                return;

            CreateHostBuilder(args.First()).Build().Run();
        }

        private static bool ValidateArgs(string[] args)
        {
            if (args.Length > 0 && File.Exists(args.First()))
                return true;

            Console.WriteLine($"The input file was not found. Please, enter a valid path. Example: dotnet run {@"C:\BestRoute\attachments\input-routes.csv"}");
            return false;
        }

        public static IHostBuilder CreateHostBuilder(string filePath)
        {
            var configuration = new string[] { "--filePath", filePath };

            return Host
                .CreateDefaultBuilder(configuration)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    var config = new ConfigurationBuilder()
                        .AddCommandLine(configuration)
                        .Build();

                    webBuilder.UseConfiguration(config);
                    webBuilder.UseStartup<Startup>();
                });
        }            
    }
}
