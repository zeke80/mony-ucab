using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace moneyucab_portalweb_back.Comandos.ComandosService.Login.Simples
{
	public class Comando_Retiro
	{
		private int _idUsuario { get; set; }
		private int _idCuenta { get; set; }
		private double _monto { get; set; }

		public Comando_Retiro(int IdUsuario, int IdCuenta, double Monto)
		{
			this._idUsuario = IdUsuario;
			this._idCuenta = IdCuenta;
			this._monto = Monto;
		}

		async public Task<Boolean> Ejecutar()
		{
			DAOBase dao = new DAOBase();
			dao.Retiro(_idUsuario, _idCuenta, _monto);
			return true;
		}
	}
}
