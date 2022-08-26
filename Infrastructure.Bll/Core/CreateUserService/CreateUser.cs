using Model.DtoModels;
using Model.Models;
using System;
using System.Security.Policy;
using System.Threading.Tasks;
using Infrastructure.Bll.Utils.EmailService;
using Infrastructure.Bll.Utils.UserProfileService;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Bll.Core.CreateUserService
{
    public class CreateUser : ICreateUser
    {
        private readonly IUserProfileService _userProfileService;
        private readonly UserManager<User> _userManager;

        public CreateUser(IUserProfileService userProfileService, UserManager<User> userManager)
        {
            _userProfileService = userProfileService;
            _userManager = userManager;
        }

        public async Task<IdentityResult> AddNewUser(CreateUserDto model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));

            var user = _userProfileService.ParseUserProfile(model.PinnedFile);
            user.UserName = model.Login;
            user.Email = model.Email;


            return await _userManager.CreateAsync(user, model.Password);
        }
    }
}
