using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace moneyucab_portalweb_back.EntitiesForm
{
	public class EjecuciónPagoExterno
	{
		public bool reg { get; set; }
		public int idOperacion { get; set; }
		public string idPago { get; set; }
		public string idUsuarioPagante { get; set; }
	}
}
