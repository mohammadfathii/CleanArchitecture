namespace JobFinder.API.Controllers;

using JobFinder.Application.User.Queries.GetUser;
using JobFinder.Application.User.Commands.Create;
using JobFinder.Application.Common.Interfaces;
using JobFinder.Domain.UserAggregate.Enums;
using JobFinder.Application.Common.Errors;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MediatR;

[ApiController]
[Route("[controller]")]
public class HomeController : ControllerBase
{
  private ISender _sender;
  private ITokenGenerator _tokenGenerator;

  private static string userId = "";

  public HomeController(ISender sender, ITokenGenerator tokenGenerator)
  {
    _sender = sender;
    _tokenGenerator = tokenGenerator;
  }

  [HttpGet("/Home/Get")]
  public async Task<IActionResult> Home()
  {
    var command = new CreateUserCommand(new CreateUserCommandDTO("mohammad fathi", "edovoss", "mohammad@gmail.com", "12jhvbhv34", UserPermission.Admin));
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
  [HttpGet("/Authorize")]
  public async Task<string> NeedAuthorize()
  {
    await Task.CompletedTask;
    return "hello";
  }

  [HttpGet("/Register")]
  public async Task<string> Register()
  {
    var command = new CreateUserCommand(new CreateUserCommandDTO("mohammad asdsafathi", "edovosdasdsas", "mohaasdsadammad@gmail.com", "12jhvdasdsabhv34", UserPermission.Admin));

    var result = await _sender.Send(command);
    return result.Value.Id.Value.ToString();
  }

  [HttpGet("/Login")]
  public async Task<IActionResult> Login()
  {
    var query = new GetUserQuery(userId);
    var user = await _sender.Send(query);
    if (user is null)
    {
      return Problem(statusCode: 404, title: "user not founded !");
    }
    var token = _tokenGenerator.GenerateJWTToken(user);
    return Ok(token);
  }

}
