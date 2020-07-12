using Npgsql;
using System;

namespace Comunes.Comun
{
    /// <summary>
    /// Clase común Banco, sirve como medio por el cual se controla la información sobre esta entidad en toda la aplicación.
    /// Esto permite además servir como un formulario de datos para la ejecución de diferntes métodos DAO.
    /// </summary>
    public class ComBanco : EntidadComun, IEntidadComun
    {
        /// <summary>
        /// Id específico para determinar la llave primaria de la entidad.
        /// </summary>
        public int idBanco { get; set; }
        /// <summary>
        /// Nombre que identifica a la entidad.
        /// </summary>
        public string nombre { get; set; }
        /// <summary>
        /// Id específico para determinar la llave primaria de la entidad
        /// </summary>
        public int estatus { get; set; }

        public ComBanco()
        {

        }

        /// <summary>
        /// Constructor con objetivo de simplificar el llenado para la asignación de un banco a traés de un método específico.
        /// </summary>
        /// <param name="idBanco">Específica el id del Banco al cual se le dará uso como formulario.</param>
        public ComBanco(int idBanco)
        {
            this.idBanco = idBanco;
        }

        public void LlenadoDataNpgsql(NpgsqlDataReader data)
        {
            this.idBanco = data.GetInt32(0 + offset);
            this.nombre = data.GetString(1 + offset);
            this.estatus = data.GetInt32(2 + offset);
        }
    }
}
