using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Model.DtoModels;

namespace Infrastructure.Bll.Core.LoginUserService
{
    public interface ILoginUserService
    {
        Task<int> LoginUser(CreateUserDto user);
    }
}
