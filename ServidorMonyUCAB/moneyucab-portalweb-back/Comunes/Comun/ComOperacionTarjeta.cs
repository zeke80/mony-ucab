using Npgsql;
using NpgsqlTypes;
using System;

namespace Comunes.Comun
{

    /// <summary>
    /// Entidad común que establece una operación que se realiza con una tarjeta.
    /// </summary>
    public class ComOperacionTarjeta : EntidadComun, IEntidadComun
    {

        /// <summary>
        /// Identificador único de la operación con tarjeta.
        /// </summary>
        public int idOperacionTarjeta { get; set; }
        /// <summary>
        /// Identificador del usuario que recibe el resultado de la operación.
        /// </summary>
        public int idUsuarioReceptor { get; set; }
        /// <summary>
        /// Identificador de la tarjeta que realiza la operación.
        /// </summary>
        public int idTarjeta { get; set; }
        /// <summary>
        /// Fecha la cual se realizó dicha operación.
        /// </summary>
        public NpgsqlDate fecha { get; set; }
        //private Npgsql _hora{ get; set; }
        /// <summary>
        /// Monto de la transferencia que realiza dicha operación.
        /// </summary>
        public double monto { get; set; }
        /// <summary>
        /// Identificador de valor único como referencia de transferencia.
        /// </summary>
        public string referencia { get; set; }

        public ComOperacionTarjeta()
        {

        }

        public void LlenadoDataNpgsql(NpgsqlDataReader Data)
        {
            this.idOperacionTarjeta = Data.GetInt32(0 + offset);
            this.idUsuarioReceptor = Data.GetInt32(1 + offset);
            this.idTarjeta = Data.GetInt32(2 + offset);
            this.fecha = Data.GetDate(3 + offset);
            //this._hora = data.GetDateTime(4 + _offset);
            this.monto = Data.GetDouble(5 + offset);
            this.referencia = Data.GetString(6 + offset);
        }
    }
}
