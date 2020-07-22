using Comunes.Comun;
using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace moneyucab_portalweb_back.Comandos.ComandosService.Login.ConsultasDAO
{
	public class Comando_Consultar_Usuarios_Familiares
	{
		private int _idUsuario;

		public Comando_Consultar_Usuarios_Familiares()
		{

		}

		public Comando_Consultar_Usuarios_Familiares(int IdUsuario)
		{
			this._idUsuario = IdUsuario;
		}

		async public Task<List<ComUsuario>> Ejecutar()
		{
			DAOBase dao = FabricaDAO.CrearDaoBase();
			return dao.ConsultarUsuariosFamiliares(this._idUsuario);
		}
		
		
	}
}
