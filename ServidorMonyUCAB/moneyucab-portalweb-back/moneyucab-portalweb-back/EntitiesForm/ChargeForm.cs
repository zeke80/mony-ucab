using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace moneyucab_portalweb_back.EntitiesForm
{
    public class ChargeForm
    {
        public int monto { get; set; }
        public string descripcion { get; set; }
        public string emailReceptor { get; set; }
        public string id { get; set; }
        public bool reg { get; set; }
        public int idOperacion { get; set; }

    }
}
