using Comandos;
using Excepciones.Excepciones_Especificas;
using Microsoft.AspNetCore.Identity;
using moneyucab_portalweb_back.EntitiesForm;
using System;
using System.Threading.Tasks;

namespace moneyucab_portalweb_back.Comandos.ComandosService.Login.Simples
{
    public class Comando_Existencia_Usuario : Comando<Boolean>
    {

        private UserManager<Usuario> _userManager;
        private string _userName;
        private string _email;
        private string _userId;

        public Comando_Existencia_Usuario(UserManager<Usuario> UserManager, string UserName, string Email, string UserId)
        {
            this._userManager = UserManager;
            this._userName = UserName;
            this._email = Email;
            this._userId = UserId;
        }

        async public Task<Boolean> Ejecutar()
        {
            //Este comando debe retornar una excepción sino consigue el usuario o email
            // Chequeo que el username no este registrado
            if (await _userManager.FindByNameAsync(_userName) != null)
            {
                UsuarioExistenteException.UsuarioExistente();
            }
            // Chequeo que el email no este registrado
            if (await _userManager.FindByEmailAsync(_email) != null)
            {
                UsuarioExistenteException.UsuarioExistente();
            }
            if (await _userManager.FindByIdAsync(_userId) != null)
            {
                UsuarioExistenteException.UsuarioExistente();
            }
            UsuarioExistenteException.UsuarioNoExistente();
            return true;
        }

    }
}
