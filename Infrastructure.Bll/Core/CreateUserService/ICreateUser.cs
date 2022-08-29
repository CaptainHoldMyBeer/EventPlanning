using Model.DtoModels;
using Model.Models;
using System.Threading.Tasks;

namespace Infrastructure.Bll.Core.CreateUserService
{
    public interface ICreateUser
    {
        Task<User> AddNewUser(UserDto model);
    }
}
