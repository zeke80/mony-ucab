using Comunes.Comun;
using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace moneyucab_portalweb_back.Comandos.ComandosService.Login.ConsultasDAO
{
    public class Comando_Retiro_Mes
    {
		private string _mes;

		public Comando_Retiro_Mes(string mes)
		{
			this._mes = mes;

		}

		async public Task<List<ComRangoFechas>> Ejecutar()
		{
			DAOBase dao = FabricaDAO.CrearDaoBase();
			return dao.retiro_mes(this._mes);
		}
	}
}
