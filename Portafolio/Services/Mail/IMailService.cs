using Portafolio.Models;

namespace Portafolio.Services.Mail
{
    public interface IMailService
    {
        Task SendEmail(ContactDTO request);
    }
}
