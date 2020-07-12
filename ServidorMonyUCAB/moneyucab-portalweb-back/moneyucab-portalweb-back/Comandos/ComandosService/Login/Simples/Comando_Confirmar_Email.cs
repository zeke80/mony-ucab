using Comandos;
using Excepciones.Excepciones_Especificas;
using Microsoft.AspNetCore.Identity;
using moneyucab_portalweb_back.EntitiesForm;
using System;
using System.Threading.Tasks;

namespace moneyucab_portalweb_back.Comandos.ComandosService.Login.Simples
{
    public class Comando_Confirmar_Email : Comando<Boolean>
    {
        private string _userId;
        private UserManager<Usuario> _userManager;
        private ConfirmEmailModel _model;

        public Comando_Confirmar_Email(string UserId, UserManager<Usuario> UserManager, ConfirmEmailModel Model)
        {
            this._userId = UserId;
            this._userManager = UserManager;
            this._model = Model;
        }

        async public Task<Boolean> Ejecutar()
        {
            var usuario = await _userManager.FindByIdAsync(_userId);
            if (usuario.EmailConfirmed) //Si ya es un usuario con email confirmado
            {
                //Código 1 para error de usuario con email confirmado
                EmailConfirmadoException.EmailConfirmado();
            }

            // Decodificando el token
            var decodedToken = _model.confirmationToken.Replace("_", "/").Replace("-", "+").Replace(".", "=");

            // Cambia en la BD el "ConfirmEmail" a TRUE
            var result = await _userManager.ConfirmEmailAsync(usuario, decodedToken);

            if (result.Succeeded)
            {
                return true;
            }
            else
            {
                EmailConfirmadoException.EmailFalloEnvioConfirmacion();
            }
            return false;
        }
    }
}
