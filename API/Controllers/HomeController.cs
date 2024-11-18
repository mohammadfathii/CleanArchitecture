using JobFinder.Application.Common.Errors;
using JobFinder.Application.User.Commands.Create;
using JobFinder.Domain.Resume.ValueObjects;
using JobFinder.Domain.User.Enums;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace JobFinder.API.Controllers;

[ApiController]
[Route("[controller]")]
public class HomeController : ControllerBase
{
  private ISender _sender;

  public HomeController(ISender sender)
  {
    _sender = sender;
  }

  [HttpGet("/Home/Get")]
  public async Task<IActionResult> Home()
  {
    var command = new CreateUserCommand(new CreateUserCommandDTO("mohammad fathi", "edovoss", "mohammad@gmail.com", "12jhvbhv34", UserPermission.Admin, ResumeId.CreateUnique()));
    // var command = new TestUserCommand("Masdaso");

    var result = await _sender.Send(command);
    var errors = result.Errors;

    // handling errors
    if (!result.IsSuccess && errors[0] is ValidationError)
    {
      return Problem(statusCode: 409, title: errors[0].Message);
    }
    else if (!result.IsSuccess)
    {
      return Problem(statusCode: 500, title: "there is some error");
    }

    return Ok(result.Value);
  }
}
