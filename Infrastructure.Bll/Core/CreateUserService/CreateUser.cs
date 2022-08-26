using Model.DtoModels;
using Model.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Bll.Core.CreateUserService
{
    public class CreateUser : ICreateUser
    {
        public User AddNewUser(CreateUserDto request)
        {
            return new User();
        }
    }
}
