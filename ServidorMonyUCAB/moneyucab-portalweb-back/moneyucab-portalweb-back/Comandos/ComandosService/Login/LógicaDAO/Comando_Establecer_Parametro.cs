using Comunes.Comun;
using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace moneyucab_portalweb_back.Comandos.ComandosService.Login.Simples
{
	public class Comando_Establecer_Parametro
	{
		private int _idUsuario { get; set; }
		private int _idParametro { get; set; }
		private string _validacion { get; set; }
		private int _estatus { get; set; }


		public Comando_Establecer_Parametro(int IdUsuario, int IdParametro, string Validacion, int Estatus)
		{
			this._idUsuario = IdUsuario;
			this._idParametro = IdParametro;
			this._validacion = Validacion;
			this._estatus = Estatus;
		}

		async public Task<Boolean> Ejecutar()
		{
			DAOBase dao = new DAOBase();
			dao.EstablecerParametro(new ComUsuarioParametro(this._idUsuario, this._idParametro, this._validacion, this._estatus));
			return true;
		}
	}
}
