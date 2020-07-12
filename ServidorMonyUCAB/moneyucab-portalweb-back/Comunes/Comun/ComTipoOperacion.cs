using Npgsql;
using System;

namespace Comunes.Comun
{
    /// <summary>
    /// Establece el tipo de operación que clasifica su acción sobre una operación de monedero.
    /// </summary>
    public class ComTipoOperacion : EntidadComun, IEntidadComun
    {
        /// <summary>
        /// Establece el identificador único para el tipo de operación usado.
        /// </summary>
        public int idTipoOperacion { get; set; }
        /// <summary>
        /// Establece la descripción del tipo de operación usada para la operación determinada.
        /// </summary>
        public string descripcion { get; set; }
        /// <summary>
        /// Establece el estatus de uso dentro de la lógica de negocio.
        /// </summary>
        public int estatus { get; set; }

        public ComTipoOperacion()
        {

        }

        public void LlenadoDataNpgsql(NpgsqlDataReader Data)
        {
            this.idTipoOperacion = Data.GetInt32(0 + offset);
            this.descripcion = Data.GetString(1 + offset);
            this.estatus = Data.GetInt32(2 + offset);
        }
    }
}
