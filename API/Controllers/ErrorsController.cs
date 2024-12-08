using Microsoft.AspNetCore.Mvc;

namespace JobFinder.API.Controllers;

[ApiController]
[Route("[controller]")]
public class ErrorsController : ControllerBase
{
  [HttpGet("/error")]
  public IActionResult Error(){
    

    return Problem();
  }

}
