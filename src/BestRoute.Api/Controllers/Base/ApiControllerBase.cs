using Microsoft.AspNetCore.Mvc;
using BestRoute.Application.UseCases;

namespace BestRoute.Api.Controllers.Base
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public abstract class ApiControllerBase : ControllerBase
    {
        protected IActionResult PostResponse(string action, UseCaseResponseMessage response)
        {
            if (!response.IsValid())
                return BadRequest(response.Errors);

            return CreatedAtAction(action, response);            
        }

        protected IActionResult GetResponse(UseCaseResponseMessage response)
        {
            if (response == null)
                return NoContent();

            return Ok(response);
        }
    }
}
