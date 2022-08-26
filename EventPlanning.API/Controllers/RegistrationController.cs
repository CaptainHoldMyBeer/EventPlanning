using Infrastructure.Bll.Utils.EmailService;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Model;
using Model.Models;
using System;
using System.Threading.Tasks;

namespace EventPlanning.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IEmailService _emailService;
        private readonly ApplicationContext cont;

        public RegistrationController(UserManager<User> userManager, SignInManager<User> signInManager/*, EmailService emailService*/, ApplicationContext context)
        {
            
            
            _userManager = userManager;
            _signInManager = signInManager;

            cont = context;
            //var tmp = cont.Events;
            ////_emailService = emailService;
            //cont.Events.Add(new Event
            //{
            //    Date = DateTime.Today,
            //    Location = "asdsads",
            //    Title = "asdasddddd"
            //});
        }

        [Route("register")]
        [HttpPost]
        public IActionResult RegisterUser()
        {
            return Ok("registration");
        }

        [Route("checkUser")]
        [HttpGet]
        public async Task<IActionResult> CheckIfUserExists()
        {
            try
            {
                var user = _userManager.FindByEmailAsync("luperkalfan@gmail.com").Result;

                var result = true;

                if (result)
                {
                    var code = _userManager.GenerateEmailConfirmationTokenAsync(user).Result;

                    var tmp =  _userManager.ConfirmEmailAsync(user, code).Result;

                    var callbackUrl = Url.Action(
                            "ConfirmEmail",
                            "Account",
                            new { userId = user.Id, code = code },
                            protocol: HttpContext.Request.Scheme);
                    EmailService emailService = new EmailService();
                    await emailService.SendEmailAsync(user.Email, "Confirm your account",
                        $"Подтвердите регистрацию, перейдя по ссылке: <a href='{callbackUrl}'>link</a>");

                    user.EmailConfirmed = true;

                    return Ok("Для завершения регистрации проверьте электронную почту и перейдите по ссылке, указанной в письме");
                }


                return Ok("check user");
            }
            catch(Exception ex)
            {
                throw;
            }
        }
    }
}
