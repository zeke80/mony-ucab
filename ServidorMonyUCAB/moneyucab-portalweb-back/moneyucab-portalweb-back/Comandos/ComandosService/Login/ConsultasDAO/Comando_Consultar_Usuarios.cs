using Comunes.Comun;
using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace moneyucab_portalweb_back.Comandos.ComandosService.Login.ConsultasDAO
{
	public class Comando_Consultar_Usuarios
	{
		private string _query;

		public Comando_Consultar_Usuarios()
		{

		}

		public Comando_Consultar_Usuarios(string Query)
		{
			this._query = Query;
		}

		async public Task<List<ComUsuario>> Ejecutar()
		{
			DAOBase dao = FabricaDAO.CrearDaoBase();
			return dao.ConsultarUsuarios(this._query);
		}
		
		
	}
}
