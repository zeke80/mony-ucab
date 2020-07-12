using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace moneyucab_portalweb_back.Comandos.ComandosService.Login.Simples
{
	public class Comando_Recarga_Monedero_Tarjeta
	{
		private int _idUsuarioReceptor { get; set; }
		private int _idMedioPaga { get; set; }
		private double _monto { get; set; }

		public Comando_Recarga_Monedero_Tarjeta(int IdUsuarioReceptor, int IdMedioPaga,double Monto)
		{
			this._idUsuarioReceptor = IdUsuarioReceptor;
			this._idMedioPaga = IdMedioPaga;
			this._monto = Monto;
		}

		async public Task<Boolean> Ejecutar()
		{
			DAOBase dao = new DAOBase();
			dao.RecargaMonederoTarjeta(_idUsuarioReceptor, _idMedioPaga, _monto);
			return true;
		}
	}
}
