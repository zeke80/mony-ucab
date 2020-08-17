using Comunes.Comun;
using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace moneyucab_portalweb_back.Comandos.ComandosService.Login.ConsultasDAO
{
    public class Comando_Retiro_Anual
    {
		private string _ano;

		public Comando_Retiro_Anual(string ano)
		{
			this._ano = ano;

		}

		async public Task<List<ComOperacionMonedero>> Ejecutar()
		{
			DAOBase dao = FabricaDAO.CrearDaoBase();
			return dao.retiro_anual(this._ano);
		}
	}
}
