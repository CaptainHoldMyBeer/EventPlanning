using Microsoft.AspNetCore.Identity;
using Model.DtoModels;
using Model.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Bll.Core.CreateUserService
{
    public class CreateUser : ICreateUser
    {
        private readonly UserManager<User> _userManager;

        public CreateUser(UserManager<User> userManager)
        {
            _userManager = userManager;
        }


        public async Task<User> AddNewUser(UserDto model)
        {
            try
            {
                var user = GetUserFromModel(model);
                var addUserTask = await _userManager.CreateAsync(user, model.Password);

                if (addUserTask.Succeeded)
                {
                    var addedUser = _userManager.Users.First(p => p.UserName == user.UserName);

                    return addedUser;
                }
                else
                {
                    throw new Exception("Error while adding new user");
                }
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        private User GetUserFromModel(UserDto model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));

            var user = new User
            {
                UserName = model.Login,
                Email = model.Email,
                Name = model.Name,
                Surname = model.Surname,
                Age = model.Age,
                Address = model.Location
            };

            return user;
        }
    }
}
