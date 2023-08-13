using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BuberBreakfast.Controllers;

[ApiController]
[Route("[controller]")]
public class ApiController : ControllerBase
{
    // Our own implementation of the Problem method
    // that takes a list of errors and uses the ControllerBase's Problem method
    // to return a custom Problem object
    protected IActionResult Problem(List<Error> errors)
    {
        // If all errors are validation errors, return a ValidationProblem 
        // with a ModelStateDictionary containing all the errors:
        if (errors.All(e => e.Type == ErrorType.Validation))
        {
            var modelStateDictionary = new ModelStateDictionary();
            
            errors.ForEach(e => modelStateDictionary.AddModelError(e.Code, e.Description));

            return ValidationProblem(modelStateDictionary);
        }

        // If there is an unexpected error, return a Problem without any details
        // (we don't want to leak any information about the error to the client)
        if(errors.Any(e => e.Type == ErrorType.Unexpected))
        {
            return Problem();
        }

        // Otherwise, return a Problem with the first error
        var firstError = errors.First();

        var statusCode = firstError.Type switch
        {
            ErrorType.NotFound => StatusCodes.Status404NotFound,
            ErrorType.Validation => StatusCodes.Status400BadRequest,
            ErrorType.Conflict => StatusCodes.Status409Conflict,
            _ => StatusCodes.Status500InternalServerError
        };

        return Problem(
            statusCode: statusCode,
            title: firstError.Description
            // detail: string.Join(Environment.NewLine, errors.Select(e => e.Description))
        );
    }
}