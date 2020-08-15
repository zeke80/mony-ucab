using PayPal.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace moneyucab_portalweb_back.EntitiesForm
{
	public class TransferenciaExternaPayPal : Transferencia
	{
		public bool reg { get; set; }
		public Payment payment { get; set; }
	}
}
