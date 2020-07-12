using Comunes.Comun;
using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace moneyucab_portalweb_back.Comandos.ComandosService.Login.ConsultasDAO
{
	public class Comando_Tipos_Identificaciones
	{

		public Comando_Tipos_Identificaciones()
		{

		}
		async public Task<List<ComTipoIdentificacion>> Ejecutar()
		{
			DAOBase dao = FabricaDAO.CrearDaoBase();
			return dao.TiposIdentificaciones();
		}
		
		
	}
}
