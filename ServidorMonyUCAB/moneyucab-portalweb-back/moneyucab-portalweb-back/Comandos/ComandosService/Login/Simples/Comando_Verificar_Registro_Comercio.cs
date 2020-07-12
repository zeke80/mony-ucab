using Comandos;
using Excepciones.Excepciones_Especificas;
using Microsoft.AspNetCore.Identity;
using moneyucab_portalweb_back.EntitiesForm;
using System;
using System.Threading.Tasks;

namespace moneyucab_portalweb_back.Comandos.ComandosService.Login.Simples
{
    public class Comando_Verificar_Registro_Comercio : Comando<Object>
    {

        private UserManager<Usuario> _userManager;
        private ComercioForm _comercio;

        public Comando_Verificar_Registro_Comercio(UserManager<Usuario> UserManager, ComercioForm Comercio)
        {
            this._userManager = UserManager;
            this._comercio = Comercio;
        }

        async public Task<bool> Ejecutar()
        {

            // Chequeo que el username no este registrado
            try
            {
                await FabricaComandos.Fabricar_Cmd_Existencia_Usuario(_userManager, _comercio.usuario, _comercio.usuario, " ").Ejecutar();
            }
            catch (UsuarioExistenteException ex)
            {
                if (ex.codigo != 17)
                    UsuarioExistenteException.UsuarioNoExistente();
            }
            return true;
        }
    }
}
