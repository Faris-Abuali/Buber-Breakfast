using Microsoft.AspNetCore.Mvc;

namespace BuberBreakfast.Controllers;


public class ErrorsController : ControllerBase
{
    [HttpGet("/error")]
    public IActionResult Error()
    {
        return Problem();
    }
}