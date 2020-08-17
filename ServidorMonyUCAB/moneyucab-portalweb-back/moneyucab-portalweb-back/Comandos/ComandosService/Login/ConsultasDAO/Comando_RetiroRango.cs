using Comunes.Comun;
using DAO;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace moneyucab_portalweb_back.Comandos.ComandosService.Login.ConsultasDAO
{
    public class Comando_RetiroRango
    {
		private string _date;
		private string _date2;

		public Comando_RetiroRango(string fecha, string fecha2)
		{
			this._date = fecha;
			this._date2 = fecha2;
		}

			async public Task<List<ComRangoFechas>> Ejecutar()
		{
			DAOBase dao = FabricaDAO.CrearDaoBase();
			return dao.RetiroRango(this._date,this._date2);
		}
	}
}
