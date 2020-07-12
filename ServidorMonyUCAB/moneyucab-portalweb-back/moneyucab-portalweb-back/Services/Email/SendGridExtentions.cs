using Microsoft.Extensions.DependencyInjection;
using moneyucab_portalweb_back.Services;

namespace moneyucab_portalweb_back.Comandos.ComandosService.Utilidades.Email
{
    public static class SendGridExtentions
    {
        public static IServiceCollection AddSendGridEmailSender(this IServiceCollection services)
        {
            services.AddTransient<IEmailSender, SendGridEmailSender>();

            return services;
        }
    }
}
