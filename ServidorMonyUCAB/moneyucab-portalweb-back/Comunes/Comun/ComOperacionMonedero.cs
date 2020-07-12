using Npgsql;
using NpgsqlTypes;
using System;

namespace Comunes.Comun
{

    /// <summary>
    /// Establece la entidad que define las operaciones que se han realizado en un monedero
    /// </summary>
    public class ComOperacionMonedero : EntidadComun, IEntidadComun
    {
        /// <summary>
        /// Tipo de operación que se realizó en el monedero.
        /// </summary>
        public ComTipoOperacion tipoOperacion = new ComTipoOperacion();
        /// <summary>
        /// Operacion Tarjeta vinculada a la operación de monedero.
        /// </summary>
        public ComOperacionTarjeta operacionTarjeta = new ComOperacionTarjeta();
        /// <summary>
        /// Operacion Cuenta vinculada a la operación de monedero.
        /// </summary>
        public ComOperacionCuenta operacionCuenta = new ComOperacionCuenta();
        /// <summary>
        /// Identificador único de la operación de monedero dentro de la base de datos.
        /// </summary>
        public int idOperacionMonedero { get; set; }
        /// <summary>
        /// Identificador del usuario que vincula la operación de monedero.
        /// </summary>
        public int idUsuario { get; set; }
        /// <summary>
        /// Monto que ejecuta una operación monetaria dentro del monedero.
        /// </summary>
        public double monto { get; set; }
        /// <summary>
        /// Fecha la cual se realiza dicha operación.
        /// </summary>
        public NpgsqlDate fecha { get; set; }
        //private NpgsqlDateTime _hora{ get; set; }
        /// <summary>
        /// Referencia o valor identificador único a través de una operación monetaria vinculada con el monedero.
        /// </summary>
        public string referencia { get; set; }

        public ComOperacionMonedero()
        {
            
        }

        public void LlenadoDataNpgsql(NpgsqlDataReader Data)
        {
            try
            {
                this.operacionTarjeta.offset = 10;
                this.operacionTarjeta.LlenadoDataNpgsql(Data);
            }
            catch (InvalidCastException)
            {
                this.operacionTarjeta = null;
            }
            try
            {
                this.operacionCuenta.offset = 17;
                this.operacionCuenta.LlenadoDataNpgsql(Data);
            }
            catch (InvalidCastException)
            {
                this.operacionCuenta = null;
            }
            this.idOperacionMonedero = Data.GetInt32(0 + offset);
            this.idUsuario = Data.GetInt32(1 + offset);
            this.fecha = Data.GetDate(4 + offset);
            //this._hora = data.GetDateTime(5 + _offset);
            this.monto = Data.GetDouble(3 + offset);
            this.referencia = Data.GetString(6 + offset);
            this.tipoOperacion.offset = 7;
            this.tipoOperacion.LlenadoDataNpgsql(Data);
        }

        public void LlenadoDataCierreNpgsql(NpgsqlDataReader Data)
        {
            this.idOperacionMonedero = Data.GetInt32(0 + offset);
            this.idUsuario = Data.GetInt32(1 + offset);
            this.fecha = Data.GetDate(4 + offset);
            //this._hora = data.GetDateTime(5 + _offset);
            this.monto = Data.GetDouble(3 + offset);
            this.referencia = Data.GetString(6 + offset);
            this.tipoOperacion.offset = 7;
            this.tipoOperacion.LlenadoDataNpgsql(Data);
        }
    }
}
