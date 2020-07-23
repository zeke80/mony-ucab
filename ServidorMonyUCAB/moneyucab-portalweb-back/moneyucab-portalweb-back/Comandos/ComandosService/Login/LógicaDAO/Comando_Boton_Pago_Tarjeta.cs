using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace moneyucab_portalweb_back.Comandos.ComandosService.Login.Simples
{
	public class Comando_Boton_Pago_Tarjeta
	{
		private int _idUsuario { get; set; }
		private string _usuarioDestino { get; set; }
		private double _monto { get; set; }
		private int _idTarjeta { get; set; }

		public Comando_Boton_Pago_Tarjeta(int IdUsuarioReceptor, string IdUsuario, double Monto, int IdTarjeta)
		{
			this._idUsuario = IdUsuarioReceptor;
			this._usuarioDestino = IdUsuario;
			this._monto = Monto;
			this._idTarjeta = IdTarjeta;
		}

		async public Task<Boolean> Ejecutar()
		{
			DAOBase dao = new DAOBase();
			dao.BotonPagoTarjeta(_idUsuario, _usuarioDestino, _monto, _idTarjeta);
			return true;
		}
	}
}
