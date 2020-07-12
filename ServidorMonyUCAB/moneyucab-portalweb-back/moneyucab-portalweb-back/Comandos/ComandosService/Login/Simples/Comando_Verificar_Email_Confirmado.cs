using Comandos;
using Excepciones.Excepciones_Especificas;
using Microsoft.AspNetCore.Identity;
using moneyucab_portalweb_back.EntitiesForm;
using System;
using System.Threading.Tasks;

namespace moneyucab_portalweb_back.Comandos.ComandosService.Login.Simples
{
    public class Comando_Verificar_Email_Confirmado : Comando<Boolean>
    {
        private string _email;
        private UserManager<Usuario> _userManager;

        public Comando_Verificar_Email_Confirmado(string Email, UserManager<Usuario> UserManager)
        {
            this._email = Email;
            this._userManager = UserManager;

        }

        async public Task<Boolean> Ejecutar()
        {
            // Check if email has been confirmed
            var user = await _userManager.FindByEmailAsync(_email);
            if (await _userManager.IsEmailConfirmedAsync((Usuario)user))
            {
                return true;
            }
            EmailConfirmadoException.EmailNoConfirmado();
            return false;
        }


    }
}
