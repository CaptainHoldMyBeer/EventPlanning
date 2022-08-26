using Microsoft.AspNetCore.Mvc;
using Model.DtoModels;
using Model.Models;

namespace EventPlanning.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [Route("authentificate")]
        [HttpGet]
        public IActionResult AuthentificateUser(User existedUser)
        {
            return Ok();
        }

        [Route("register")]
        [HttpPost]
        public IActionResult RegisterUser(CreateUserDto newUser)
        {
            return Ok("registration");
        }
    }
}
