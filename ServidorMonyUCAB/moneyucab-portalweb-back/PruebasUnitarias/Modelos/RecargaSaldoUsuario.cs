using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebasUnitarias.Modelos
{
    class RecargaSaldoUsuario
    {
        int idUsuarioReceptor;
        int idMedioPaga;
        int monto;
        int idOperacion;

        public int IdUsuarioReceptor { get => idUsuarioReceptor; set => idUsuarioReceptor = value; }
        public int IdMedioPaga { get => idMedioPaga; set => idMedioPaga = value; }
        public int Monto { get => monto; set => monto = value; }
        public int IdOperacion { get => idOperacion; set => idOperacion = value; }
    }
}
