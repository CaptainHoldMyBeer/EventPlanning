using Infrastructure.Bll.Core.CreateUserService;
using Infrastructure.Bll.Core.LoginUserService;
using Infrastructure.Bll.Utils.EmailService;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Model.DtoModels;
using Model.Models;
using System;
using System.Threading.Tasks;

namespace EventPlanning.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ICreateUser _createUser;
        private readonly UserManager<User> _userManager;
        private readonly IEmailService _emailService;
        private readonly ILoginUserService _loginUser;
        public AuthController(ICreateUser createUser, UserManager<User> userManager, IEmailService emailService, ILoginUserService loginUser)
        {
            _createUser = createUser;
            _userManager = userManager;
            _emailService = emailService;
            _loginUser = loginUser;
        }
        [Route("login")]
        [HttpPost]
        public async Task<IActionResult> AuthenticateUser(UserDto existedUser)
        {
            try
            {
                var result = await _loginUser.LoginUser(existedUser);

                return Ok(result);

            }
            catch (ArgumentException)
            {
                return BadRequest("Invalid username/password combination");
            }
            catch (Exception)
            {
                return StatusCode(500, "error while login");
            }
        }

        [Route("register")]
        [HttpPost]
        public async Task<IActionResult> RegisterUser(UserDto newUser)
        {
            try
            {
                var addedUser = await _createUser.AddNewUser(newUser);
                var code = await _userManager.GenerateEmailConfirmationTokenAsync(addedUser);

                var callbackUrl = Url.Action(
                    "ConfirmEmail",
                    "Account",
                    new { userId = addedUser.Id, code = code },
                    protocol: HttpContext.Request.Scheme);

                await _emailService.SendEmailAsync(addedUser.Email, "Confirm your account",
                    $"Подтвердите регистрацию, перейдя по ссылке: <a href='{callbackUrl}'>link</a>");

                addedUser.EmailConfirmed = true;

                return Ok(addedUser.Id);
            }
            catch (Exception ex)
            {
                 return StatusCode(500);
            }
        }
    }
}
