using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace moneyucab_portalweb_back.Comandos.ComandosService.Login.Simples
{
	public class Comando_Realizar_Cobro
	{
		private int _idUsuarioSolicitante { get; set; }
		private string _emailPagador { get; set; }
		private double _monto { get; set; }

		public Comando_Realizar_Cobro(int IdUsuarioSolicitante,string EmailPagador,double Monto)
		{
			this._idUsuarioSolicitante = IdUsuarioSolicitante;
			this._emailPagador = EmailPagador;
			this._monto = Monto;
		}

		async public Task<Boolean> Ejecutar()
		{
			DAOBase dao = new DAOBase();
			dao.Cobro(_idUsuarioSolicitante, _emailPagador, _monto);
			return true;
		}
	}
}
