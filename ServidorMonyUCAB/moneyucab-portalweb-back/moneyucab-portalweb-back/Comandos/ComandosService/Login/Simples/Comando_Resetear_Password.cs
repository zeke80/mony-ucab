using Comandos;
using Excepciones.Excepciones_Especificas;
using Microsoft.AspNetCore.Identity;
using moneyucab_portalweb_back.EntitiesForm;
using System;
using System.Threading.Tasks;

namespace moneyucab_portalweb_back.Comandos.ComandosService.Login.Simples
{
    public class Comando_Resetear_Password : Comando<Boolean>
    {
        private ResetPasswordModel _model;
        private UserManager<Usuario> _userManager;

        public Comando_Resetear_Password(UserManager<Usuario> UserManager, ResetPasswordModel Model)
        {
            this._userManager = UserManager;
            this._model = Model;
        }

        async public Task<Boolean> Ejecutar()
        {
            try
            {
                await FabricaComandos.Fabricar_Cmd_Existencia_Usuario(_userManager, _model.idUsuario, _model.idUsuario, _model.idUsuario).Ejecutar();
            }
            catch (UsuarioExistenteException ex)
            {
                if (ex.codigo != 17)
                {
                    throw ex;
                }
            }
            // Decodificando el token
            var decodedToken = _model.resetPasswordToken.Replace("_", "/").Replace("-", "+").Replace(".", "=");

            var usuario = await _userManager.FindByIdAsync(_model.idUsuario);
            if (usuario == null)
            {
                usuario = await _userManager.FindByEmailAsync(_model.idUsuario);
                if(usuario == null)
                {
                    usuario = await _userManager.FindByNameAsync(_model.idUsuario);
                }
            }
            // Cambia la contraseña del usuario
            var result = await _userManager.ResetPasswordAsync(usuario, decodedToken, _model.newPassword);

            if (result.Succeeded)
            {
                return true;
            }
            else
            {
                ReseteoPasswordException.ReseteoPasswordFallido();
                return false;
            }
        }
    }
}
