using System;
using System.Threading.Tasks;

namespace Infrastructure.Bll.Utils.EmailService
{
    public class EmailService : IEmailService
    {
        public async Task<bool> SendEmailAsync(string email, string subject, string message)
        {
            try
            {
                #region тестирование отправки сообщения с ссылкой

                //var mailMessage = new MailMessage("eventsnoreplytask@gmail.com", email, "Hello world", message);
                //mailMessage.IsBodyHtml = true;
                //var client = new SmtpClient("smtp.mailtrap.io", 2525)
                //{
                //    Credentials = new NetworkCredential("b897485e21ba67", "b09ede855c4065"),
                //    EnableSsl = true,

                //};
                //client.Send("eventsnoreplytask@gmail.com", email, "Подтверждение", message);

                await Task.Delay(100);


                return true;

                #endregion
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
