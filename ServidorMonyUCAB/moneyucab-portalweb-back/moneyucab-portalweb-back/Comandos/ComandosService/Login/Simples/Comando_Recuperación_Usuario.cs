using Comandos;
using Microsoft.AspNetCore.Identity;
using moneyucab_portalweb_back.Comandos.ComandosService.Utilidades.Email;
using Excepciones.Excepciones_Especificas;
using moneyucab_portalweb_back.EntitiesForm;
using moneyucab_portalweb_back.Models;
using System;
using System.Threading.Tasks;

namespace moneyucab_portalweb_back.Comandos.ComandosService.Login.Simples
{
    public class Comando_Recuperacion_Usuario : Comando<Boolean>
    {

        private UserManager<Usuario> _userManager;
        private string _email;
        private readonly ApplicationSettings _appSettings;
        private readonly string _clientBaseURI = "https://localhost:4200/#/";
        private IEmailSender _emailSender;

        public Comando_Recuperacion_Usuario(UserManager<Usuario> UserManager, string Email, ApplicationSettings AppSettings, IEmailSender EmailSender)
        {
            this._appSettings = AppSettings;
            this._userManager = UserManager;
            this._email = Email;
            this._emailSender = EmailSender;
        }

        async public Task<Boolean> Ejecutar()
        {

            try
            {
                await FabricaComandos.Fabricar_Cmd_Existencia_Usuario(_userManager, _email, _email, _email).Ejecutar();
            }
            catch (UsuarioExistenteException ex)
            {
                if (ex.codigo != 17)
                {
                    throw ex;
                }
            }
            var usuario = await _userManager.FindByEmailAsync(_email);
            // Busco el ID del template que será usado en el correo a enviar.
            var templateID = _appSettings.ConfirmAccountTemplateID;
            // Se crea el link que será anexado al template del correo
            var callbackURL = _clientBaseURI + "/";

            // Se crea el mensaje con sus detalles para el envío
            var emailDetails = new SendEmailDetails
            {
                FromName = "MoneyUCAB",
                FromEmail = "moneyucab@gmail.com",
                ToName = usuario.UserName,
                ToEmail = usuario.Email,
                Subject = "MoneyUCAB - Restablece tu usuario",
                TemplateID = templateID,
                TemplateData = new EmailData
                {
                    Name = usuario.UserName,
                    URL = callbackURL,
                    Message = "Este es el nombre de usuario vinculado a tu email:" +
                              usuario.UserName,
                }
            };

            // Se envía el mensaje al correo del usuario registrado
            _emailSender.SendEmailAsync(emailDetails);
            return true;
        }

    }
}
