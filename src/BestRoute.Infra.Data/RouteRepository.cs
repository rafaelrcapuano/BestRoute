using System;
using System.Collections.Generic;
using System.IO;
using BestRoute.Application.Interfaces.Repositories;
using BestRoute.Domain;

namespace BestRoute.Infra.Data
{
    public class RouteRepository : IRouteRepository
    {
        private readonly string _filePath;

        public RouteRepository(string filePath)
        {
            _filePath = filePath;
        }

        public RouteModel Insert(RouteModel model)
        {
            var content = $"{Environment.NewLine}{model.Departure},{model.Destination},{model.Distance}";
            File.AppendAllText(_filePath, content);
            return model;
        }

        public IList<RouteModel> Get()
        {
            var routes = new List<RouteModel>();
            var fileLines = File.ReadAllLines(_filePath);

            foreach (var line in fileLines)
            {
                var content = line.Split(',');
                if (content.Length == 3)
                    routes.Add(new RouteModel(
                        content[0].ToUpperInvariant(), 
                        content[1].ToUpperInvariant(), 
                        Convert.ToDouble(content[2])));
            }

            return routes;
        }
    }
}
