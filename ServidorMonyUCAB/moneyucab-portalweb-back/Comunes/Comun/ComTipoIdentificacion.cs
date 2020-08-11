using Npgsql;
using System;

namespace Comunes.Comun
{
    /// <summary>
    /// Establece el tipo de identificación que actúa sobre un usuario dentro de la aplicación.
    /// </summary>
    public class ComTipoIdentificacion : EntidadComun, IEntidadComun
    {
        /// <summary>
        /// Identificador único para la entidad directamente en base de datos.
        /// </summary>
        public int idTipoIdentificacion { get; set; }
        /// <summary>
        /// Establece el código del tipo de identificación para actuar dentro de la lógica de negocio.
        /// </summary>
        public char codigo { get; set; }
        /// <summary>
        /// Establece la descripción de uso del tipo de identificación.
        /// </summary>
        public string descripcion { get; set; }
        /// <summary>
        /// Establece el estatus de uso sobre este tipo de identificación para la lógica de negocio.
        /// </summary>
        public int estatus { get; set; }

        public ComTipoIdentificacion()
        {

        }

        /// <summary>
        /// Constructor con objetivo de simplificar el llenado para la asignación de un banco a través de un método específico.
        /// </summary>
        /// <param name="IdTipoIdentificacion">Establece el identificador único para dicha entidad.</param>
        /// <param name="Codigo">Establece la identificación para uso de lógica de negocio.</param>
        /// <param name="Descripcion">Describe el tipo de identificación implementada.</param>
        /// <param name="Estatus">Establece el estatus de uso dentor de la lógica de negocio.</param>
        public ComTipoIdentificacion(int IdTipoIdentificacion, char Codigo, string Descripcion, int Estatus)
        {
            this.idTipoIdentificacion = IdTipoIdentificacion;
            this.codigo = Codigo;
            this.descripcion = Descripcion;
            this.estatus = Estatus;
        }

        public void LlenadoDataNpgsql(NpgsqlDataReader Data)
        {
            try
            {
                this.idTipoIdentificacion = Data.GetInt32(0 + offset);
            }
            catch (InvalidCastException ex)
            {
                this.idTipoIdentificacion = 0;
            }
            try
            {
                this.codigo = Data.GetChar(1 + offset);
            }
            catch (InvalidCastException ex)
            {
                this.codigo = 'c';
            }
            try
            {
                this.descripcion = Data.GetString(2 + offset);
            }
            catch (InvalidCastException ex)
            {
                this.descripcion = "";
            }
            try
            {
                this.estatus = Data.GetInt32(3 + offset);
            }
            catch (InvalidCastException ex)
            {
                this.estatus = 0;
            }
        }
    }
}
