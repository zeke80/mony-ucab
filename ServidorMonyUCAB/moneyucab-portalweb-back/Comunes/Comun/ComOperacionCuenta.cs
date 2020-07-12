using Npgsql;
using NpgsqlTypes;
using System;

namespace Comunes.Comun
{
    /// <summary>
    /// Entidad común Operacion Cuenta que establece las operaciones de pago o reintegro que se realizaron con una cuenta determinada.
    /// </summary>
    public class ComOperacionCuenta : EntidadComun, IEntidadComun
    {
        /// <summary>
        /// Identificador único que establece una operación de cuenta.
        /// </summary>
        public int idOperacionCuenta { get; set; }
        /// <summary>
        /// Identificador del usuario que recibe el resultado de la operación.
        /// </summary>
        public int idUsuarioReceptor { get; set; }
        /// <summary>
        /// Identificador de la cuenta que realizó dicha operación.
        /// </summary>
        public int idCuenta { get; set; }
        /// <summary>
        /// Establece la fecha que se realizó dicha operación.
        /// </summary>
        public NpgsqlDate fecha { get; set; }
        //private string _hora{ get; set; }
        /// <summary>
        /// Monto de transferencia que se realizó en dicha operación.
        /// </summary>
        public double monto { get; set; }
        /// <summary>
        /// Establece la referencia que tiene como identificador particular de dicha entidad.
        /// </summary>
        public string referencia { get; set; }

        public ComOperacionCuenta()
        {

        }

        public void LlenadoDataNpgsql(NpgsqlDataReader Data)
        {
            this.idOperacionCuenta = Data.GetInt32(0 + offset);
            this.idUsuarioReceptor = Data.GetInt32(1 + offset);
            this.idCuenta = Data.GetInt32(2 + offset);
            this.fecha = Data.GetDate(3 + offset);
            //this._hora = data.GetString(4 + _offset);
            this.monto = Data.GetDouble(5 + offset);
            this.referencia = Data.GetString(6 + offset);
        }
    }
}