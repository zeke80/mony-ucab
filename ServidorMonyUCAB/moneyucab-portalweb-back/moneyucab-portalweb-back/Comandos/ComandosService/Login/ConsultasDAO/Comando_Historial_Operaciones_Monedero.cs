using Comunes.Comun;
using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace moneyucab_portalweb_back.Comandos.ComandosService.Login.ConsultasDAO
{
	public class Comando_Historial_Operaciones_Monedero
	{
		private int _idUsuario;

		public Comando_Historial_Operaciones_Monedero()
		{

		}

		public Comando_Historial_Operaciones_Monedero(int idUsuario)
		{
			this._idUsuario = idUsuario;
		}

		async public Task<List<ComOperacionMonedero>> Ejecutar()
		{
			DAOBase dao = FabricaDAO.CrearDaoBase();
			return dao.HistorialOperacionesMonedero(this._idUsuario);
		}
		
		
	}
}
