using System.Collections.Generic;
using System.Linq;
using System.Text;
using BestRoute.Application.Interfaces.Repositories;
using BestRoute.Application.Interfaces.UseCases;
using BestRoute.Application.UseCases.Route.Responses;
using BestRoute.Domain;

namespace BestRoute.Application.UseCases.Route
{
    public class GetBestRouteUseCase : IGetBestRouteUseCase
    {
        private readonly IRouteRepository _routeRepository;
        private readonly IList<TravelModel> _travels;
        private IList<RouteModel> routes;

        public GetBestRouteUseCase(IRouteRepository routeRepository)
        {
            _routeRepository = routeRepository;
            _travels = new List<TravelModel>();            
        }

        public BestRouteResponse Get(string departure, string destination)
        {
            departure = departure.ToUpperInvariant();
            destination = destination.ToUpperInvariant();

            routes = _routeRepository.Get();
            if (!IsValidDestination(destination))
                return default;

            var possibleRoutes = GetPossibleRoutes(departure);
            if (!possibleRoutes.Any())
                return default;

            foreach (var currentRoute in possibleRoutes)
                AddTravel(currentRoute, destination);

            return ReturnBestRoute(departure);
        }

        private bool IsValidDestination(string destination)
        {
            return routes.Any(a => a.Destination == destination);
        }

        private IEnumerable<RouteModel> GetPossibleRoutes(string departure)
        {
            var possibleRoutes = routes
                .Where(w => w.Departure == departure)
                .ToList();

            return possibleRoutes;
        }

        private void AddTravel(RouteModel currentRoute, string destination)
        {
            var travel = new TravelModel();
            FindDestination(travel, currentRoute, destination);
            _travels.Add(travel);
        }

        private void FindDestination(TravelModel travel,
            RouteModel currentRoute,
            string destination)
        {
            travel.Routes.Add(currentRoute);

            if (currentRoute.Destination == destination)
                return;

            var nextPossibleRoutes = GetNextPossibleRoutes(currentRoute);
            foreach (var nextRoute in nextPossibleRoutes)
                FindDestination(travel, nextRoute, destination);
        }

        private IList<RouteModel> GetNextPossibleRoutes(RouteModel currentRoute)
        {
            return routes
                .Where(w => w.Departure == currentRoute.Destination)
                .ToList();
        }

        private BestRouteResponse ReturnBestRoute(string departure)
        { 
            var travel = _travels
                .OrderBy(w => w.TotalDistance)
                .First();

            var bestRoute = new StringBuilder();
            bestRoute.Append(departure);

            foreach (var route in travel.Routes)
                bestRoute.Append($" - {route.Destination}");

            return new BestRouteResponse(bestRoute.ToString(), travel.TotalDistance);
        }
    }
}