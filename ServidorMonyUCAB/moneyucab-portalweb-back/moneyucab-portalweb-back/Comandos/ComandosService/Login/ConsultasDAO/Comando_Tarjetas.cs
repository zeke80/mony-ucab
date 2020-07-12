using Comunes.Comun;
using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace moneyucab_portalweb_back.Comandos.ComandosService.Login.ConsultasDAO
{
	public class Comando_Tarjetas
	{
		private int _idUsuario;

		public Comando_Tarjetas()
		{

		}

		public Comando_Tarjetas(int UsuarioId)
		{
			this._idUsuario = UsuarioId;
		}

		async public Task<List<Object>> Ejecutar()
		{
			DAOBase dao = FabricaDAO.CrearDaoBase();
			List<ComTarjeta> tarjetas = dao.Tarjetas(this._idUsuario);
			List<Object> tarjetasResponse = new List<Object>();
			for (int i = 0; i < tarjetas.Count; i++)
			{
				var infoAdicional = new { tarjetas[i].tipoTarjeta, tarjetas[i].banco};
				var elementResponse = new { tarjetas[i].numero, tarjetas[i].cvc, tarjetas[i].estatus, tarjetas[i].fechaVencimiento, tarjetas[i].idTarjeta, tarjetas[i].idUsuario, infoAdicional };
				tarjetasResponse.Add(elementResponse);
			}
			return tarjetasResponse;
		}
		
		
	}
}
