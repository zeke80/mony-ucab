using Comunes.Comun;
using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace moneyucab_portalweb_back.Comandos.ComandosService.Login.ConsultasDAO
{
	public class Comando_Consultar_Opciones_Menu
	{
		private int _idUsuario;

		public Comando_Consultar_Opciones_Menu(int IdUsuario)
		{
			this._idUsuario = IdUsuario;
		}
		async public Task<List<ComOpcionMenu>> Ejecutar()
		{
			DAOBase dao = FabricaDAO.CrearDaoBase();
			return dao.OpcionesMenu(this._idUsuario);
		}
		
		
	}
}
