using System.Threading.Tasks;

namespace moneyucab_portalweb_back.Comandos.ComandosService.Utilidades.Email
{
    public interface IEmailSender
    {
        // Send email with given information
        //Task<SendEmailResponse> SendEmailAsync(string templateID, string userEmail, string userName, string emailSubject, string message);
        Task<SendEmailResponse> SendEmailAsync(SendEmailDetails emailDetails);

    }
}
