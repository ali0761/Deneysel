using CicekSepeti.Core.Entities;
using System.Net;
using System.Net.Mail;


namespace CicekSepeti.WebUI.Utils
{
    public class MailHelper
    {

        public static async Task SendMailAsync(Contact contact)
        {
            SmtpClient smtpClient = new SmtpClient("mail.siteminadiolacak.com",587);
            smtpClient.Credentials = new NetworkCredential("info@siteadiolacak.com","mailiiminşifresiolacak");
            smtpClient.EnableSsl = false;
            MailMessage message = new MailMessage();
            message.From = new MailAddress("info@siteadiolacak.com");
            message.To.Add("bilgi@siteadiolacak.com");
            message.Subject = "Siteden mesaj geldi";
            message.Body = $"İsim: {contact.Name} - Soyisim: {contact.Surname} - Email: {contact.Email} - Telefon: {contact.Phone} - Mesaj: {contact.Message}";
            message.IsBodyHtml = true;
            await smtpClient.SendMailAsync(message);
            smtpClient.Dispose();
        }
    }
}
