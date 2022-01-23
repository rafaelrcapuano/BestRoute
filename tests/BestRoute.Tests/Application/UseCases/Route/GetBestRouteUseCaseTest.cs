using Moq;
using System.Collections.Generic;
using BestRoute.Application.Interfaces.Repositories;
using BestRoute.Application.UseCases.Route;
using BestRoute.Domain;
using Xunit;

namespace BestRoute.Tests.Application.UseCases.Route
{
    public class GetBestRouteUseCaseTest
    {
        private readonly Mock<IRouteRepository> _mockRepository;
        private readonly GetBestRouteUseCase _useCase;

        public GetBestRouteUseCaseTest()
        {
            _mockRepository = new Mock<IRouteRepository>();
            SetupMockRepository();

            _useCase = new GetBestRouteUseCase(_mockRepository.Object);
        }

        private void SetupMockRepository()
        {
            var routes = new List<RouteModel>
            {
                new RouteModel("GRU", "BRC", 10),
                new RouteModel("BRC", "SCL", 5),
                new RouteModel("GRU", "CDG", 75),
                new RouteModel("GRU", "SCL", 20),
                new RouteModel("GRU", "ORL", 56),
                new RouteModel("ORL", "CDG", 5),
                new RouteModel("SCL", "ORL", 20)
            };

            _mockRepository
                .Setup(s => s.Get())
                .Returns(routes);
        }

        [Fact]
        public void GetShouldReturnDefaultWithInvalidDeparture()
        {
            var bestRoute = _useCase.Get("BRA", "ORL");            
            Assert.Equal(default, bestRoute);
        }

        [Fact]
        public void GetShouldReturnDefaultWithInvalidDestination()
        {
            var bestRoute = _useCase.Get("GRU", "BRA");
            Assert.Equal(default, bestRoute);
        }

        [Fact]
        public void GetShouldReturnBestRoute()
        {
            var bestRoute = _useCase.Get("GRU", "CDG");
            Assert.Equal("GRU - BRC - SCL - ORL - CDG", bestRoute.Route);
            Assert.Equal(40, bestRoute.TotalDistance);
        }
    }
}
