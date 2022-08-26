using Infrastructure.Bll.Utils.FileService;
using Model.DtoModels;
using Model.Models;

namespace Infrastructure.Bll.Utils.UserProfileService
{
    public class UserProfileService : IUserProfileService
    {
        public User ParseUserProfile(PinnedFile file)
        {
            var workbook = FileHelper.GetExcelFromPinnedFile(file);


            var sheet = workbook.GetSheetAt(0);

            var user = new User()
            { 
                Name = sheet.GetRow(1).GetCell(1).StringCellValue,
                Surname = sheet.GetRow(2).GetCell(1).StringCellValue,
                Age = (int)sheet.GetRow(3).GetCell(1).NumericCellValue, 
                Address = sheet.GetRow(4).GetCell(1).StringCellValue,
            };


            return user;
        }
    }
}
