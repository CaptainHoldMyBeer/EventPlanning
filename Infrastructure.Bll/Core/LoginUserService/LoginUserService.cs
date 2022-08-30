using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Model.DtoModels;
using Model.Models;

namespace Infrastructure.Bll.Core.LoginUserService
{
    public class LoginUserService: ILoginUserService
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        public LoginUserService(SignInManager<User> signInManager, UserManager<User> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }
        public async Task<int> LoginUser(UserDto user)
        {
            try
            {
                var loginResult = await _signInManager.PasswordSignInAsync(user.Login, user.Password, false, false);

                if (loginResult.Succeeded)
                {
                    return _userManager.Users.First(p => p.UserName == user.Login).Id;
                }
                else
                {
                    throw new ArgumentException();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    } 
}
