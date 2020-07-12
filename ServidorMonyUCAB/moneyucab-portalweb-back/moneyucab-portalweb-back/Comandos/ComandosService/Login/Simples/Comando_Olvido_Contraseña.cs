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
    public class Comando_Olvido_Contraseña : Comando<Boolean>
    {

        private UserManager<Usuario> _userManager;
        private ForgotPasswordModel _model;
        private readonly ApplicationSettings _appSettings;
        private readonly string _clientBaseURI = "https://localhost:4200/#/";
        private IEmailSender _emailSender;

        public Comando_Olvido_Contraseña(UserManager<Usuario> UserManager, ForgotPasswordModel Model, ApplicationSettings AppSettings, IEmailSender EmailSender)
        {
            this._appSettings = AppSettings;
            this._userManager = UserManager;
            this._model = Model;
            this._emailSender = EmailSender;
        }

        async public Task<Boolean> Ejecutar()
        {

            try
            {
                await FabricaComandos.Fabricar_Cmd_Existencia_Usuario(_userManager, _model.email, _model.email, _model.email).Ejecutar();
            }
            catch (UsuarioExistenteException ex)
            {
                if (ex.codigo != 17)
                {
                    throw ex;
                }
            }
            var usuario = await _userManager.FindByEmailAsync(_model.email);
            // Se genera el codigo para confirmar el email del usuario recien creado
            var code = await _userManager.GeneratePasswordResetTokenAsync(usuario);
            // Se codifica el token para poder enviarlo por parametro
            var encodedToken = code.Replace("/", "_").Replace("+", "-").Replace("=", ".");
            // Busco el ID del template que será usado en el correo a enviar.
            var templateID = _appSettings.ConfirmAccountTemplateID;
            // Se crea el link que será anexado al template del correo
            var callbackURL = _clientBaseURI + "pw-reset/" + usuario.Id + "/" + encodedToken;

            // Se crea el mensaje con sus detalles para el envío
            var emailDetails = new SendEmailDetails
            {
                FromName = "MoneyUCAB",
                FromEmail = "moneyucab@gmail.com",
                ToName = usuario.UserName,
                ToEmail = usuario.Email,
                Subject = "MoneyUCAB - Restablece tu contraseña",
                TemplateID = templateID,
                TemplateData = new EmailData
                {
                    Name = usuario.UserName,
                    URL = callbackURL,
                    Message = "¿Has olvidado tu contraseña? ¡No te preocupes! " +
                              "Te enviamos este mensaje para que puedas restablecerla. " +
                              "Solo debes hacer click en el botón.",
                    ButtonTitle = "Restablecer contraseña"
                }
            };

            // Se envía el mensaje al correo del usuario registrado
            _emailSender.SendEmailAsync(emailDetails);
            return true;
        }

    }
}
