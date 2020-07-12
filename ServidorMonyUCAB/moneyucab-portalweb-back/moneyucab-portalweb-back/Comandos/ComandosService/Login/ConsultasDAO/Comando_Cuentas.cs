using Comunes.Comun;
using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace moneyucab_portalweb_back.Comandos.ComandosService.Login.ConsultasDAO
{
	public class Comando_Cuentas
	{
		private int _idUsuario;

		public Comando_Cuentas()
		{

		}

		public Comando_Cuentas(int IdUsuario)
		{
			this._idUsuario = IdUsuario;
		}

		async public Task<List<Object>> Ejecutar()
		{
			DAOBase dao = FabricaDAO.CrearDaoBase();
			List<ComCuenta> cuentas = dao.Cuentas(this._idUsuario);
			List<Object> cuentasResponse = new List<Object>();
			for (int i = 0; i < cuentas.Count; i++)
            {
				var infoAdicional = new { cuentas[i]._tipoCuenta, cuentas[i]._banco };
				var elementResponse = new { cuentas[i]._idCuenta, cuentas[i]._idUsuario, cuentas[i]._numero, infoAdicional };
				cuentasResponse.Add(elementResponse);
				
            }
			return cuentasResponse;
		}
		
		
	}
}
