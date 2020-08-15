using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace moneyucab_portalweb_back.EntitiesForm
{
	public class EjecuciónPagoExternoRecarga : EjecuciónPagoExterno
	{
		public int idUsuario { get; set; }
		public int idCuenta { get; set; }
		public double monto { get; set; }
	}
}
