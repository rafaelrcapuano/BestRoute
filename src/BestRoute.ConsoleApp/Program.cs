using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.IO;
using BestRoute.Infra.CrossCutting;

namespace BestRoute.ConsoleApp
{
    public static class Program
    {
        static void Main(string[] args)
        {
            if (!ValidateArgs(args))
                return;

            string filePath = args.First();
            var serviceProvider = CreateServices(filePath);
            using var scope = serviceProvider.CreateScope();
            var app = serviceProvider.GetRequiredService<App>();

            ShowWelcomeMessage();

            bool execute = true;
            while (execute)
                execute = app.GetBestRoute();

            ShowFarewellMessage();
        }

        private static bool ValidateArgs(string[] args)
        {
            if (args.Length > 0 && File.Exists(args.First()))
                return true;

            Console.WriteLine($"The input file was not found. Please, enter a valid path. Example: dotnet run {@"C:\BestRoute\attachments\input-routes.csv"}");
            return false;
        }

        private static IServiceProvider CreateServices(string filePath)
        {
            var services = new ServiceCollection();
            services.AddUseCase(filePath);
            services.AddTransient<App>();

            return services.BuildServiceProvider();
        }

        private static void ShowWelcomeMessage()
        {
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("Welcome to Best Router Console App!");
            Console.WriteLine("Please, enter an existing route with the following structure: Departure-Destination");
            Console.WriteLine("If you would like to quit, press 'q' and 'Enter'.");
        }        

        private static void ShowFarewellMessage()
        {
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("Closing the app...");
        }
    }
}