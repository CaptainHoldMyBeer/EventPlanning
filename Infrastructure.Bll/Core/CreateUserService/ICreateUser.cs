using Model.DtoModels;
using Model.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Bll.Core.CreateUserService
{
    public interface ICreateUser
    {
        User AddNewUser(CreateUserDto requuest);
    }
}
