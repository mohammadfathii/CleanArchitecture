using JobFinder.Application.Common.Interfaces;
using JobFinder.Application.Employer.Commands.Create;
using JobFinder.Application.User.Commands.Create;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using JobFinder.Application.Common.Errors;
using System.Net;
using API.Models;
using MapsterMapper;
using JobFinder.Application.User.Queries.LoginUser;

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

    [HttpPost("/Register/User")]
    public async Task<IActionResult> RegisterUser([FromBody] RegisterUserModel request)
    {
        var command = _mapper.Map<CreateUserCommand>(request);

        var result = await _sender.Send(command);

        if (result.Errors[0] != null && result.Errors[0] is EntityExistsError) {
            return Problem(statusCode : (int)HttpStatusCode.Conflict,title : result.Errors[0].Message);
        }
        else if (result.Errors[0] != null && result.Errors[0] is ValidationError)
        {
            return Problem(statusCode: (int)HttpStatusCode.Conflict, title: result.Errors[0].Message);
        }

        var token = _tokenGenerator.GenerateUserToken(result.Value);
        return Ok(token);
    }

    [HttpPost("/Register/Employer")]
    public async Task<IActionResult> RegisterEmployer([FromBody] RegisterEmployerModel request)
    {
        var command = _mapper.Map<CreateEmployerCommand>(request);

        var result = await _sender.Send(command);

        if (result.Errors[0] != null && result.Errors[0] is EntityExistsError)
        {
            return Problem(statusCode: (int)HttpStatusCode.Conflict, title: result.Errors[0].Message);
        }else if (result.Errors[0] != null && result.Errors[0] is ValidationError)
        {
            return Problem(statusCode: (int)HttpStatusCode.Conflict, title: result.Errors[0].Message);
        }

        var token = _tokenGenerator.GenerateEmployerToken(result.Value);
        return Ok(token);
    }

    [HttpPost("/Login/User")]
    public async Task<IActionResult> LoginUser([FromBody] LoginUserModel request){
        var query = _mapper.Map<LoginUserQuery>(request);

        var user = await _sender.Send(query);

        if(user.Errors != null && user.Errors[0] is AuthenticationFaieldError){
            return Problem(statusCode : (int)HttpStatusCode.BadRequest,title : user.Errors[0].Message);
        }

        var token = _tokenGenerator.GenerateUserToken(user.Value);

        return Ok(token);
    }

    [HttpPost("/Login/Employer")]
    public IActionResult LoginEmployer(){

        return Ok();
    }


}