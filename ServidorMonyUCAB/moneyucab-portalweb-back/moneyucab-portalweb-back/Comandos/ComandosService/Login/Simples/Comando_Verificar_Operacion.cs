using Comunes.Comun;
using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace moneyucab_portalweb_back.Comandos.ComandosService.Login.Simples
{
	public class Comando_Verificar_Operacion
	{
		public List<ComOperacionMonedero> operaciones = new List<ComOperacionMonedero>();
		public int _idUsuarioReceptor;

		public Comando_Verificar_Operacion(int IdUsuario)
		{
			_idUsuarioReceptor = IdUsuario;
			operaciones = new List<ComOperacionMonedero>();
		}
		async public Task<Boolean> Ejecutar()
		{
			DAOBase dao = new DAOBase();

			operaciones = dao.HistorialOperacionesMonedero(_idUsuarioReceptor);

			return true;
		}
	}
}
