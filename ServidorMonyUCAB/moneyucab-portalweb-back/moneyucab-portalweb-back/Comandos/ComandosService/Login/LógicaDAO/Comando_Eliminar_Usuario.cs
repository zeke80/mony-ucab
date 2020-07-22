using Comunes.Comun;
using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace moneyucab_portalweb_back.Comandos.ComandosService.Login.ConsultasDAO
{
	public class Comando_Eliminar_Usuario
	{
		private int _idUsuario;

		public Comando_Eliminar_Usuario()
		{

		}

		public Comando_Eliminar_Usuario(int IdUsuario)
		{
			this._idUsuario = IdUsuario;
		}

		async public Task<bool> Ejecutar()
		{
			DAOBase dao = FabricaDAO.CrearDaoBase();
			return dao.EliminarUsuario(this._idUsuario);
		}
		
		
	}
}
