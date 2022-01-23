using BestRoute.Application.Interfaces.Repositories;
using BestRoute.Application.Interfaces.UseCases;
using BestRoute.Application.Interfaces.Validations;
using BestRoute.Application.UseCases.Route.Requests;
using BestRoute.Application.UseCases.Route.Responses;
using BestRoute.Domain;

namespace BestRoute.Application.UseCases.Route
{
    public class RouteUseCase : IRouteUseCase
    {
        private readonly IRouteValidator _validator;
        private readonly IRouteRepository _repository;

        public RouteUseCase(IRouteValidator validator, IRouteRepository repository)
        {
            _validator = validator;
            _repository = repository;
        }

        public InsertRouteResponse Insert(InsertRouteRequest request)
        {
            if (!_validator.IsValid(request))
                return new InsertRouteResponse(_validator.Errors);

            var model = new RouteModel(request.Departure, request.Destination, request.Distance);
            _repository.Insert(model);
            return new InsertRouteResponse(model.Departure, model.Destination, model.Distance);
        }
    }
}