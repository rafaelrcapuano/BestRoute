using Microsoft.AspNetCore.Mvc;
using BestRoute.Api.Controllers.Base;
using BestRoute.Application.Interfaces.UseCases;
using BestRoute.Application.UseCases.Route.Requests;

namespace BestRoute.Api.Controllers
{
    public class RouteController : ApiControllerBase
    {
        private readonly IRouteUseCase _insertRouteUseCase;
        private readonly IGetBestRouteUseCase _getBestRouteUseCase;

        public RouteController(IRouteUseCase insertRouteUseCase,
            IGetBestRouteUseCase getBestRouteUseCase)
        {
            _insertRouteUseCase = insertRouteUseCase;
            _getBestRouteUseCase = getBestRouteUseCase;
        }

        [HttpPost]
        public IActionResult Insert([FromBody]InsertRouteRequest request)
        {
            var route = _insertRouteUseCase.Insert(request);
            return PostResponse(nameof(Insert), route);
        }

        [HttpGet("{departure}/{destination}")]
        public IActionResult Get(string departure, string destination)
        {
            var bestRoute = _getBestRouteUseCase.Get(departure, destination);
            return GetResponse(bestRoute);
        }
    }
}