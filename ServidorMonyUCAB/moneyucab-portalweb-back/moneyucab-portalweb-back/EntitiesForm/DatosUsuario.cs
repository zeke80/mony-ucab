using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace moneyucab_portalweb_back.EntitiesForm
{
	public class DatosUsuario
	{
		public int idUsuario { get; set; }
		public int idTipoUsuario { get; set; }
		public int idTipoIdentificacion { get; set; }
		public string idEntity { get; set; }
		public string usuario { get; set; }
		public DateTime fechaRegistro { get; set; }
		public int nroIdentificacion { get; set; }
		public string email { get; set; }
		public string telefono { get; set; }
		public string direccion { get; set; }
		public int estatus { get; set; }

		public class Mapeo
		{
			public Mapeo(EntityTypeBuilder<DatosUsuario> mapeoDatosUsuario)
			{
				mapeoDatosUsuario.ToTable("usuario");
				mapeoDatosUsuario.HasKey(x => x.idUsuario);
				mapeoDatosUsuario.Property(x => x.idUsuario).HasColumnName("idusuario");
				mapeoDatosUsuario.Property(x => x.idTipoUsuario).HasColumnName("idtipousuario");
				mapeoDatosUsuario.Property(x => x.idTipoIdentificacion).HasColumnName("idtipoidentificacion");
				mapeoDatosUsuario.Property(x => x.idEntity).HasColumnName("idEntity");
				mapeoDatosUsuario.Property(x => x.usuario).HasColumnName("usuario");
				mapeoDatosUsuario.Property(x => x.fechaRegistro).HasColumnName("fecha_registro");
				mapeoDatosUsuario.Property(x => x.nroIdentificacion).HasColumnName("nro_identificacion");
				mapeoDatosUsuario.Property(x => x.email).HasColumnName("email");
				mapeoDatosUsuario.Property(x => x.telefono).HasColumnName("telefono");
				mapeoDatosUsuario.Property(x => x.direccion).HasColumnName("direccion");
				mapeoDatosUsuario.Property(x => x.estatus).HasColumnName("estatus");
			}
		}
	}
}
