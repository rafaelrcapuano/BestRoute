using System.ComponentModel.DataAnnotations;

namespace BestRoute.Application.UseCases.Route.Requests
{
    public class InsertRouteRequest
    {
        public string Departure { get; set; }

        public string Destination { get; set; }

        public double Distance { get; set; }
    }
}