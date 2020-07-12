using Comandos;
using Excepciones.Excepciones_Especificas;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using moneyucab_portalweb_back.EntitiesForm;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace moneyucab_portalweb_back.Comandos.ComandosService.Login.Simples
{
    public class Comando_Verificar_Autenticacion : Comando<Object>
    {
        //private FormP formulario;
        private UserManager<Usuario> _userManager;
        private LoginModel _model;

        public Comando_Verificar_Autenticacion(UserManager<Usuario> UserManager, LoginModel Model)
        {
            this._userManager = UserManager;
            this._model = Model;
        }

        async public Task<Boolean> Ejecutar()
        {
            try
            {
                await FabricaComandos.Fabricar_Cmd_Existencia_Usuario(_userManager, _model.email, _model.email, null).Ejecutar();
            }
            catch (UsuarioExistenteException ex)
            {
                if (ex.codigo != 17)
                    UsuarioExistenteException.UsuarioNoExistente();
            }
            if (_model.comercio)
            {
                if (!await FabricaComandos.Fabricar_Cmd_Comercio_Usuario(_model.email).Ejecutar())
                {
                    AutenticacionAppException.UsuarioInvalidoApp();
                }
            }
            if (!await FabricaComandos.Fabricar_Cmd_Persona_Usuario(_model.email).Ejecutar())
            {
                AutenticacionAppException.UsuarioInvalidoApp();
            }
            return true;
        }


    }
}
