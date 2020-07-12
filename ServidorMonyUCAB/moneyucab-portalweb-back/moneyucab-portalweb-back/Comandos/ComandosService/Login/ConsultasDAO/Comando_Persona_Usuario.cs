using Comunes.Comun;
using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace moneyucab_portalweb_back.Comandos.ComandosService.Login.ConsultasDAO
{
	public class Comando_Persona_Usuario
	{
		private string _usuario;

		public Comando_Persona_Usuario(string Usuario)
		{
			this._usuario = Usuario;
		}
		async public Task<bool> Ejecutar()
		{
			DAOBase dao = FabricaDAO.CrearDaoBase();
			return dao.PersonaUsuario(_usuario);
		}
		
		
	}
}
