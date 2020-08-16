using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comunes.Comun
{
    public class ComBitacora: EntidadComun, IEntidadComun
    {
        public int idauditoria { get; set; }
        public int idevento { get; set; }
        public int idusuario { get; set; }
        public NpgsqlDate fecha { get; set; }
        public TimeSpan hora { get; set; }
        public string datos { get; set; }
        public string causa { get; set; }

        public ComBitacora() {
        }

        public void LlenadoDataNpgsql(NpgsqlDataReader Data)
        {
            this.idauditoria = Data.GetInt32(0 + offset);
            this.idevento = Data.GetInt32(1 + offset);
            this.idusuario = Data.GetInt32(2 + offset);
            this.fecha = Data.GetDate(3 + offset);
            this.hora = Data.GetTimeSpan(4 + offset);
            this.datos = Data.GetString(5 + offset);
            this.causa = Data.GetString(6 + offset);
        }
    }

   
}
