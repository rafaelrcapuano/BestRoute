namespace BestRoute.Application.UseCases.Route.Responses
{
    public class BestRouteResponse : UseCaseResponseMessage
    {
        public BestRouteResponse(string route, double totalDistance)
        {
            Route = route;
            TotalDistance = totalDistance;
        }

        public string Route { get; }

        public double TotalDistance { get; }
    }
}