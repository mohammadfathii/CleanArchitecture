using JobFinder.Application.Common.Interfaces;
using JobFinder.Application.User.Commands.Create;
using JobFinder.Domain.UserAggregate.Enums;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace JobFinder.API.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
    private readonly ITokenGenerator _tokenGenerator;
    private readonly ISender _sender;

    public AuthController(ITokenGenerator tokenGenerator, ISender sender)
    {
        _tokenGenerator = tokenGenerator;
        _sender = sender;
    }

    [HttpGet("/Login/User")]
    public async Task<IActionResult> LoginUser()
    {
        var command = new CreateUserCommand(new CreateUserCommandDTO("mohammad fathi", "ss", "mohammadail.com", "12jhvbhv34", UserPermission.Admin));
        // var command = new TestUserCommand("Masdaso");

        var result = await _sender.Send(command);
        var errors = result.Errors;
        var token = _tokenGenerator.GenerateUserToken(result.Value);
        return Ok(token);
    }

    [HttpGet("/Login/Employer")]
    public async Task<IActionResult> LoginEmployer()
    {
        var command = new CreateUserCommand(new CreateEmployerCommand("mohammad fathi", "ss", "mohammadail.com", "12jhvbhv34", UserPermission.Admin));
        // var command = new TestUserCommand("Masdaso");

        var result = await _sender.Send(command);
        var errors = result.Errors;
        var token = _tokenGenerator.GenerateUserToken(result.Value);
        return Ok(token);
    }

}