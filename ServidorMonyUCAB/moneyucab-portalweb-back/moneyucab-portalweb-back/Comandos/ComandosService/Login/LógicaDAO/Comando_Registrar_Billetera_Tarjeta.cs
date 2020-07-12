using Comunes.Comun;
using DAO;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace moneyucab_portalweb_back.Comandos.ComandosService.Login.Simples
{
	public class Comando_Registrar_Billetera_Tarjeta
	{
		private int _idUsuario { get; set; }
		private int _idTipoTarjeta { get; set; }
		private int _idBanco { get; set; }
		private long _numero { get; set; }
		private NpgsqlDate _fechaVencimiento { get; set; }
		private int _cvc { get; set; }
		private int _estatus { get; set; }

		public Comando_Registrar_Billetera_Tarjeta(int IdUsuario, int IdTipoTarjeta, int IdBanco, long Numero , NpgsqlDate FechaVencimiento, int CVC, int Estatus)
		{
			this._idUsuario = IdUsuario;
			this._idTipoTarjeta = IdTipoTarjeta;
			this._idBanco = IdBanco;
			this._numero = Numero;
			this._fechaVencimiento = FechaVencimiento;
			this._cvc = CVC;
			this._estatus = Estatus;
		}
		async public Task<Boolean> Ejecutar()
		{
			DAOBase dao = new DAOBase();
			ComTipoTarjeta comTipoTarjeta = new ComTipoTarjeta(_idTipoTarjeta);
			ComBanco comBanco = new ComBanco(_idBanco);
			ComTarjeta comTarjeta = new ComTarjeta(comTipoTarjeta, comBanco, _idUsuario, _numero, _fechaVencimiento, _cvc, _estatus);
			dao.RegistroTarjeta(comTarjeta);

			return true;
		}
	}
}
