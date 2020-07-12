using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace moneyucab_portalweb_back.Comandos.ComandosService.Login.Simples
{
	public class Comando_Eliminar_Billetera_Cuenta

	{
		private int _idUsuario { get; set; }

		public Comando_Eliminar_Billetera_Cuenta(int IdUsuario)
		{
			this._idUsuario = IdUsuario;
		}

		async public Task<Boolean> Ejecutar()
		{
			DAOBase dao = new DAOBase();
			dao.EjecutarCierre(_idUsuario);

			return true;
		}
	}
}
