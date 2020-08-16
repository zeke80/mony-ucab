using Comunes.Comun;
using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace moneyucab_portalweb_back.Comandos.ComandosService.Login.ConsultasDAO
{
    public class Comando_Comisiones_PorEmpresa
    {
	
			public Comando_Comisiones_PorEmpresa()
			{

			}
			async public Task<List<ComComercio>> Ejecutar()
			{
				DAOBase dao = FabricaDAO.CrearDaoBase();
				return dao.ComisionesPorEmpresa();
			}

	}
}
