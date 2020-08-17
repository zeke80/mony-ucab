using Comunes.Comun;
using DAO;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace moneyucab_portalweb_back.Comandos.ComandosService.Login.ConsultasDAO
{
    public class Comando_Retiro_Dia
    {
		private string _DD;

		public Comando_Retiro_Dia(string fecha)
		{
			this._DD = fecha;
			
		}

		async public Task<List<ComRangoFechas>> Ejecutar()
		{
			DAOBase dao = FabricaDAO.CrearDaoBase();
			return dao.retiro_dia(this._DD);
		}
	}
}
