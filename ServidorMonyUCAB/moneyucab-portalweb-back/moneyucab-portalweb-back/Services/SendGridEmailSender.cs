using Microsoft.Extensions.Options;
using moneyucab_portalweb_back.Comandos.ComandosService.Utilidades.Email;
using moneyucab_portalweb_back.Models;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;

namespace moneyucab_portalweb_back.Services
{
    public class SendGridEmailSender : IEmailSender
    {
        private readonly ApplicationSettings _applicationSettings;
        public SendGridEmailSender(IOptions<ApplicationSettings> applicationSettings)
        {
            _applicationSettings = applicationSettings.Value;
        }

        public async Task<SendEmailResponse> SendEmailAsync(SendEmailDetails emailDetails)
        {

            // Busco código de la API de SendGrid
            var apiKey = _applicationSettings.SendGridKey;

            // Se crea el cliente
            var client = new SendGridClient(apiKey);

            // Se crea un nuevo mensaje de SendGrid
            var sendGridMessage = new SendGridMessage();

            // Se prepara el mensaje con la info necesaria
            sendGridMessage.SetFrom(emailDetails.FromEmail, emailDetails.FromName);
            sendGridMessage.AddTo(emailDetails.ToEmail, emailDetails.ToName);
            sendGridMessage.SetSubject(emailDetails.Subject);
            sendGridMessage.SetTemplateId(emailDetails.TemplateID);
            sendGridMessage.SetTemplateData(emailDetails.TemplateData);

            // Se envía el mensaje
            var response = await client.SendEmailAsync(sendGridMessage);

            return new SendEmailResponse();
        }

    }
}
