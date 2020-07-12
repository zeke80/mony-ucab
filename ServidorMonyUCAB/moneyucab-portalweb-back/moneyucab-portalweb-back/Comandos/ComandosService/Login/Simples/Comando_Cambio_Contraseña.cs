using Comandos;
using Microsoft.AspNetCore.Identity;
using moneyucab_portalweb_back.Comandos.ComandosService.Utilidades.Email;
using Excepciones.Excepciones_Especificas;
using moneyucab_portalweb_back.EntitiesForm;
using moneyucab_portalweb_back.IdentityExtentions;
using moneyucab_portalweb_back.Models;
using System;
using System.Threading.Tasks;

namespace moneyucab_portalweb_back.Comandos.ComandosService.Login.Simples
{
    public class Comando_Cambio_Contraseña : Comando<Boolean>
    {

        private UserManager<Usuario> _userManager;
        private string _usuario;
        private string _passwordActual;
        private string _passwordNueva;

        public Comando_Cambio_Contraseña(UserManager<Usuario> UserManager, string Usuario, string PasswordActual, string PasswordNueva)
        {
            this._userManager = UserManager;
            this._usuario = Usuario;
            this._passwordActual = PasswordActual;
            this._passwordNueva = PasswordNueva;
        }

        async public Task<Boolean> Ejecutar()
        {
            try
            {
                await FabricaComandos.Fabricar_Cmd_Existencia_Usuario(this._userManager, this._usuario, this._usuario, this._usuario).Ejecutar();
            }
            catch (UsuarioExistenteException ex)
            {
                if(ex.codigo == 11)
                {
                    throw ex;
                }
            }
            Usuario user = await this._userManager.FindByNameAsync(this._usuario);
            if (user == null)
            {
                user = await this._userManager.FindByEmailAsync(this._usuario);
                if (user == null)
                {
                    user = await this._userManager.FindByIdAsync(this._usuario);
                }
            }
            var result = await this._userManager.ChangePasswordAsync(user, this._passwordActual, this._passwordNueva);
            if (!result.Succeeded)
            {
                CambioContraseñaException.CambioContraseñaError();
            }
            return true;
        }

    }
}
