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

		async public Task<List<Object>> Ejecutar()
		{
			DAOBase dao = FabricaDAO.CrearDaoBase();
			List<ComOperacionMonedero> Operaciones = dao.HistorialOperacionesMonedero(this._idUsuario);
			List<Object> HistMonederoResponse = new List<Object>();
			for (int i = 0; i < Operaciones.Count; i++)
			{
				var infoAdicional = new { Operaciones[i].tipoOperacion, Operaciones[i].operacionCuenta, Operaciones[i].operacionTarjeta };
				var elementResponse = new { Operaciones[i].fecha, Operaciones[i].idOperacionMonedero, Operaciones[i].idUsuario, Operaciones[i].referencia, infoAdicional };
				HistMonederoResponse.Add(elementResponse);
			}
			return HistMonederoResponse;
		}
		
		
	}
}
