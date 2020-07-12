using Npgsql;
using NpgsqlTypes;
using System;

namespace Comunes.Comun
{

    /// <summary>
    /// Entidad común que establece un Pago realizado por una persona a otra, también tiene como función establecer un cobro.
    /// </summary>
    public class ComPago : EntidadComun, IEntidadComun
    {

        /// <summary>
        /// Identificador único del pago/cobro realizado dentro de la base de datos.
        /// </summary>
        public int idPago { get; set; }
        /// <summary>
        /// Identificador del usuario que solicita realizar un pago al usuario receptor (Usuario que paga).
        /// </summary>
        public int idUsuarioSolicitante { get; set; }
        /// <summary>
        /// Identificador del usuario que recibe el resultado de dicho pago (Usuario que cobra).
        /// </summary>
        public int idUsuarioReceptor { get; set; }
        /// <summary>
        /// Fecha la cual se realiza dicha operación.
        /// </summary>
        public NpgsqlDate fecha { get; set; }
        /// <summary>
        /// Monto por el cual se realiza el cobro o dicho pago.
        /// </summary>
        public string monto { get; set; }
        /// <summary>
        /// Estatus de procedimiento de dicha operación.
        /// </summary>
        public string estatus { get; set; }
        /// <summary>
        /// Establece el valor de referencia por una transferencia o acción monetaria vinculada a dinero real si es necesario (Vacía si todavía no se ha pagado el cobro).
        /// </summary>
        public string referencia { get; set; }

        public ComPago()
        {

        }

        public void LlenadoDataNpgsql(NpgsqlDataReader Data)
        {
            this.idPago = Data.GetInt32(0 + offset);
            this.idUsuarioSolicitante = Data.GetInt32(1 + offset);
            this.idUsuarioReceptor = Data.GetInt32(2 + offset);
            this.fecha = Data.GetDate(3 + offset);
            this.monto = Data.GetString(4 + offset);
            this.estatus = Data.GetString(5 + offset);
            try
            {
                this.referencia = Data.GetString(6 + offset);
            }
            catch (InvalidCastException)
            {
                this.referencia = null;
            }
        }
    }
}
