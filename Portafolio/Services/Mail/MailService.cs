using MailKit.Security;
using MimeKit.Text;
using MimeKit;
using MailKit.Net.Smtp;
using Portafolio.Models;

namespace Portafolio.Services.Mail
{
    public class MailService : IMailService
    {
        private readonly IConfiguration _configuration;

        public MailService(IConfiguration configuration)
        {
              _configuration = configuration;
        }
        public async Task SendEmail(ContactDTO request)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse("xavierceagonzalez@gmail.com"));
            email.To.Add(MailboxAddress.Parse("xavierceagonzalez@gmail.com"));
            email.Subject = request.Subject;
            email.Body = new TextPart(TextFormat.Html)
            {
                Text = request.Message + "\n\nMail de contacto: "+request.Email + "\nTeléfono de contacto: +" + request.PhoneCode + " " + request.Phone
            };

            using var smtp = new SmtpClient();
            
            smtp.Connect(
                _configuration.GetSection("Email:Host").Value,
               Convert.ToInt32(_configuration.GetSection("Email:Port").Value),
               SecureSocketOptions.StartTls
                );


            smtp.Authenticate(_configuration.GetSection("Email:UserName").Value, _configuration.GetSection("Email:PassWord").Value);
            
            smtp.Send(email);
            smtp.Disconnect(true);


        }
    }
}
