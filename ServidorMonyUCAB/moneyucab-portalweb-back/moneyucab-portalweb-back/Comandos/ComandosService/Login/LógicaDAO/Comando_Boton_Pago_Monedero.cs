using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace moneyucab_portalweb_back.Comandos.ComandosService.Login.Simples
{
	public class Comando_Boton_Pago_Monedero
	{
		private int _idUsuario { get; set; }
		private string _usuarioDestino { get; set; }
		private double _monto { get; set; }

		public Comando_Boton_Pago_Monedero(int IdUsuarioReceptor, string IdUsuario, double Monto)
		{
			this._idUsuario = IdUsuarioReceptor;
			this._usuarioDestino = IdUsuario;
			this._monto = Monto;
		}

		async public Task<Boolean> Ejecutar()
		{
			DAOBase dao = new DAOBase();
			dao.BotonPagoMonedero(_idUsuario, _usuarioDestino, _monto);
			return true;
		}
	}
}
