using Npgsql;
using NpgsqlTypes;
using System;

namespace Comunes.Comun
{

    /// <summary>
    /// Entidad común que establece las opciones de menú para el uso de usuario.
    /// </summary>
    public class ComOpcionMenu : EntidadComun, IEntidadComun
    {

        /// <summary>
        /// Identificador único de la opcion menú
        /// </summary>
        public int idOpcionMenu { get; set; }
        /// <summary>
        /// Identificador de la aplicación de la cual hace uso la opción).
        /// </summary>
        public int idAplicacion { get; set; }
        /// <summary>
        /// Nombre de la opción
        /// </summary>
        public string nombre { get; set; }
        /// <summary>
        /// Descripción de la opción
        /// </summary>
        public string descripcion { get; set; }
        /// <summary>
        /// Url de uso
        /// </summary>
        public string url { get; set; }
        /// <summary>
        /// Posición de uso
        /// </summary>
        public int posicion { get; set; }
        /// <summary>
        /// Estatus de la opción de menú
        /// </summary>
        public int estatus { get; set; }

        public ComOpcionMenu()
        {

        }

        public void LlenadoDataNpgsql(NpgsqlDataReader Data)
        {
            this.idOpcionMenu = Data.GetInt32(0 + offset);
            this.idAplicacion = Data.GetInt32(1 + offset);
            this.nombre = Data.GetString(2 + offset);
            this.descripcion = Data.GetString(3 + offset);
            this.url = Data.GetString(4 + offset);
            this.posicion = Data.GetInt32(5 + offset);
            this.estatus = Data.GetInt32(6 + offset);
        }
    }
}
