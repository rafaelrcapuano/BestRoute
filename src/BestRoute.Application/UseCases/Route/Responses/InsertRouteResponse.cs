using System.Collections.Generic;

namespace BestRoute.Application.UseCases.Route.Responses
{
    public class InsertRouteResponse : UseCaseResponseMessage
    {
        public InsertRouteResponse(string departure, string destination, double distance)
        {
            Departure = departure;
            Destination = destination;
            Distance = distance;
        }

        public InsertRouteResponse(IEnumerable<string> errors) : base(errors)
        { }

        public string Departure { get; }
        
        public string Destination { get; }
        
        public double Distance { get; }
    }
}