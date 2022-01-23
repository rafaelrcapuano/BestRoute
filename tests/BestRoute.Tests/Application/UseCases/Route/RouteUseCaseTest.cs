using Moq;
using BestRoute.Application.Interfaces.Repositories;
using BestRoute.Application.Interfaces.Validations;
using BestRoute.Application.UseCases.Route;
using BestRoute.Application.UseCases.Route.Requests;
using BestRoute.Domain;
using Xunit;

namespace BestRoute.Tests.Application.UseCases.Route
{
    public class RouteUseCaseTest
    {
        private readonly Mock<IRouteValidator> _mockValidator;
        private readonly Mock<IRouteRepository> _mockRepository;
        private readonly RouteUseCase _useCase;
        private readonly InsertRouteRequest _request;

        public RouteUseCaseTest()
        {
            _mockValidator = new Mock<IRouteValidator>();
            _mockRepository = new Mock<IRouteRepository>();

            _useCase = new RouteUseCase(_mockValidator.Object, _mockRepository.Object);
            _request = new InsertRouteRequest();
        }

        private void SetupMockValidator(bool response)
        {
            _mockValidator
                .Setup(s => s.IsValid(_request))
                .Returns(response);
        }

        [Fact]
        public void InsertShouldNotBeValid()
        {
            SetupMockValidator(false);

            _useCase.Insert(_request);
            _mockRepository.Verify(v => v.Insert(It.IsAny<RouteModel>()), Times.Never);
        }

        [Fact]
        public void InsertShouldBeValid()
        {
            SetupMockValidator(true);

            _useCase.Insert(_request);
            _mockRepository.Verify(v => v.Insert(It.IsAny<RouteModel>()), Times.Once);            
        }
    }
}