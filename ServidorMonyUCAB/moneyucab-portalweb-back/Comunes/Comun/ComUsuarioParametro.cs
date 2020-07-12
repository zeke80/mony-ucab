using Npgsql;
using NpgsqlTypes;
using System;

namespace Comunes.Comun
{
    /// <summary>
    /// Establece la entidad común UsuarioParametro, la cual establece la relación de los parámetros con un usuario específico.
    /// </summary>
    public class ComUsuarioParametro : EntidadComun, IEntidadComun, IFormularioInsert
    {
        /// <summary>
        /// Establece el identificador único del usuario dentro de la lógica de negocio.
        /// </summary>
        public int idUsuario { get; set; }
        /// <summary>
        /// Establece el parámetro determinado para su uso dentro de la aplicación respecto a transferencias monetarias.
        /// </summary>
        public ComParametro parametro = new ComParametro();
        /// <summary>
        /// Establece el valor que valida la acción del parámetro respecto a las operaciones de transferencia monetaria.
        /// </summary>
        public string validacion { get; set; }
        /// <summary>
        /// Establece el estatus de uso dentro de la aplicación de la relación del usuario con el parámetro.
        /// </summary>
        public int estatus { get; set; }

        public ComUsuarioParametro()
        {
            
        }

        /// <summary>
        /// Constructor con objetivo de simplificar el llenado para la asignación de un banco a través de un método específico.
        /// </summary>
        /// <param name="IdUsuario">Establece el identificador único del usuario dentro de la aplicación.</param>
        /// <param name="IdParametro">Establece el identificador único del parámetro para su uso dentro de la aplicación.</param>
        /// <param name="Validacion">Establece el valor que realiza la validación del parámetro respecto a las operaciones de transferencia monetaria.</param>
        /// <param name="Estatus">Establece el estatus de uso de dicho parámetro definido por el usuario dentro de la aplicación.</param>
        public ComUsuarioParametro(int IdUsuario, int IdParametro, string Validacion, int Estatus)
        {
            this.idUsuario = IdUsuario;
            this.validacion = Validacion;
            this.estatus = Estatus;
            this.parametro = new ComParametro(IdParametro);
        }

        public void LlenadoDataForm(NpgsqlCommand ComandoSQL)
        {
            ComandoSQL.Parameters.Add(new NpgsqlParameter("UsuarioId", this.idUsuario));
            ComandoSQL.Parameters.Add(new NpgsqlParameter("ParametroId", this.parametro.idParametro));
            ComandoSQL.Parameters.Add(new NpgsqlParameter("Validacion", this.validacion));
            ComandoSQL.Parameters.Add(new NpgsqlParameter("Estatus", this.estatus));
        }

        public void LlenadoDataNpgsql(NpgsqlDataReader Data)
        {
            this.idUsuario = Data.GetInt32(0 + offset);
            this.validacion = Data.GetString(2 + offset);
            this.estatus = Data.GetInt32(3 + offset);
            this.parametro.offset = 4;
            this.parametro.LlenadoDataNpgsql(Data);
        }
    }
}
