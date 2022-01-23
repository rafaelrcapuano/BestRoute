namespace BestRoute.Domain
{
    public class RouteModel
    {
        public RouteModel(string departure, string destination, double distance)
        {
            Departure = departure;
            Destination = destination;
            Distance = distance;
        }

        public string Departure { get; }

        public string Destination { get; }

        public double Distance { get; }
    }
}