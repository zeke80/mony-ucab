using Npgsql;
using System;

namespace Comunes.Comun
{
    /// <summary>
    /// Entidad común Parametro que vincula una frecuencia con un tipo de parámetro para validar acciones dentro de la aplicación.
    /// </summary>
    public class ComParametro : EntidadComun, IEntidadComun
    {

        /// <summary>
        /// Establece el tipo de parametro que categoriza el parámetro.
        /// </summary>
        public ComTipoParametro tipoParametro = new ComTipoParametro();
        /// <summary>
        /// Atributo temporal que establece la acción de dicho tipo de parámetro.
        /// </summary>
        public ComFrecuencia frecuencia = new ComFrecuencia();
        /// <summary>
        /// Identificador único del parámetro dentro de la base de datos para uso de la aplicación.
        /// </summary>
        public int idParametro { get; set; }
        /// <summary>
        /// Nombre que establece el identificador del Parametro.
        /// </summary>
        public string nombre { get; set; }
        /// <summary>
        /// Establece el estatus para su uso dentro de la aplicación.
        /// </summary>
        public int estatus { get; set; }

        public ComParametro()
        {

        }

        /// <summary>
        /// Constructor con objetivo de simplificar el llenado para la asignación de un parámetro dentro de la aplicación.
        /// </summary>
        /// <param name="IdParametro">Establece el identificador único de la entidad relacionado directamente en base de datos.</param>
        public ComParametro(int idParametro)
        {
            this.idParametro = idParametro;
        }

        public void LlenadoDataNpgsql(NpgsqlDataReader Data)
        {
            this.idParametro = Data.GetInt32(0 + offset);
            this.nombre = Data.GetString(3 + offset);
            this.estatus = Data.GetInt32(4 + offset);
            this.tipoParametro.offset = 5 + offset;
            this.tipoParametro.LlenadoDataNpgsql(Data);
            this.frecuencia.offset = 8 + offset;
            this.frecuencia.LlenadoDataNpgsql(Data);
        }
    }
}
