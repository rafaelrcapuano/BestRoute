using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using BestRoute.Api.Controllers;
using BestRoute.Application.Interfaces.UseCases;
using BestRoute.Application.UseCases.Route.Requests;
using BestRoute.Application.UseCases.Route.Responses;
using Xunit;

namespace BestRoute.Tests.Api
{
    public class RouteControllerTest
    {
        private readonly Mock<IRouteUseCase> _mockRouteUseCase;
        private readonly Mock<IGetBestRouteUseCase> _mockGetBestRouteUseCase;
        private readonly RouteController _controller;

        public RouteControllerTest()
        {
            _mockRouteUseCase = new Mock<IRouteUseCase>();
            _mockGetBestRouteUseCase = new Mock<IGetBestRouteUseCase>();

            _controller = new RouteController(_mockRouteUseCase.Object, _mockGetBestRouteUseCase.Object);
        }

        [Fact]
        public void InsertShouldReturnBadRequest()
        {
            var request = new InsertRouteRequest();
            var errors = new List<string> { "Error message" };

            _mockRouteUseCase
                .Setup(s => s.Insert(request))
                .Returns(new InsertRouteResponse(errors));
            
            var actionResult = _controller.Insert(request);
            _mockRouteUseCase.Verify(v => v.Insert(request), Times.Once);

            Assert.IsType<BadRequestObjectResult>(actionResult);
        }

        [Fact]
        public void InsertShouldReturnCreated()
        {
            var request = new InsertRouteRequest();

            _mockRouteUseCase
                .Setup(s => s.Insert(request))
                .Returns(new InsertRouteResponse("SCL", "ORL", 20));

            var actionResult = _controller.Insert(request);
            _mockRouteUseCase.Verify(v => v.Insert(request), Times.Once);

            Assert.IsType<CreatedAtActionResult>(actionResult);
        }

        [Fact]
        public void GetShouldReturnNoContent()
        {
            var departure = "GRU";
            var destination = "CDG";

            var actionResult = _controller.Get(departure, destination);
            _mockGetBestRouteUseCase.Verify(v => v.Get(departure, destination), Times.Once);

            Assert.IsType<NoContentResult>(actionResult);
        }

        [Fact]
        public void GetShouldReturnOk()
        {
            var departure = "GRU";
            var destination = "CDG";

            _mockGetBestRouteUseCase
                .Setup(s => s.Get(departure, destination))
                .Returns(new BestRouteResponse("GRU - BRC - SCL - ORL - CDG", 40));

            var actionResult = _controller.Get(departure, destination);
            _mockGetBestRouteUseCase.Verify(v => v.Get(departure, destination), Times.Once);

            Assert.IsType<OkObjectResult>(actionResult);            
        }
    }
}