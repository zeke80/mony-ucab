using PayPal.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace moneyucab_portalweb_back.EntitiesForm
{
	public class TransferenciaExternaPayPal
	{
		public bool reg { get; set; }
		public int idOperacion { get; set; }
		public int monto { get; set; }
		public int status { get; set; }
		public List<Transaction> listaT;
	}
}
