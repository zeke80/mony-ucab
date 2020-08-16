using Comunes.Comun;
using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace moneyucab_portalweb_back.Comandos.ComandosService.Login.ConsultasDAO
{
    public class Comando_Cobros_Pendientes
    {
		public Comando_Cobros_Pendientes()
		{

		}
		async public Task<List<ComPago>> Ejecutar()
		{
			DAOBase dao = FabricaDAO.CrearDaoBase();
			return dao.CobrosPendientes();
		}
	}
}
