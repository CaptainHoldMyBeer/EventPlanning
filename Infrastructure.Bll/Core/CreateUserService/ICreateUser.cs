using Model.DtoModels;
using Model.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Bll.Core.CreateUserService
{
    public interface ICreateUser
    {
        Task<IdentityResult> AddNewUser(CreateUserDto model);
    }
}
