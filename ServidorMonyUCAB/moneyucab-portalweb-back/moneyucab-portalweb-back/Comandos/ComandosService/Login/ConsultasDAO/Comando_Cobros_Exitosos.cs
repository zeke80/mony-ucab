using Comunes.Comun;
using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace moneyucab_portalweb_back.Comandos.ComandosService.Login.ConsultasDAO
{
	public class Comando_Cobros_Exitosos
	{
		private int _idUsuario;
		private int _solicitante;
		public Comando_Cobros_Exitosos(int IdUsuario, int Solicitante)
		{
			this._idUsuario = IdUsuario;
			this._solicitante = Solicitante;
		}
		async public Task<List<ComPago>> Ejecutar()
		{
			DAOBase dao = FabricaDAO.CrearDaoBase();
			return dao.CobrosExitosos(this._idUsuario, this._solicitante);
		}
		
		
	}
}
