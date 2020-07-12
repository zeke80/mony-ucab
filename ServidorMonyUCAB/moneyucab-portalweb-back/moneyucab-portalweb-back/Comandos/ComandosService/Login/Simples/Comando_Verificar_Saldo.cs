using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace moneyucab_portalweb_back.Comandos.ComandosService.Login.Simples
{
	public class Comando_Verificar_Saldo
	{
		public int _idUsuario;

		public Comando_Verificar_Saldo(int IdUsuario)
		{
			this._idUsuario = IdUsuario;
		}

		async public Task<Double> Ejecutar()
		{
			DAOBase dao = new DAOBase();
			
			return dao.SaldoMonedero(this._idUsuario);
		}
		
		
	}
}
