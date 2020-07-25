using Comunes.Comun;
using DAO;
using Excepciones.Excepciones_Especificas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace moneyucab_portalweb_back.Comandos.ComandosService.Login.ConsultasDAO
{
	public class Comando_Informacion_Persona
	{
		private string _usuario;

		public Comando_Informacion_Persona()
		{

		}

		public Comando_Informacion_Persona(string Usuario)
		{
			this._usuario = Usuario;
		}

		async public Task<ComUsuario> Ejecutar()
		{
			DAOBase dao = FabricaDAO.CrearDaoBase();
			ComUsuario usuario = dao.InformacionPersona(this._usuario);
			if (usuario.estatus != 1)
            {
				AutenticacionException.UsuarioNoValido();
            }
			return usuario;
		}
		
		
	}
}
