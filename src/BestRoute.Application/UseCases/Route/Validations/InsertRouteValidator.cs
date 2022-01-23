using System.Collections.Generic;
using System.Linq;
using BestRoute.Application.Interfaces.Validations;
using BestRoute.Application.Resources;
using BestRoute.Application.UseCases.Route.Requests;

namespace BestRoute.Application.UseCases.Route.Validations
{
    public class InsertRouteValidator : IRouteValidator
    {
        private InsertRouteRequest request;

        public InsertRouteValidator()
        {
            Errors = new List<string>();
        }

        public IList<string> Errors { get; }

        public bool IsValid(InsertRouteRequest request)
        {
            this.request = request;

            ValidateDeparture();
            ValidateDestination();
            ValidateDistance();

            return !Errors.Any();
        }

        private void ValidateDeparture()
        {
            if (string.IsNullOrWhiteSpace(request.Departure))
                Errors.Add(string.Format(Messages.Required, nameof(request.Departure)));
        }

        private void ValidateDestination()
        {
            if (string.IsNullOrWhiteSpace(request.Destination))
                Errors.Add(string.Format(Messages.Required, nameof(request.Destination)));
        }

        private void ValidateDistance()
        {
            if (request.Distance == 0)
                Errors.Add(string.Format(Messages.MoreThanZero, nameof(request.Distance)));
        }
    }
}