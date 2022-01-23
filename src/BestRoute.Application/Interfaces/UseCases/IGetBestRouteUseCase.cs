using BestRoute.Application.UseCases.Route.Responses;

namespace BestRoute.Application.Interfaces.UseCases
{
    public interface IGetBestRouteUseCase
    {
        BestRouteResponse Get(string departure, string destination);
    }
}