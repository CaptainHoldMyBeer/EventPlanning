using Microsoft.AspNetCore.Mvc;

namespace EventPlanning.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [Route("authentificate")]
        [HttpPost]
        public IActionResult AuthentificateUser()
        {
            return Ok("auth user");
        }

        [Route("logOut")]
        [HttpGet]
        public IActionResult LogOut()
        {
            return Ok("log out");
        }
    }
}
