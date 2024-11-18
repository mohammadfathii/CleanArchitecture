namespace JobFinder.API.Controllers;

using JobFinder.Application.Common.Errors;
using JobFinder.Application.Common.Interfaces;
using JobFinder.Application.User.Commands.Create;
using JobFinder.Domain.ResumeAggregate.ValueObjects;
using JobFinder.Domain.UserAggregate.Enums;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


[ApiController]
[Route("[controller]")]
public class HomeController : ControllerBase
{
  private ISender _sender;
  private ITokenGenerator _tokenGenerator;

  public HomeController(ISender sender, ITokenGenerator tokenGenerator)
  {
    _sender = sender;
    _tokenGenerator = tokenGenerator;
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
  [Authorize]
  [HttpGet("/Home/Authorize")]
  public async Task<string> NeedAuthorize()
  {
    return "hello";
  }

  [HttpGet("/Home/Login")]
  public async Task<string> Authorize()
  {
    var command = new CreateUserCommand(new CreateUserCommandDTO("mohammad asdsafathi", "edovosdasdsas", "mohaasdsadammad@gmail.com", "12jhvdasdsabhv34", UserPermission.Admin, ResumeId.CreateUnique()));

    var result = await _sender.Send(command);
    var token = _tokenGenerator.GenerateJWTToken(result.Value);
    return token;
  }

}
