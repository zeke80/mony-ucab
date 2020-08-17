using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using NpgsqlTypes;

namespace Comunes.Comun
{
    public class ComRangoFechas : EntidadComun, IEntidadComun
    {
        public int idoperacionesmonedero { get; set; }
        public int idusuario { get; set; }
        public int idoperacion { get; set; }
        public double monto { get; set; }
        public NpgsqlDate fecha { get; set; }
        public TimeSpan hora { get; set; }
        public string referencia { get; set; }

        public ComRangoFechas()
        {

        }
        public ComRangoFechas(int idoperacion)
        {
            this.idoperacionesmonedero = idoperacion;
        }

        public void LlenadoDataNpgsql(NpgsqlDataReader Data)
        {
            this.idoperacionesmonedero = Data.GetInt32(0 + offset);
            this.idusuario = Data.GetInt32(1 + offset);
            this.idoperacion = Data.GetInt32(2 + offset);
            this.monto = Data.GetDouble(3 + offset);
            this.fecha = Data.GetDate(4 + offset);
            this.hora = Data.GetTimeSpan(5 + offset);
            this.referencia = Data.GetString(6 + offset);
        }

       
    }
}
