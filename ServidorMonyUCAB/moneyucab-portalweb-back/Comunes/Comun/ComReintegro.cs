using Npgsql;
using NpgsqlTypes;
using System;

namespace Comunes.Comun
{
    /// <summary>
    /// Entidad común de Reintegro que establece la identificación de la solicitud de un reintegro o de pago del mismo.
    /// </summary>
    public class ComReintegro : EntidadComun, IEntidadComun
    {
        /// <summary>
        /// Identificador único que establece la solicitud o el pago de un reintegro.
        /// </summary>
        public int idReintegro { get; set; }
        /// <summary>
        /// Identificador de un usuario que solicita el reintegro (Usuario que recibe el pago).
        /// </summary>
        public int idUsuarioSolicitante { get; set; }
        /// <summary>
        /// Identificador del usuario receptor al cual se le solicita el reintegro (Usuario que debe pagar el reintegro).
        /// </summary>
        public int idUsuarioReceptor { get; set; }
        /// <summary>
        /// Fecha la cual se realizó la operación/solicitud.
        /// </summary>
        public NpgsqlDate fecha { get; set; }
        /// <summary>
        /// Identifica la referencia la cual realizó el reintegro (pago de la solicitud).
        /// </summary>
        public string referencia_reintegro { get; set; }
        /// <summary>
        /// Identifica la referencia la cual se solicita el reintegro sobre dicha transferencia/operación.
        /// </summary>
        public string referencia { get; set; }
        /// <summary>
        /// Identifica los estatus de procedimiento de dicho reintegro.
        /// </summary>
        public string estatus { get; set; }
        /// <summary>
        /// Identifica el monto del reintegro.
        /// </summary>
        public string monto { get; set; }

        public ComReintegro()
        {

        }

        public void LlenadoDataNpgsql(NpgsqlDataReader Data)
        {
            this.idReintegro = Data.GetInt32(0 + offset);
            this.idUsuarioSolicitante = Data.GetInt32(1 + offset);
            this.idUsuarioReceptor = Data.GetInt32(2 + offset);
            this.fecha = Data.GetDate(3 + offset);
            this.referencia_reintegro = Data.GetString(4 + offset);
            try
            {
                this.referencia = Data.GetString(5 + offset);
            }
            catch (InvalidCastException)
            {
                this.referencia = null;
            }
            this.estatus = Data.GetString(6 + offset);
            this.monto = Data.GetString(7 + offset);
        }
    }
}
