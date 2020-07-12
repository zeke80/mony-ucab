using Comunes.Comun;
using DAO;
using moneyucab_portalweb_back.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using moneyucab_portalweb_back.EntitiesForm;

namespace moneyucab_portalweb_back.Comandos.ComandosService.Login.ConsultasDAO
{
	public class Comando_Bancos
	{

        public Comando_Bancos()
		{

		}

        async public Task<List<ComBanco>> Ejecutar()
		{
			DAOBase dao = FabricaDAO.CrearDaoBase();
			return dao.Bancos();
		}
		
		
	}
}
