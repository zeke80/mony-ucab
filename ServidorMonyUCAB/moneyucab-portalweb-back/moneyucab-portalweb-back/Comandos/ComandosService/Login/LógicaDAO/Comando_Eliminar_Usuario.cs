using Comunes.Comun;
using DAO;
using Microsoft.AspNetCore.Identity;
using moneyucab_portalweb_back.EntitiesForm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace moneyucab_portalweb_back.Comandos.ComandosService.Login.ConsultasDAO
{
	public class Comando_Eliminar_Usuario
	{
		private int _idUsuario;
		private string _usuario;
		private UserManager<Usuario> _userManager;

		public Comando_Eliminar_Usuario()
		{

		}

		public Comando_Eliminar_Usuario(int IdUsuario, UserManager<Usuario> UserManager, string Usuario)
		{
			this._idUsuario = IdUsuario;
			this._userManager = UserManager;
			this._usuario = Usuario;
		}

		async public Task<bool> Ejecutar()
		{
			var usuario = await this._userManager.FindByNameAsync(this._usuario);
			await this._userManager.DeleteAsync(usuario);
			DAOBase dao = FabricaDAO.CrearDaoBase();
			return dao.EliminarUsuario(this._idUsuario);
		}
		
		
	}
}
