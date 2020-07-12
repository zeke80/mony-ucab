using Comunes.Comun;
using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace moneyucab_portalweb_back.Comandos.ComandosService.Login.ConsultasDAO
{
	public class Comando_Historial_Operaciones_Tarjeta
	{
		private int _idTarjeta;

		public Comando_Historial_Operaciones_Tarjeta()
		{

		}

		public Comando_Historial_Operaciones_Tarjeta(int IdTarjeta)
		{
			this._idTarjeta = IdTarjeta;
		}

		async public Task<List<ComOperacionTarjeta>> Ejecutar()
		{
			DAOBase dao = FabricaDAO.CrearDaoBase();
			return dao.HistorialOperacionesTarjeta(this._idTarjeta);
		}
		
		
	}
}
