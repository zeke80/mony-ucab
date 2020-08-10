using Comandos;
using Excepciones.Excepciones_Especificas;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using moneyucab_portalweb_back.EntitiesForm;
using moneyucab_portalweb_back.Models;
using moneyucab_portalweb_back.Services.PagoExterno;
using PayPal.Api;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace moneyucab_portalweb_back.Comandos.ComandosService.Login.Simples
{
    //Este comando retorna el token de inicio de sesión
    public class Comando_Crear_Pago_Paypal : Comando<Payment>
    {

        private string _baseUrl;
        private string _intent;
        private Payment _listaT;

        public Comando_Crear_Pago_Paypal(string BaseUrl, string Intent, Payment ListaT)
        {
            this._baseUrl = BaseUrl;
            this._intent = Intent;
            this._listaT = ListaT;
        }


        async public Task<Payment> Ejecutar()
        {
            Payment payment = PaypalPaymentService.CreatePayment(this._baseUrl, this._intent, this._listaT);
            return payment;
        }

    }
}
