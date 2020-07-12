using Comunes.Comun;
using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace moneyucab_portalweb_back.Comandos.ComandosService.Login.ConsultasDAO
{
	public class Comando_Frecuencias
	{

		public Comando_Frecuencias()
		{

		}
		async public Task<List<ComFrecuencia>> Ejecutar()
		{
			DAOBase dao = FabricaDAO.CrearDaoBase();
			return dao.Frecuencias();
		}
		
		
	}
}
