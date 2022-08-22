using Microsoft.AspNetCore.Mvc;

namespace EventPlanning.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        [Route("register")]
        [HttpPost]
        public IActionResult RegisterUser()
        {
            return Ok("registration");
        }

        [Route("checkUser")]
        [HttpGet]
        public IActionResult CheckIfUserExists()
        {
            return Ok("check user");
        }
    }
}
