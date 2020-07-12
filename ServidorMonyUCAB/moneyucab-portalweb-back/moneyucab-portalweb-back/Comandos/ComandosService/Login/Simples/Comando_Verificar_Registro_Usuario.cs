using Comandos;
using Excepciones.Excepciones_Especificas;
using Microsoft.AspNetCore.Identity;
using moneyucab_portalweb_back.EntitiesForm;
using System;
using System.Threading.Tasks;

namespace moneyucab_portalweb_back.Comandos.ComandosService.Login.Simples
{
    public class Comando_Verificar_Registro_Usuario : Comando<Object>
    {

        private UserManager<Usuario> _userManager;
        private RegistrationModel _userModel;

        public Comando_Verificar_Registro_Usuario(UserManager<Usuario> UserManager, RegistrationModel UserModel)
        {
            this._userManager = UserManager;
            this._userModel = UserModel;
        }

        async public Task<Object> Ejecutar()
        {

            // Chequeo que el username no este registrado
            try
            {
                await FabricaComandos.Fabricar_Cmd_Existencia_Usuario(_userManager, _userModel.usuario, _userModel.email, null).Ejecutar();
            }
            catch (UsuarioExistenteException ex)
            {
                if (ex.codigo == 11)
                {
                    //Se captura si no existe previamente el usuario.
                    //Se debe ingresar en este punto la validación DAO con el sistema propio y no con Identity

                    //-------------------------------------------------------
                }
                else
                    UsuarioExistenteException.UsuarioExistente();
            }
            return null;
        }
    }
}
