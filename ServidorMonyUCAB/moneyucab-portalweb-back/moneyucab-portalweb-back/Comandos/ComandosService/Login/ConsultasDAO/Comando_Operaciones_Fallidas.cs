using Comunes.Comun;
using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace moneyucab_portalweb_back.Comandos.ComandosService.Login.ConsultasDAO
{
    public class Comando_Operaciones_Fallidas
    {
		public Comando_Operaciones_Fallidas()
		{

		}
		async public Task<List<ComBitacora>> Ejecutar()
		{
			DAOBase dao = FabricaDAO.CrearDaoBase();
			return dao.OperacionesFallidas();
		}
	}
}
