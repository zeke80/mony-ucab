using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace moneyucab_portalweb_back.Comandos.ComandosService.Login.Simples
{
	public class Comando_Pago_Paypal
	{
		private bool _reg { get; set; }
		private int _idOperacion { get; set; }
		private string _referencia { get; set; }

		public Comando_Pago_Paypal(bool Reg, int IdOperacion, string Referencia)
		{
			this._reg = Reg;
			this._idOperacion = IdOperacion;
			this._referencia = Referencia;
		}

		async public Task<Boolean> Ejecutar()
		{
			DAOBase dao = FabricaDAO.CrearDaoBase();
			dao.PagoPaypal(_reg, _idOperacion, _referencia);
			return true;
		}
	}
}
