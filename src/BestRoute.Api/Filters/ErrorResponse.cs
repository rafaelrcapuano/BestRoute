using System;
using System.Collections.Generic;

namespace BestRoute.Api.Filters
{
    public class ErrorResponse
    {
        public ErrorResponse()
        {
            var errors = new List<string>();
            errors.Add("Something didn't go as expected... Please, check if the file routes are formatted correctly.");
            Errors = errors;
        }

        public IEnumerable<string> Errors { get; set; }

        public Exception DeveloperMessage { get; set; }
    }
}