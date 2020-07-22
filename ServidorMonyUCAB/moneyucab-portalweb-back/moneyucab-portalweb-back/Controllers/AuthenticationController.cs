using Excepciones;
using Excepciones.Excepciones_Especificas;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using moneyucab_portalweb_back.Comandos;
using moneyucab_portalweb_back.Comandos.ComandosService.Utilidades.Email;
using moneyucab_portalweb_back.Comandos.ComandosService.Login.Simples;
using moneyucab_portalweb_back.Comandos.ComandosService.Login.ConsultasDAO;
using moneyucab_portalweb_back.Models;
using moneyucab_portalweb_back.EntitiesForm;
using System;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authorization;

namespace moneyucab_portalweb_back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private UserManager<Usuario> _userManager;
        private SignInManager<Usuario> _signInManager;
        private readonly ApplicationSettings _appSettings;
        private IEmailSender _emailSender;

        private readonly string clientBaseURI = "http://localhost:4200/#/";

        public AuthenticationController(
            UserManager<Usuario> userManager,
            SignInManager<Usuario> signInManager,
            IOptions<ApplicationSettings> appSettings,
            IEmailSender emailSender
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _appSettings = appSettings.Value;
            _emailSender = emailSender;
        }


        [HttpPost]
        [Route("Register")]
        //Post: /api/Authentication/Register
        public async Task<Object> Register(RegistrationModel UserModel)
        {
            try
            {
                // Chequeo que el username no este registrado
                await FabricaComandos.Fabricar_Cmd_Verificar_Registro_Usuario(this._userManager, UserModel).Ejecutar();
                //Se realiza el registro del usuario
                var result = await FabricaComandos.Fabricar_Cmd_Registro_Usuario(_userManager, UserModel, _appSettings, _emailSender).Ejecutar();

                return Ok(new { key = "RegisterMessage", message = "Registro exitoso", result });
            }
            catch (MoneyUcabException ex)
            {
                //Debe controlarse un error dentro de la plataforma
                //Se realiza bad request respondiendo con el objeto obtenido
                return BadRequest(ex.Response());
            }
            catch (Exception ex)
            {
                return BadRequest(MoneyUcabException.ResponseErrorDesconocido(ex));
            }
        }

        [HttpPost]
        [Route("RegisterFamiliar")]
        //Post: /api/Authentication/Register
        public async Task<Object> RegisterFamiliar(RegistrationModel UserModel)
        {
            try
            {
                // Chequeo que el username no este registrado
                await FabricaComandos.Fabricar_Cmd_Verificar_Registro_Usuario(this._userManager, UserModel).Ejecutar();
                //Se realiza el registro del usuario
                var result = await FabricaComandos.Fabricar_Cmd_Registro_Usuario_Familiar(_userManager, UserModel, _appSettings, _emailSender).Ejecutar();

                return Ok(new { key = "RegisterMessage", message = "Registro exitoso", result });
            }
            catch (MoneyUcabException ex)
            {
                //Debe controlarse un error dentro de la plataforma
                //Se realiza bad request respondiendo con el objeto obtenido
                return BadRequest(ex.Response());
            }
            catch (Exception ex)
            {
                return BadRequest(MoneyUcabException.ResponseErrorDesconocido(ex));
            }
        }

        [HttpPost]
        [Route("RegisterComercio")]
        //Post: /api/Authentication/Register
        public async Task<Object> RegisterComercio(ComercioForm comercio)
        {
            try
            {
                //Ejecución de comandos para funcionalidad de registro

                // Chequeo que el usuario exista para registrarle la info de comercio
                await FabricaComandos.Fabricar_Cmd_Verificar_Registro_Comercio(_userManager, comercio).Ejecutar();
                //Se realiza el registro del usuario
                await FabricaComandos.Fabricar_Cmd_Registro_Comercio(comercio).Ejecutar();

                return Ok(new { key = "RegisterMessage", message = "Registro del comercio exitoso"});
            }
            catch (MoneyUcabException ex)
            {
                //Debe controlarse un error dentro de la plataforma
                //Se realiza bad request respondiendo con el objeto obtenido
                return BadRequest(ex.Response());
            }
            catch (Exception ex)
            {
                return BadRequest(MoneyUcabException.ResponseErrorDesconocido(ex));
            }
        }


        [HttpPost]
        [Route("Login")]
        //Post: /api/Authentication/Login
        public async Task<IActionResult> Login(LoginModel Model)
        {
            try
            {
                // Busco el usuario en la base de datos - Get user in database
                await FabricaComandos.Fabricar_Cmd_Verificar_Autenticacion(_userManager, Model).Ejecutar();
                // await FabricaComandos.Fabricar_Cmd_Verificar_Email_Confirmado(model.Email, _userManager).Ejecutar();
                // Obtengo el resultado de iniciar sesión 
                var result = await FabricaComandos.Fabricar_Cmd_Inicio_Sesion(_userManager, Model, _appSettings, _signInManager).Ejecutar();
                return Ok(new { key = "LoginMessage", message = "Ingreso exitoso", result });
            }
            catch (MoneyUcabException ex)
            {
                //Se retorna el badRequest con los datos de la excepción
                return BadRequest(ex.Response());
            }
            catch (Exception ex)
            {
                return BadRequest(MoneyUcabException.ResponseErrorDesconocido(ex));
            }
        }


        [HttpPost]
        [Route("ConfirmedEmail")]
        //[AllowAnonymous]
        //Post: /api/Authentication/ConfirmedEmail
        public async Task<IActionResult> ConfirmEmail(ConfirmEmailModel Model)
        {
            try
            {
                // Reviso que los parametros no sean nulos o con errores
                await FabricaComandos.Fabricar_Cmd_Verificar_Parametros(Model.confirmationToken, Model.idUsuario).Ejecutar();

                //Busco al usuario por su ID

                await FabricaComandos.Fabricar_Cmd_Existencia_Usuario(_userManager, null, null, Model.idUsuario).Ejecutar();
                var result = await FabricaComandos.Fabricar_Cmd_Confirmar_Email(Model.idUsuario, _userManager, Model).Ejecutar();
                //Se responde positivamente por el proceso.
                return Ok(new { key = "ModificationSuccess", message = "¡Modificación exitosa!", result });
            }
            catch (MoneyUcabException ex)
            {
                //Error al intentar confirmar el email.
                return BadRequest(ex.Response());
            }
            catch (Exception ex)
            {
                return BadRequest(MoneyUcabException.ResponseErrorDesconocido(ex));
            }

        }


        [HttpPost]
        [Route("ForgotPasswordEmail")]
        //Post: /api/Authentication/ForgotPasswordEmail
        public async Task<IActionResult> SendForgotPasswordEmail(ForgotPasswordModel Model)
        {
            try
            {
                //Proceso de envío y recuperación de contraseña.    
                var result = await FabricaComandos.Fabricar_Cmd_Olvido_Contraseña(_userManager, Model, _appSettings, _emailSender).Ejecutar();
                return Ok(new { key = "ForgotPasswordEmailSent", message = "Un mensaje ha sido enviado a su email con instrucciones para restablecer su contraseña", result});
            }
            catch (MoneyUcabException ex)
            {
                return BadRequest(ex.Response());
            }
            catch (Exception ex)
            {
                return BadRequest(MoneyUcabException.ResponseErrorDesconocido(ex));
            }

        }


        [HttpPost]
        [Route("ResetPassword")]
        //Post: /api/Authentication/ResetPassword
        public async Task<IActionResult> ResetPassword(ResetPasswordModel Model)
        {
            try
            {
                // Reviso que los parametros no sean nulos o con errores
                await FabricaComandos.Fabricar_Cmd_Verificar_Parametros(Model.newPassword, Model.resetPasswordToken).Ejecutar();

                // Busco al usuario por su ID
                var result = await FabricaComandos.Fabricar_Cmd_Resetear_Password(_userManager, Model).Ejecutar();

                return Ok(new { key = "ResetPasswordSuccess", message = "¡Contraseña restablecida!", result});
            }
            catch (MoneyUcabException ex)
            {
                return BadRequest(ex.Response());
            }
            catch (Exception ex)
            {
                return BadRequest(MoneyUcabException.ResponseErrorDesconocido(ex));
            }

        }

        [HttpPost]
        [Authorize]
        [Route("ChangePassword")]
        //Post: /api/Authentication/ResetPassword
        public async Task<IActionResult> ChangePassword(ResetPasswordModel Model)
        {
            try
            {
                // Busco al usuario por su ID
                var result = await FabricaComandos.Fabricar_Cmd_Cambio_Contraseña(_userManager, Model.idUsuario, Model.resetPasswordToken, Model.newPassword).Ejecutar();

                return Ok(new { key = "ChangePasswordSuccess", message = "¡Contraseña cambiada!", result });
            }
            catch (MoneyUcabException ex)
            {
                return BadRequest(ex.Response());
            }
            catch (Exception ex)
            {
                return BadRequest(MoneyUcabException.ResponseErrorDesconocido(ex));
            }

        }

        [HttpPost]
        [Authorize]
        [Route("Modification")]
        public async Task<IActionResult> Modification([FromBody]ModificacionUsuario Formulario)
        {
            try
            {
                var result = await FabricaComandos.Fabricar_Cmd_Modificar_Usuario(Formulario.nombre, Formulario.apellido, Formulario.telefono, Formulario.direccion, Formulario.razonSocial, Formulario.idEstadoCivil, Formulario.idUsuario).Ejecutar();
                return Ok(new { key = "ModificationSuccess", message = "¡Modificación exitosa!" , result});
            }
            catch (MoneyUcabException ex)
            {
                return BadRequest(ex.Response());
            }
            catch (Exception ex)
            {
                return BadRequest(MoneyUcabException.ResponseErrorDesconocido(ex));
            }

        }

        [HttpDelete]
        [Authorize]
        [Route("EliminarUsuario")]
        //GET: /api/Dashboard/InformacionPersona
        public async Task<Object> EliminarUsuario([FromQuery] int IdUsuario)
        {

            try
            {
                return FabricaComandos.Fabricar_Cmd_Eliminar_Usuario(IdUsuario).Ejecutar();
            }
            catch (MoneyUcabException ex)
            {
                //Se retorna el badRequest con los datos de la excepción
                return BadRequest(ex.Response());
            }
            catch (Exception ex)
            {
                return BadRequest(MoneyUcabException.ResponseErrorDesconocido(ex));
            }
        }


    }
}