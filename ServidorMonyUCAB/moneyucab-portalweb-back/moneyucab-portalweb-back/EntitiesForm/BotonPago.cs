using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace moneyucab_portalweb_back.EntitiesForm
{
	public class BotonPago
	{
		public int idUsuario { get; set; }
		public int idMedioPaga { get; set; }
		public double monto { get; set; }
		public string usuarioDestino { get; set; }
	}
}
