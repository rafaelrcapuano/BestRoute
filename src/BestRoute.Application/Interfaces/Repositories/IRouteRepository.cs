using System.Collections.Generic;
using BestRoute.Domain;

namespace BestRoute.Application.Interfaces.Repositories
{
    public interface IRouteRepository
    {
        RouteModel Insert(RouteModel model);

        IList<RouteModel> Get();
    }
}