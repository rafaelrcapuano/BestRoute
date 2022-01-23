using BestRoute.Application.UseCases.Route.Validations;
using BestRoute.Tests.TestDataBuilders;
using Xunit;

namespace BestRoute.Tests.Application.UseCases.Route.Validations
{
    public class InsertRouteValidatorTest
    {
        private readonly InsertRouteValidator _validator;

        public InsertRouteValidatorTest()
        {
            _validator = new InsertRouteValidator();
        }

        [Fact]
        public void InsertRouteWithoutDepartureShouldNotBeValid()
        {
            var request = new InsertRouteRequestBuilder()
                .WithDestination()
                .WithDistance()
                .Build();
            
            Assert.False(_validator.IsValid(request));
        }

        [Fact]
        public void InsertRouteWithoutDestinationShouldNotBeValid()
        {
            var request = new InsertRouteRequestBuilder()
                .WithDeparture()
                .WithDistance()
                .Build();

            Assert.False(_validator.IsValid(request));
        }

        [Fact]
        public void InsertRouteWithoutDistanceShouldNotBeValid()
        {
            var request = new InsertRouteRequestBuilder()
                .WithDeparture()
                .WithDestination()
                .Build();

            Assert.False(_validator.IsValid(request));
        }

        [Fact]
        public void InsertRouteShouldBeValid()
        {
            var request = new InsertRouteRequestBuilder()
                .WithDeparture()
                .WithDestination()
                .WithDistance()
                .Build();

            Assert.True(_validator.IsValid(request));
        }
    }
}
