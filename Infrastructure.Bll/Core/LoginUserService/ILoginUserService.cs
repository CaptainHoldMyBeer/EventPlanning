using Model.DtoModels;
using System.Threading.Tasks;

namespace Infrastructure.Bll.Core.LoginUserService
{
    public interface ILoginUserService
    {
        Task<int> LoginUser(UserDto user);
    }
}
