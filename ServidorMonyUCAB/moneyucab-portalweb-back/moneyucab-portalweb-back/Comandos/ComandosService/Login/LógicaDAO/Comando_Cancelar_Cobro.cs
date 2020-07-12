using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace moneyucab_portalweb_back.Comandos.ComandosService.Login.Simples
{
	public class Comando_Cancelar_Cobro
	{
		private int _idCobro { get; set; }


		public Comando_Cancelar_Cobro(int IdCobro)
		{
			this._idCobro = IdCobro;
		}

		async public Task<Boolean> Ejecutar()
		{
			DAOBase dao = new DAOBase();
			dao.CancelarCobro(_idCobro);
			return true;
		}
	}
}
