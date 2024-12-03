using JobFinder.Application.Common.Interfaces;
using JobFinder.Application.Employer.Commands.Create;
using JobFinder.Application.User.Commands.Create;
using JobFinder.Domain.UserAggregate.Enums;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using JobFinder.Application.Common.Errors;
using System.Net;

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

    [HttpGet("/Register/User")]
    public async Task<IActionResult> LoginUser()
    {
        var command = new CreateUserCommand(new CreateUserCommandDTO("mohammad fathi", "sdsdsadsas", "mohammadail@adsa.com", "12jhvbsdshv34", UserPermission.Admin));
        // var command = new TestUserCommand("Masdaso");

        var result = await _sender.Send(command);
        var error = result.Errors[0];

        if (error != null && error is EntityExistsError) {
            return Problem(statusCode : (int)HttpStatusCode.Conflict,title : error.Message);
        }

        var token = _tokenGenerator.GenerateUserToken(result.Value);
        return Ok(token);
    }

    [HttpGet("/Register/Employer")]
    public async Task<IActionResult> LoginEmployer()
    {
        var command = new CreateEmployerCommand(new CreateEmployerCommandDTO("TestCompany","testemil@gmail.com","090123122","asdasdsadasdasda","asdsadsadasdasdsadsa","asdsadksajdbnaskda"));

        var result = await _sender.Send(command);
        var error = result.Errors[0];

        if (error != null && error is EntityExistsError)
        {
            return Problem(statusCode: (int)HttpStatusCode.Conflict, title: error.Message);
        }

        var token = _tokenGenerator.GenerateEmployerToken(result.Value);
        return Ok(token);
    }

}