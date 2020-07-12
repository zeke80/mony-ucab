using Npgsql;
using System;

namespace Comunes.Comun
{
    /// <summary>
    /// Entidad común que representa las frecuencias vinculadas dentro de la aplicación. Frecuencias temporales para establecer parámetros.
    /// </summary>
    public class ComFrecuencia : EntidadComun, IEntidadComun
    {
        /// <summary>
        /// Identificador único de la entidad dentro de la base de datos.
        /// </summary>
        public int idFrecuencia { get; set; }
        /// <summary>
        /// Código identificador como nombre de la frecuencia dentro de la aplicación.
        /// </summary>
        public char codigo { get; set; }
        /// <summary>
        /// Descripción de la entidad dentro de la aplicación.
        /// </summary>
        public string descripcion { get; set; }
        /// <summary>
        /// Estatus para uso dentro de la aplicación.
        /// </summary>
        public int estatus { get; set; }

        public ComFrecuencia()
        {

        }

        public void LlenadoDataNpgsql(NpgsqlDataReader Data)
        {
            this.idFrecuencia = Data.GetInt32(0 + offset);
            this.codigo = Data.GetChar(1 + offset);
            this.descripcion = Data.GetString(2 + offset);
            this.estatus = Data.GetInt32(3 + offset);
        }
    }
}
