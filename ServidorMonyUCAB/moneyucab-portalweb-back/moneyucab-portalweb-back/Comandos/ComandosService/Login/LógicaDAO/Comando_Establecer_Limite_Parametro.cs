using Comunes.Comun;
using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace moneyucab_portalweb_back.Comandos.ComandosService.Login.Simples
{
	public class Comando_Establecer_Limite_Parametro
	{
		private int _idParametro { get; set; }
		private string _limite { get; set; }


		public Comando_Establecer_Limite_Parametro(int IdParametro, string Limite)
		{
			this._idParametro = IdParametro;
			this._limite = Limite;
		}

		async public Task<Boolean> Ejecutar()
		{
			DAOBase dao = new DAOBase();
			dao.EstablecerLimiteParametro(this._idParametro, this._limite);
			return true;
		}
	}
}
