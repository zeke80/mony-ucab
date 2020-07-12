using Comunes.Comun;
using DAO;
using System;
using System.Threading.Tasks;

namespace moneyucab_portalweb_back.Comandos.ComandosService.Login.Simples
{
	public class Comando_Registrar_Billetera_Cuenta
	{
		private int _idUsuario { get; set; }
		private int _idTipoCuenta { get; set; }
		private int _idBanco { get; set; }
		private string _numero { get; set; }

		public Comando_Registrar_Billetera_Cuenta(int IdUsuario, int IdTipoCuenta,int IdBanco, string Numero)
		{
			this._idUsuario = IdUsuario;
			this._idTipoCuenta = IdTipoCuenta;
			this._idBanco = IdBanco;
			this._numero = Numero;
		}
		async public Task<Boolean> Ejecutar()
		{
			DAOBase dao = new DAOBase();
			ComBanco comBanco = new ComBanco(_idBanco);
			ComTipoCuenta comTipoCuenta = new ComTipoCuenta(_idTipoCuenta);
			ComCuenta comCuenta = new ComCuenta(comTipoCuenta, comBanco, _idUsuario, _numero);
			dao.RegistroCuenta(comCuenta);

			return true;
		}
	}
}
