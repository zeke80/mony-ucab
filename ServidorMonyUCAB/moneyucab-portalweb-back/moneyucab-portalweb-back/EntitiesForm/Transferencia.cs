using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace moneyucab_portalweb_back.EntitiesForm
{
	public class Transferencia
	{
		public int idUsuarioReceptor { get; set; }
		public int idMedioPaga { get; set; }
		public double monto { get; set; }
		public int idOperacion { get; set; }
	}
}
