using Comunes.Comun;
using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace moneyucab_portalweb_back.Comandos.ComandosService.Login.ConsultasDAO
{
	public class Comando_Historial_Operaciones_Cuenta
	{
		private int _idCuenta;

		public Comando_Historial_Operaciones_Cuenta()
		{

		}

		public Comando_Historial_Operaciones_Cuenta(int IdCuenta)
		{
			this._idCuenta = IdCuenta;
		}

		async public Task<List<ComOperacionCuenta>> Ejecutar()
		{
			DAOBase dao = FabricaDAO.CrearDaoBase();
			return dao.HistorialOperacionesCuenta(this._idCuenta);
		}
		
		
	}
}
