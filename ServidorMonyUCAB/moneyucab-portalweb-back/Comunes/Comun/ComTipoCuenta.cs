using Npgsql;
using System;
using System.Runtime.Serialization;

namespace Comunes.Comun
{
    /// <summary>
    /// Entidad común que establece el tipo de cuenta clasificando su uso dentro de la aplicación.
    /// </summary>
    [DataContract]
    public class ComTipoCuenta : EntidadComun, IEntidadComun
    {
        /// <summary>
        /// Identificador único para el tipo de tarjeta clasicador de las cuentas.
        /// </summary>
        [DataMember]
        public int idTipoCuenta { get; set; }
        /// <summary>
        /// Descripción de uso de tipo de cuenta dentro de la aplicación.
        /// </summary>
        [DataMember]
        public string descripcion { get; set; }
        /// <summary>
        /// Establece el estatus de uso con este tipo de cuenta.
        /// </summary>
        [DataMember]
        public int estatus { get; set; }

        public ComTipoCuenta()
        {

        }

        /// <summary>
        /// Constructor con objetivo de simplificar el llenado para la asignación de un banco a través de un método específico.
        /// </summary>
        /// <param name="IdTipoCuenta">Establece el tipo de cuenta por el cual se realiza la creación.</param>
        public ComTipoCuenta(int IdTipoCuenta)
        {
            this.idTipoCuenta = IdTipoCuenta;
        }

        public void LlenadoDataNpgsql(NpgsqlDataReader Data)
        {
            this.idTipoCuenta = Data.GetInt32(0 + offset);
            this.descripcion = Data.GetString(1 + offset);
            this.estatus = Data.GetInt32(2 + offset);
        }
    }
}
