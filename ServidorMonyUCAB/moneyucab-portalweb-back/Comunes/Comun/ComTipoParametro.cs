using Npgsql;
using System;

namespace Comunes.Comun
{
    /// <summary>
    /// Establece el tipo de parámetro que actúa sobre las operaciones de transferencia monetaria dentro de la lógica de negocio.
    /// </summary>
    public class ComTipoParametro : EntidadComun, IEntidadComun
    {
        /// <summary>
        /// Establece el identificador único del tipo de parámetro usado dentro de la lógica de negocio.
        /// </summary>
        public int idTipoParametro { get; set; }
        /// <summary>
        /// Establece la descripción de uso para dicho tipo de parámetro dentro de la lógica de negocio.
        /// </summary>
        public string descripcion { get; set; }
        /// <summary>
        /// Establece el estatus de uso para dicho tipo de parámetro dentro de la lógica de negocio.
        /// </summary>
        public int estatus { get; set; }

        public ComTipoParametro()
        {

        }

        public void LlenadoDataNpgsql(NpgsqlDataReader Data)
        {
            this.idTipoParametro = Data.GetInt32(0 + offset);
            this.descripcion = Data.GetString(1 + offset);
            this.estatus = Data.GetInt32(2 + offset);
        }
    }
}
