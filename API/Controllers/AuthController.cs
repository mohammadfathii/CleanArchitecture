using JobFinder.Application.Common.Interfaces;
using JobFinder.Application.Employer.Commands.Create;
using JobFinder.Application.User.Commands.Create;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using JobFinder.Application.Common.Errors;
using System.Net;
using API.Models;
using MapsterMapper;

namespace JobFinder.API.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
    private readonly ITokenGenerator _tokenGenerator;
    private readonly ISender _sender;
    private readonly IMapper _mapper;

    public AuthController(ITokenGenerator tokenGenerator, ISender sender,IMapper mapper)
    {
        _tokenGenerator = tokenGenerator;
        _sender = sender;
        _mapper = mapper;
    }

    [HttpGet("/Register/User")]
    public async Task<IActionResult> RegisterUser(RegisterUserModel request)
    {
        // var command = _mapper.Map<CreateUserCommand>(request);

        var command = new CreateUserCommand(new CreateUserCommandDTO(request.FullName,request.UserName,request.Email,request.Password,Domain.UserAggregate.Enums.UserPermission.Employe));

        var result = await _sender.Send(command);
        var error = result.Errors[0];

        if (error != null && error is EntityExistsError) {
            return Problem(statusCode : (int)HttpStatusCode.Conflict,title : error.Message);
        }
        else if (error != null && error is ValidationError)
        {
            return Problem(statusCode: (int)HttpStatusCode.Conflict, title: error.Message);
        }

        var token = _tokenGenerator.GenerateUserToken(result.Value);
        return Ok(token);
    }

    [HttpGet("/Register/Employer")]
    public async Task<IActionResult> RegisterEmployer(RegisterEmployerModel request)
    {
        var command = _mapper.Map<CreateEmployerCommand>(request);

        var result = await _sender.Send(command);
        var error = result.Errors[0];

        if (error != null && error is EntityExistsError)
        {
            return Problem(statusCode: (int)HttpStatusCode.Conflict, title: error.Message);
        }
        else if (error != null && error is ValidationError)
        {
            return Problem(statusCode: (int)HttpStatusCode.Conflict, title: error.Message);
        }

        var token = _tokenGenerator.GenerateEmployerToken(result.Value);
        return Ok(token);
    }

}