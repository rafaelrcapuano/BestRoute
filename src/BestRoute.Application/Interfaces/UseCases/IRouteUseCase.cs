using BestRoute.Application.UseCases.Route.Requests;
using BestRoute.Application.UseCases.Route.Responses;

namespace BestRoute.Application.Interfaces.UseCases
{
    public interface IRouteUseCase
    {
        InsertRouteResponse Insert(InsertRouteRequest request);        
    }
}