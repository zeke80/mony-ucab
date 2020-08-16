using Comunes.Comun;
using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace moneyucab_portalweb_back.Comandos.ComandosService.Login.ConsultasDAO
{
    public class Comando_RetiroRango
    {
		public Comando_RetiroRango()
		{

		}
		async public Task<List<ComOperacionMonedero>> Ejecutar()
		{
			DAOBase dao = FabricaDAO.CrearDaoBase();
			return dao.RetiroRango();
		}
	}
}
