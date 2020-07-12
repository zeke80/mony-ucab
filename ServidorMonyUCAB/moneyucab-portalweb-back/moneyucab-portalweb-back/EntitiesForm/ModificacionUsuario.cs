using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace moneyucab_portalweb_back.EntitiesForm
{
	public class ModificacionUsuario
	{
		public string nombre { get; set; }
		public string apellido { get; set; }
		public string telefono { get; set; }
		public string direccion { get; set; }
		public string razonSocial { get; set; }
		public int idEstadoCivil { get; set; }
		public int idUsuario { get; set; }
	}
}
