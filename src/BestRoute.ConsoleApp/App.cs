using System;
using BestRoute.Application.Interfaces.UseCases;

namespace BestRoute.ConsoleApp
{
    public class App
    {
        private readonly IGetBestRouteUseCase _useCase;

        public App(IGetBestRouteUseCase useCase)
        {
            _useCase = useCase;
        }

        public bool GetBestRoute()
        {
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("Please enter the route: ");

            var input = Console.ReadLine();
            if (CloseApp(input))
                return false;

            var parameters = input.Split('-');
            if (!ValidateParameters(parameters))
                return true;

            return TryGetBestRoute(parameters);
        }

        private bool CloseApp(string input)
        {
            return input == "q";
        }

        private bool ValidateParameters(string[] parameters)
        {
            if (parameters.Length == 2)
                return true;
            
            InvalidRouteMessage();
            return false;            
        }        

        private void InvalidRouteMessage()
        {
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("The informed route is not valid.");
            Console.WriteLine("Please, enter an existing route with the following structure:");
            Console.WriteLine("Departure-Destination");
        }

        private bool TryGetBestRoute(string[] parameters)
        {
            var departure = parameters[0];
            var destination = parameters[1];

            try
            {
                GetBestRoute(departure, destination);
            }
            catch
            {
                Console.WriteLine("Something didn't go as expected... Please, check if the file routes are formatted correctly.");
                return false;
            }

            return true;
        }

        private void GetBestRoute(string departure, string destination)
        {
            var bestRoute = _useCase.Get(departure, destination);

            if (bestRoute == null)
                NotExistRouteMessage();
            else
                Console.WriteLine($"Best route: {bestRoute.Route} > ${bestRoute.TotalDistance}");
        }

        private void NotExistRouteMessage()
        {
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("The informed route is not valid.");
            Console.WriteLine("Please, check if departure and destination are correct.");
        }
    }
}
