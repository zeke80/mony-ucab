using moneyucab_portalweb_back.Contextos;
using moneyucab_portalweb_back.EntitiesForm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace moneyucab_portalweb_back.Comandos.ComandosService.Utilidades
{	//este se habia hecho antes de la logica de los comandos por eso no lo usa
	public class EntityDatosUsuario
	{
		private readonly DatosUsuarioDBContext _datosUsuarioDBContext;
		public EntityDatosUsuario(DatosUsuarioDBContext DatosUsuarioDBContext)
		{
			_datosUsuarioDBContext = DatosUsuarioDBContext;
		}
		
		public List<DatosUsuario> Consultar()
		{
			var resultado = _datosUsuarioDBContext.datosUsuario.ToList();
			return resultado;
		}

		public Boolean Insertar(DatosUsuario DatosUsuario)
		{
				_datosUsuarioDBContext.datosUsuario.Add(DatosUsuario);
				_datosUsuarioDBContext.SaveChanges();
				return true;
		}

		public Boolean Editar(DatosUsuario DatosUsuario)
		{
				var datosUsuarioBaseDeDatos = _datosUsuarioDBContext.datosUsuario.Where(busqueda => busqueda.idUsuario == DatosUsuario.idUsuario).FirstOrDefault();

				datosUsuarioBaseDeDatos.usuario = DatosUsuario.usuario;
				datosUsuarioBaseDeDatos.nroIdentificacion = DatosUsuario.nroIdentificacion;
				datosUsuarioBaseDeDatos.email = DatosUsuario.email;
				datosUsuarioBaseDeDatos.telefono = DatosUsuario.telefono;
				datosUsuarioBaseDeDatos.direccion = DatosUsuario.direccion;
				_datosUsuarioDBContext.SaveChanges();
			return true;
		}

		public Boolean Eliminar(int IdUsuario)
		{
				var usuarioBaseDeDatos = _datosUsuarioDBContext.datosUsuario.Where(busqueda => busqueda.idUsuario == IdUsuario).FirstOrDefault();
				_datosUsuarioDBContext.Remove(usuarioBaseDeDatos);

				_datosUsuarioDBContext.SaveChanges(); 
			return true;
		}

	}
}
