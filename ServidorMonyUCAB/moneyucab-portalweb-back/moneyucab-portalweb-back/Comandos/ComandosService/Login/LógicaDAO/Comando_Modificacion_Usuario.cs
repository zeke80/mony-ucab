using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace moneyucab_portalweb_back.Comandos.ComandosService.Login.Simples
{
	public class Comando_Modificacion_Usuario
	{
		private string _nombre { get; set; }
		private string _apellido { get; set; }
		private string _telefono { get; set; }
		private string _direccion { get; set; }
		private string _razonSocial { get; set; }
		private int _idEstadoCivil { get; set; }
		private int _idUsuario { get; set; }

		public Comando_Modificacion_Usuario(string Usuario,string Email, string Telefono, string Direccion, string RazonSocial, int idEstadoCivil, int IdUsuario)
		{
			this._nombre = Usuario;
			this._apellido = Email;
			this._telefono = Telefono;
			this._direccion = Direccion;
			this._razonSocial = RazonSocial;
			this._idEstadoCivil = idEstadoCivil;
			this._idUsuario = IdUsuario;

		}

		async public Task<Boolean> Ejecutar()
		{
			DAOBase dao = new DAOBase();
			dao.ModificaciónUsuario(_nombre, _apellido, _telefono, _direccion, _razonSocial, _idEstadoCivil, _idUsuario);
			return true;
		}
	}
}
