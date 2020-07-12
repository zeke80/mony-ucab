using Comunes.Comun;
using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace moneyucab_portalweb_back.Comandos.ComandosService.Login.ConsultasDAO
{
	public class Comando_Estados_Civiles
	{

		public Comando_Estados_Civiles()
		{

		}
		async public Task<List<ComEstadoCivil>> Ejecutar()
		{
			DAOBase dao = FabricaDAO.CrearDaoBase();
			return dao.EstadosCiviles();
		}
		
		
	}
}
