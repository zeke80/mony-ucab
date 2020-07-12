using Comunes.Comun;
using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace moneyucab_portalweb_back.Comandos.ComandosService.Login.ConsultasDAO
{
	public class Comando_Reintegros_Activos
	{
		private int _idUsuario;
		private int _solicitante;
		public Comando_Reintegros_Activos(int IdUsuario, int Solicitante)
		{
			this._idUsuario = IdUsuario;
			this._solicitante = Solicitante;
		}
		async public Task<List<ComReintegro>> Ejecutar()
		{
			DAOBase dao = FabricaDAO.CrearDaoBase();
			return dao.ReintegrosActivos(this._idUsuario, this._solicitante);
		}
		
		
	}
}
