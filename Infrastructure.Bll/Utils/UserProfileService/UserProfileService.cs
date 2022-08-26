using Model.DtoModels;
using Model.Models;
using NPOI.HSSF.UserModel;
using System.IO;
using System.Text;

namespace Infrastructure.Bll.Utils.UserProfileService
{
    public class UserProfileService : IUserProfileService
    {
        public User ParseUserProfile(PinnedFile file)
        {
            var bytes = Encoding.UTF8.GetBytes(file.Src);
            Stream stream = new MemoryStream(bytes);
            var tmp = new HSSFWorkbook(stream);
        }
    }
}
