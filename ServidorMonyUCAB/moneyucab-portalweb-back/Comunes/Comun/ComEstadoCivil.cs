using Npgsql;
using System;

namespace Comunes.Comun
{
    /// <summary>
    /// Entidad común Estado civil que establece en que estado legal sobre relación está una persona.
    /// </summary>
    public class ComEstadoCivil : EntidadComun, IEntidadComun
    {
        /// <summary>
        /// Establece el identificador único de la entidad relacionado directamente en base de datos.
        /// </summary>
        public int idEstadoCivil { get; set; }
        /// <summary>
        /// Establece la descripción del estado civil.
        /// </summary>
        public string descripcion { get; set; }
        /// <summary>
        /// Establece el código que identifica el estado civil dentro de documentos o procedimientos dentro de la aplicación.
        /// </summary>
        public char codigo { get; set; }
        /// <summary>
        /// Estatus del estado civil y si puede ser utilizado dentro de la aplicación
        /// </summary>
        public int estatus { get; set; }

        public ComEstadoCivil()
        {

        }

        /// <summary>
        /// Constructor con objetivo de simplificar el llenado para la asignación de un banco a través de un método específico.
        /// </summary>
        /// <param name="IdEstadoCivil">Establece el identificador único de la entidad relacionado directamente en base de datos.</param>
        /// <param name="Descripcion">Establece la descripción del estado civil.</param>
        /// <param name="Codigo">Establece el código que identifica el estado civil dentro de documentos o procedimientos dentro de la aplicación.</param>
        /// <param name="Estatus">Estatus del estado civil y si puede ser utilizado dentro de la aplicación</param>
        public ComEstadoCivil(int IdEstadoCivil, string Descripcion, char Codigo, int Estatus)
        {
            this.idEstadoCivil = IdEstadoCivil;
            this.descripcion = Descripcion;
            this.codigo = Codigo;
            this.estatus = Estatus;
        }

        public void LlenadoDataNpgsql(NpgsqlDataReader Data)
        {
            this.idEstadoCivil = Data.GetInt32(0 + offset);
            this.descripcion = Data.GetString(1 + offset);
            this.codigo = Data.GetChar(2 + offset);
            this.estatus = Data.GetInt32(3 + offset);
        }
    }
}
