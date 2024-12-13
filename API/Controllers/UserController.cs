using API.Models.User;
using JobFinder.Application.User.Queries.GetUser;
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

        [HttpGet]
        public async Task<IActionResult> Get() {
            var email = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;

            var query = new GetUserQuery(u => u.Email == email);

            var user = await _sender.Send(query);

            var result = _mapper.Map<UserProfileModel>(user);

            return Ok(result);
        }

    }
}
