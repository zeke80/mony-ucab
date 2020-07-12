using Comunes.Comun;
using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace moneyucab_portalweb_back.Comandos.ComandosService.Login.ConsultasDAO
{
	public class Comando_Parametros_Usuario
	{
		private int _idUsuario;

		public Comando_Parametros_Usuario()
		{

		}

		public Comando_Parametros_Usuario(int UsuarioId)
		{
			this._idUsuario = UsuarioId;
		}

		async public Task<List<Object>> Ejecutar()
		{
			DAOBase dao = FabricaDAO.CrearDaoBase();
			List<ComUsuarioParametro> parametros = dao.ParametrosUsuario(this._idUsuario);
			List<Object> parametrosResponse = new List<Object>();
			for (int i = 0; i < parametros.Count; i++)
			{
				var infoAdicional = new { parametros[i].parametro, parametros[i].parametro.frecuencia, parametros[i].parametro.tipoParametro};
				var elementResponse = new { parametros[i].idUsuario, parametros[i].estatus, parametros[i].validacion, infoAdicional };
				parametrosResponse.Add(elementResponse);

			}
			return parametrosResponse;
		}
		
		
	}
}
