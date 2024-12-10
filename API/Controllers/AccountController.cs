using JobFinder.Application.Common.Errors;
using JobFinder.Application.User.Commands.CreateUserResume;
using JobFinder.Application.User.Queries.GetUser;
using JobFinder.Domain.ResumeAggregate;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {

        private readonly ISender _sender;

        public AccountController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet("/UserCheck")]
        [Authorize(AuthenticationSchemes = "UserScheme")]
        public IActionResult UserCheck()
        {
            return Ok("User");
        }
        [HttpGet("/EmployerCheck")]
        [Authorize(AuthenticationSchemes = "EmployerScheme")]
        public IActionResult EmployerCheck()
        {
            return Ok("Employer");
        }

        [HttpGet("/Resume/Test")]
        public async Task<IActionResult> CreateUserResume()
        {
            var user = await _sender.Send(new GetUserQuery("babavoss"));
            
            var resume = await _sender.Send(new CreateUserResumeCommand(Resume.Create("testrdad@sasa.dsad","asdaasdassda","asddsadasdas",new List<JobFinder.Domain.SkillAggregate.ValueObjects.SkillId>()),user));

            if (resume.Errors != null && resume.Errors.Count > 0)
            {
                if (resume.Errors[0] is EntityExistsError)
                {
                    return Problem(statusCode:409,title : resume.Errors[0].Message);
                }
            }

            return Ok(resume);
        }
    }
}
