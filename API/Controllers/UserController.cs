using API.Models.Resume;
using API.Models.User;
using JobFinder.Application.Common.Errors;
using JobFinder.Application.User.Commands.CreateUserResume;
using JobFinder.Application.User.Queries.GetUser;
using JobFinder.Domain.ResumeAggregate;
using JobFinder.Domain.SkillAggregate.ValueObjects;
using JobFinder.Domain.UserAggregate;
using Mapster;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize(AuthenticationSchemes = "UserScheme")]
    public class UserController : ControllerBase
    {

        private readonly ISender _sender;
        private readonly IMapper _mapper;

        public UserController(ISender sender,IMapper mapper)
        {
            _sender = sender;
            _mapper = mapper;
        }

        [HttpGet("/User")]
        public async Task<IActionResult> Get() {
            var email = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;

            var query = new GetUserQuery(u => u.Email == email);

            var user = await _sender.Send(query);

            var result = _mapper.Map<UserProfileModel>(user);

            return Ok(result);
        }

        [HttpPost("/User/Resume")]
        public async Task<IActionResult> CreateResume([FromBody] CreateResumeModel resume)
        {
            var email = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;

            var query = new GetUserQuery(u => u.Email == email);

            var user = await _sender.Send(query);

            var command = new CreateUserResumeCommand(Resume.Create(resume.Email,resume.PhoneNumber,resume.City,resume.SkillIds == null ? new List<SkillId>() : resume.SkillIds),user);

            var result = await _sender.Send(command);

            if (result.IsFailed)
            {
                if (result.Errors[0] is ValidationError)
                {
                    return Problem(statusCode: 409, title: result.Errors[0].Message);
                }
            }

            return Ok(_mapper.Map<UserProfileModel>(user));
        }

    }
}
