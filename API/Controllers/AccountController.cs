using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        [HttpGet("/UserCheck")]
        [Authorize(AuthenticationSchemes = "UserScheme")]
        public IActionResult UserCheck()
        {
            return Ok("User");
        }
        [HttpGet("EmployerCheck")]
        [Authorize(AuthenticationSchemes = "EmployerScheme")]
        public IActionResult EmployerCheck()
        {
            return Ok("Employer");
        }
    }
}
