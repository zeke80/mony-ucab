using Comunes.Comun;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace moneyucab_portalweb_back.EntitiesForm
{
	public class ComercioForm
	{
        public string usuario { get; set; }
        public int idUsuario { get; set; }
		public string razonSocial { get; set; }
		public string nombre { get; set; }
		public string apellido { get; set; }

        public ComComercio Formatear_Formulario()
        {
            return new ComComercio(razonSocial, nombre, apellido);
        }
    }
}
