using Comunes.Comun;
using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace moneyucab_portalweb_back.Comandos.ComandosService.Login.Simples
{
	public class Comando_Establecer_Comision 
	{

		private int _idComercio { get; set; }
		private double _comision { get; set; }


		public Comando_Establecer_Comision(int IdComercio, double Comision)
		{
			this._idComercio = IdComercio;
			this._comision = Comision;
		}

		async public Task<Boolean> Ejecutar()
		{
			DAOBase dao = new DAOBase();
			dao.EstablecerComision(this._idComercio, this._comision);
			return true;
		}
	}
}
