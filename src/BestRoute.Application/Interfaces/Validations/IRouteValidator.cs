using System.Collections.Generic;
using BestRoute.Application.UseCases.Route.Requests;

namespace BestRoute.Application.Interfaces.Validations
{
    public interface IRouteValidator
    {
        IList<string> Errors { get; }

        bool IsValid(InsertRouteRequest request);
    }
}