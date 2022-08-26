using Model.DtoModels;
using NPOI.HSSF.UserModel;
using System.IO;
using System.Net.Http.Headers;
using System.Text;
using NPOI.XSSF.UserModel;

namespace Infrastructure.Bll.Utils.FileService
{
    public static class FileHelper
    {
        public static XSSFWorkbook GetExcelFromPinnedFile(PinnedFile file)
        {
            var bytes = Encoding.UTF8.GetBytes(file.Src);
            var stream = new MemoryStream(bytes);

            using (var fs = new FileStream("C:\\Users\\dodma\\Downloads\\template.xlsx", FileMode.OpenOrCreate))
            {
                var asd = new XSSFWorkbook(fs);

                return asd;
            }

            

            return null;
        }
    }
}
