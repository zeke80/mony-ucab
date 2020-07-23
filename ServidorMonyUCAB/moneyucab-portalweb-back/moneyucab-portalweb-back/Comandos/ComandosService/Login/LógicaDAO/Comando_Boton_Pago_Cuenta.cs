using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace moneyucab_portalweb_back.Comandos.ComandosService.Login.Simples
{
	public class Comando_Boton_Pago_Cuenta
	{
		private int _idUsuario { get; set; }
		private string _usuarioDestino { get; set; }
		private double _monto { get; set; }
		private int _idCuenta { get; set; }

		public Comando_Boton_Pago_Cuenta(int IdUsuarioReceptor, string IdUsuario, double Monto, int IdCuenta)
		{
			this._idUsuario = IdUsuarioReceptor;
			this._usuarioDestino = IdUsuario;
			this._monto = Monto;
			this._idCuenta = IdCuenta;
		}

		async public Task<Boolean> Ejecutar()
		{
			DAOBase dao = new DAOBase();
			dao.BotonPagoCuenta(_idUsuario, _usuarioDestino, _monto, _idCuenta);
			return true;
		}
	}
}
