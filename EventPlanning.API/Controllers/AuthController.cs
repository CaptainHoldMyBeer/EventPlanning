using System;
using System.Threading.Tasks;
using Infrastructure.Bll.Core.CreateUserService;
using Infrastructure.Bll.Utils.EmailService;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Model.DtoModels;
using Model.Models;

namespace EventPlanning.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ICreateUser _createUser;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IEmailService _emailService;
        public AuthController(ICreateUser createUser, UserManager<User> userManager, SignInManager<User> signInManager, IEmailService emailService)
        {
            _createUser = createUser;
            _userManager = userManager;
            _signInManager = signInManager;
            _emailService = emailService;
        }
        [Route("authentificate")]
        [HttpGet]
        public IActionResult AuthentificateUser(User existedUser)
        {
            return Ok();
        }

        [Route("register")]
        [HttpPost]
        public async Task<User> RegisterUser(CreateUserDto newUser)
        {
            try
            {
                var addedUser = new User();
                var addingUserTask = await _createUser.AddNewUser(newUser);

                if (addingUserTask.Succeeded)
                {

                    addedUser = await _userManager.FindByEmailAsync(newUser.Email);
                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(addedUser);

                    var callbackUrl = Url.Action(
                        "ConfirmEmail",
                        "Account",
                        new {userId = addedUser.Id, code = code},
                        protocol: HttpContext.Request.Scheme);

                    await _emailService.SendEmailAsync(addedUser.Email, "Confirm your account",
                        $"Подтвердите регистрацию, перейдя по ссылке: <a href='{callbackUrl}'>link</a>");
                    addedUser.EmailConfirmed = true;
                }

                return addedUser;
            }
            catch (ArgumentNullException ex)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new Exception("Error while adding new User.");
            }
        }
    }
}
