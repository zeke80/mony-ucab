using Microsoft.EntityFrameworkCore;
using moneyucab_portalweb_back.EntitiesForm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace moneyucab_portalweb_back.Contextos
{
	public class DatosUsuarioDBContext : DbContext
	{
		public DatosUsuarioDBContext(DbContextOptions<DatosUsuarioDBContext> Opciones) :base(Opciones)
		{

		}

		public DbSet<DatosUsuario> datosUsuario { get; set; }

		protected override void OnModelCreating(ModelBuilder ModeloCreador)
		{
			new DatosUsuario.Mapeo(ModeloCreador.Entity<DatosUsuario>());
		}
	}
}
