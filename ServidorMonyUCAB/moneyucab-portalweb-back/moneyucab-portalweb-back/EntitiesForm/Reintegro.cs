using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace moneyucab_portalweb_back.EntitiesForm
{
	public class Reintegro
	{
		public int idUsuarioSolicitante { get; set; }
		public string emailPagador { get; set; }
		public string referencia { get; set; }
	}
}
