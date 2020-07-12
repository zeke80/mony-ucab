using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace moneyucab_portalweb_back.Comandos.ComandosService.Login.Simples
{
	public class Comando_Solicitar_Reintegro
	{
		public int _idUsuarioSolicitante { get; set; }
		public string _emailPagador { get; set; }
		public string _referencia { get; set; }

		public Comando_Solicitar_Reintegro(int _idUsuarioSolicitante,string _emailPagador,string _referencia)
		{
			this._idUsuarioSolicitante = _idUsuarioSolicitante;
			this._emailPagador = _emailPagador;
			this._referencia = _referencia;
		}

		async public Task<Boolean> Ejecutar()
		{
			DAOBase dao = new DAOBase();
			dao.Reintegro(_idUsuarioSolicitante, _emailPagador, _referencia);
			return true;
		}
	}
}
