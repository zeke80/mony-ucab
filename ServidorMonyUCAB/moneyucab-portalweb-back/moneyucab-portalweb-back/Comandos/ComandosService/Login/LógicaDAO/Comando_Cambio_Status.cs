using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace moneyucab_portalweb_back.Comandos.ComandosService.Login.Simples
{
	public class Comando_Cambio_Status
	{
		private bool _reg { get; set; }
		private int _idOperacion { get; set; }
		private int _status { get; set; }

		public Comando_Cambio_Status(bool Reg, int IdOperacion, int Status)
		{
			this._reg = Reg;
			this._idOperacion = IdOperacion;
			this._status = Status;
		}

		async public Task<Boolean> Ejecutar()
		{
			DAOBase dao = FabricaDAO.CrearDaoBase();
			dao.CambioEstatus(_reg, _idOperacion, _status);
			return true;
		}
	}
}
