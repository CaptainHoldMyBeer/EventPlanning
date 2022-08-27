using Infrastructure.Bll.Core.CreateUserService;
using Infrastructure.Bll.Core.LoginUserService;
using Infrastructure.Bll.Utils.EmailService;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Model;
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
        public async Task<int> AuthenticateUser(CreateUserDto existedUser)
        {
            try
            {
                return await _loginUser.LoginUser(existedUser);

            }
            catch (Exception)
            {
                throw new Exception("Error while login user.");
            }
        }

        [Route("register")]
        [HttpPost]
        public async Task<int> RegisterUser(CreateUserDto newUser)
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


                return addedUser.Id;
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
