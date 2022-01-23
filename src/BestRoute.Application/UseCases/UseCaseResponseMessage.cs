using System.Collections.Generic;
using System.Linq;

namespace BestRoute.Application.UseCases
{
    public abstract class UseCaseResponseMessage
    {
        public IEnumerable<string> Errors { get; }

        protected UseCaseResponseMessage() { }

        protected UseCaseResponseMessage(IEnumerable<string> errors)
        {
            Errors = errors;
        }

        protected UseCaseResponseMessage(string error)
        {
            Errors = new List<string> { error };
        }

        public bool IsValid()
        {
            return Errors == null || !Errors.Any();
        }
    }
}
