using Comunes.Comun;
using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using moneyucab_portalweb_back.EntitiesForm;

namespace moneyucab_portalweb_back.Comandos.ComandosService.Login.LogicaDAO
{
	public class Comando_Registro_Usuario_DAO
	{
		private RegistrationModel _formulario;

		public Comando_Registro_Usuario_DAO(RegistrationModel Formulario)
		{
			this._formulario = Formulario;
		}
		async public Task<Boolean> Ejecutar()
		{
			DAOBase dao = FabricaDAO.CrearDaoBase();
			if (this._formulario.comercio)
            {
				dao.RegistroUsuarioComercio(this._formulario.Formatear_Formulario());
				return true;
            }
            else
            {
				dao.RegistroUsuarioPersona(this._formulario.Formatear_Formulario());
				return true;
			}
		}
		
		
	}
}
