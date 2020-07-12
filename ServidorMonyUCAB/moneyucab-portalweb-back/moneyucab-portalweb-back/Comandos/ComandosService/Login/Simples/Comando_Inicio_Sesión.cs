using Comandos;
using Excepciones.Excepciones_Especificas;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using moneyucab_portalweb_back.EntitiesForm;
using moneyucab_portalweb_back.Models;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace moneyucab_portalweb_back.Comandos.ComandosService.Login.Simples
{
    //Este comando retorna el token de inicio de sesión
    public class Comando_Inicio_Sesion : Comando<Object>
    {

        private UserManager<Usuario> _userManager;
        private LoginModel _userModel;
        private SignInManager<Usuario> _signInManager;
        private ApplicationSettings _appSettings;

        public Comando_Inicio_Sesion(UserManager<Usuario> UserManager, LoginModel UserModel, ApplicationSettings AppSettings, SignInManager<Usuario> SignInManager)
        {
            this._userManager = UserManager;
            this._userModel = UserModel;
            this._appSettings = AppSettings;
            this._signInManager = SignInManager;
        }


        async public Task<Object> Ejecutar()
        {

            var user = await _userManager.FindByEmailAsync(_userModel.email);
            var result = await _signInManager.PasswordSignInAsync(user, _userModel.password, false, true);
            if (result.Succeeded)
            {

                // Generar un nuevo token - Generate a new token
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim("UserID", user.Id.ToString()),
                        new Claim("LoggedOn", DateTime.Now.ToString())
                        //Aqui se agrega el rol o roles que tiene el usuario que inicia sesion
                    }),
                    Expires = DateTime.UtcNow.AddMinutes(Convert.ToInt32(_appSettings.Token_ExpiredTime)), // El token expira luego de este tiempo
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appSettings.JWT_Secret)), SecurityAlgorithms.HmacSha256Signature)
                };
                var tokenHandler = new JwtSecurityTokenHandler();
                var securityToken = tokenHandler.CreateToken(tokenDescriptor);
                var token = tokenHandler.WriteToken(securityToken);

                return (new { token, userID = user.Id, username = user.UserName, email = user.Email });

            }
            //Realiza un throw con el error especificado.
            if (result.IsLockedOut)
            {
                var lockoutDateTime = await _userManager.GetLockoutEndDateAsync(user); // Obtengo datetime de cuando se levanta la restriccion del lockout
                UsuarioBloqueadoException.UsuarioBloqueado((DateTimeOffset)lockoutDateTime);
            }
            else
            {
                var remainingAttempts = 3 - await _userManager.GetAccessFailedCountAsync(user); // Obtengo la cantidad de intentos restantes le quedan al usuario
                UsuarioBloqueadoException.IntentoFallido(remainingAttempts);
            }
            return null;
        }

    }
}
