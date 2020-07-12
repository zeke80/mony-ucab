using Comunes.Comun;
using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace moneyucab_portalweb_back.Comandos.ComandosService.Login.ConsultasDAO
{
	public class Comando_Tipos_Cuentas
	{

		public Comando_Tipos_Cuentas()
		{

		}
		async public Task<List<ComTipoCuenta>> Ejecutar()
		{
			DAOBase dao = FabricaDAO.CrearDaoBase();
			return dao.TiposCuentas();
		}
		
		
	}
}
