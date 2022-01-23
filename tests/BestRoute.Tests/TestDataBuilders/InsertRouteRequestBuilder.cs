using BestRoute.Application.UseCases.Route.Requests;

namespace BestRoute.Tests.TestDataBuilders
{
    public class InsertRouteRequestBuilder
    {
        private readonly InsertRouteRequest _request;

        public InsertRouteRequestBuilder()
        {
            _request = new InsertRouteRequest();
        }

        public InsertRouteRequest Build()
        {
            return _request;
        }

        public InsertRouteRequestBuilder WithDeparture()
        {
            _request.Departure = "GRU";
            return this;
        }

        public InsertRouteRequestBuilder WithDestination()
        {
            _request.Destination = "ORL";
            return this;
        }

        public InsertRouteRequestBuilder WithDistance()
        {
            _request.Distance = 50;
            return this;
        }
    }
}
