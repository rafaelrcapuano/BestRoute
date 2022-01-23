using Microsoft.Extensions.DependencyInjection;
using BestRoute.Application.Interfaces.Repositories;
using BestRoute.Application.Interfaces.UseCases;
using BestRoute.Application.Interfaces.Validations;
using BestRoute.Application.UseCases.Route;
using BestRoute.Application.UseCases.Route.Validations;
using BestRoute.Infra.Data;

namespace BestRoute.Infra.CrossCutting
{
    public static class UseCaseExtensions
    {
        public static IServiceCollection AddUseCase(this IServiceCollection services, string filePath)
        {
            services.AddScoped<IGetBestRouteUseCase, GetBestRouteUseCase>();
            services.AddScoped<IRouteUseCase, RouteUseCase>();
            services.AddScoped<IRouteValidator, InsertRouteValidator>();
            services.AddScoped<IRouteRepository>(provider => new RouteRepository(filePath));

            return services;
        }
    }
}