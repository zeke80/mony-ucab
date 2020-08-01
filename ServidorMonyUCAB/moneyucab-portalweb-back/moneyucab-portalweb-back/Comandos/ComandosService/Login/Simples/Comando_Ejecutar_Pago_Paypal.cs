using Comandos;
using Excepciones.Excepciones_Especificas;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using moneyucab_portalweb_back.EntitiesForm;
using moneyucab_portalweb_back.Models;
using moneyucab_portalweb_back.Services.PagoExterno;
using PayPal.Api;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace moneyucab_portalweb_back.Comandos.ComandosService.Login.Simples
{
    //Este comando retorna el token de inicio de sesión
    public class Comando_Ejecutar_Pago_Paypal : Comando<Payment>
    {

        private string _paymentId;
        private string _payerId;

        public Comando_Ejecutar_Pago_Paypal(string PaymentId, string PayerId)
        {
            this._paymentId = PaymentId;
            this._payerId = PayerId;
        }


        async public Task<Payment> Ejecutar()
        {
            Payment payment = PaypalPaymentService.ExecutePayment(this._paymentId, this._payerId);
            return payment;
        }

    }
}
