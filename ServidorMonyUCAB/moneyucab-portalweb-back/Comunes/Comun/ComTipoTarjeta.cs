using Npgsql;
using System;

namespace Comunes.Comun
{
    /// <summary>
    /// Establece el tipo de tarjeta para definir el comportamiento de la tarjeta.
    /// </summary>
    public class ComTipoTarjeta : EntidadComun, IEntidadComun
    {
        /// <summary>
        /// Establece el identificador único del tipo de tarjeta para su comportamiento dentro de la lógica de negocio.
        /// </summary>
        public int idTipoTarjeta { get; set; }
        /// <summary>
        /// Establece la descripción de uso del tipo de tarjeta.
        /// </summary>
        public string descripcion { get; set; }
        /// <summary>
        /// Establece el estatus de uso dentro de la lógica de negocio.
        /// </summary>
        public int estatus { get; set; }

        public ComTipoTarjeta()
        {

        }

        /// <summary>
        /// Constructor con objetivo de simplificar el llenado para la asignación de un banco a través de un método específico.
        /// </summary>
        /// <param name="IdTipoTarjeta">Establece el tip ode tarjeta que establece una creación rápida para su uso dentro de la lógica.</param>
        public ComTipoTarjeta(int IdTipoTarjeta)
        {
            this.idTipoTarjeta = IdTipoTarjeta;
        }

        public void LlenadoDataNpgsql(NpgsqlDataReader Data)
        {
            this.idTipoTarjeta = Data.GetInt32(0 + offset);
            this.descripcion = Data.GetString(1 + offset);
            this.estatus = Data.GetInt32(2 + offset);
        }
    }
}
