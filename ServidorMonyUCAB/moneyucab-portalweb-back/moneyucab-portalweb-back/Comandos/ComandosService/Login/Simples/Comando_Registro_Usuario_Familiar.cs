using Comandos;
using Excepciones;
using Microsoft.AspNetCore.Identity;
using moneyucab_portalweb_back.Comandos.ComandosService.Utilidades.Email;
using moneyucab_portalweb_back.EntitiesForm;
using moneyucab_portalweb_back.Models;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace moneyucab_portalweb_back.Comandos.ComandosService.Login.Simples
{
    public class Comando_Registro_Usuario_Familiar : Comando<Object>
    {

        private UserManager<Usuario> _userManager;
        private RegistrationModel _userModel;
        private readonly ApplicationSettings _appSettings;
        private IEmailSender _emailSender;

        private readonly string _clientBaseURI = "https://localhost:4200/#/";

        public Comando_Registro_Usuario_Familiar(UserManager<Usuario> UserManager, RegistrationModel UserModel, ApplicationSettings AppSettings, IEmailSender EmailSender)
        {
            this._userManager = UserManager;
            this._userModel = UserModel;
            this._appSettings = AppSettings;
            this._emailSender = EmailSender;
        }

        async public Task<Object> Ejecutar()
        {
            // Se crea el objeto del usuario a registrar
            var usuario = new Usuario()
            {
                UserName = _userModel.usuario,
                Email = _userModel.email,
                SignupDate = DateTime.Now
            };
            // Se crea el usuario en la base de datos
            var result = await _userManager.CreateAsync(usuario, _userModel.password);

            //Se debe ingresar en este punto la validación DAO con el sistema propio y no con Identity
            try
            {
                await FabricaComandos.Fabricar_Cmd_Registro_Usuario_Familiar_DAO(_userModel).Ejecutar();
            }
            catch(Exception ex)
            {
                await _userManager.DeleteAsync(usuario);
                throw ex;
            }
            //-------------------------------------------------------

            // Se genera el codigo para confirmar el email del usuario recien creado
            var code = await _userManager.GenerateEmailConfirmationTokenAsync(usuario);
            // Se codifica el token para poder enviarlo por parametro
            var encodedToken = code.Replace("/", "_").Replace("+", "-").Replace("=", ".");
            // Busco el ID del template que será usado en el correo a enviar.
            var templateID = _appSettings.ConfirmAccountTemplateID;
            // Se crea el link que será anexado al template del correo
            var callbackURL = _clientBaseURI + "account-confirmed/" + usuario.Id + "/" + encodedToken;

            // Se crea el mensaje con sus detalles para el envío
            var emailDetails = new SendEmailDetails
            {
                FromName = "MoneyUCAB",
                FromEmail = "moneyucab@gmail.com",
                ToName = _userModel.usuario,
                ToEmail = _userModel.email,
                Subject = "MoneyUCAB - Confirma tu correo electrónico",
                TemplateID = templateID,
                TemplateData = new EmailData
                {
                    Name = _userModel.usuario,
                    URL = callbackURL,
                    Message = "¡Nos emociona muchísimo tenerte en la familia! " +
                                "Para ello, es indispensable que confirmes tu cuenta para gozar de nuestros servicios. " +
                                "Solo haz click en el botón.",
                    ButtonTitle = "Confirmar cuenta"
                }
            };

            // Se envía el mensaje al correo del usuario registrado
            _emailSender.SendEmailAsync(emailDetails);

            return result;
        }

    }
}
