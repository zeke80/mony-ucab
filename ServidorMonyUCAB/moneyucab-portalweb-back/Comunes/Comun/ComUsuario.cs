using Npgsql;
using NpgsqlTypes;
using System;

namespace Comunes.Comun
{
    /// <summary>
    /// Entidad común de usuario, establece todos los atributos de autenticación y acción de la lógica sobre el consumidor de la aplicación.
    /// </summary>
    public class ComUsuario : EntidadComun, IEntidadComun, IFormularioRegistro
    {
        /// <summary>
        /// Establece la información de comercio relacionada con el usuario.
        /// </summary>
        public ComComercio comercio = new ComComercio();
        /// <summary>
        /// Establece la información de persona relacionada con el usuario.
        /// </summary>
        public ComPersona persona = new ComPersona();
        /// <summary>
        /// Establece el tipo de identificación relacionada directamente con el usuario.
        /// </summary>
        public ComTipoIdentificacion tipoIdentificacion = new ComTipoIdentificacion();
        /// <summary>
        /// Establece el identificador único del usuario dentro de la aplicación.
        /// </summary>
        public int idUsuario { get; set; }
        /// <summary>
        /// Establece el identificador único vinculado con el framework de autenticación Identity.
        /// </summary>
        public string idEntity { get; set; }
        /// <summary>
        /// Establece el nombre de usuario utilizado para realizar operaciones y funcionalidades dentro de la aplicación.
        /// </summary>
        public string usuario { get; set; }
        /// <summary>
        /// Establece la fecha de registro para dicho usuario.
        /// </summary>
        public NpgsqlDate fechaRegistro { get; set; }
        /// <summary>
        /// Establece el númeor de identificación legal para el usuario.
        /// </summary>
        public int nroIdentificacion { get; set; }
        /// <summary>
        /// Establece el correo electrónico para uso de dicho usuario dentro de la plataforma.
        /// </summary>
        public string email { get; set; }
        /// <summary>
        /// Establece el número telefónico relacionado con el usuario.
        /// </summary>
        public string telefono { get; set; }
        /// <summary>
        /// Establece la dirección de vivienda o localización de dicho usuario.
        /// </summary>
        public string direccion { get; set; }
        /// <summary>
        /// Establece el estatus de uso para este usuario dentro de la aplicación.
        /// </summary>
        public int estatus { get; set; }
        /// <summary>
        /// Contraseña usada (en hash) para el uso dentro de la plataforma.
        /// </summary>
        public string contrasena { get; set; }
        /// <summary>
        /// Identificador único que establece el tipo de usuario que categoriza a dicho usuario.
        /// </summary>
        public int idTipoUsuario { get; set; }

        public ComUsuario()
        {

        }

        /// <summary>
        /// Constructor con objetivo de simplificar el llenado para la asignación de un banco a través de un método específico.
        /// </summary>
        /// <param name="Comercio">Establece los datos de comercio para el uso de registro de usuario.</param>
        /// <param name="Persona">Establece los datos de Persona para el uso de registro de usuario.</param>
        /// <param name="TipoIdentificacion">Establece el tipo de identificación usado para el usuario.</param>
        /// <param name="IdUsuario">Identificador único del usuario.</param>
        /// <param name="IdEntity">Establece el identificador único para el framework de autenticación.</param>
        /// <param name="Usuario">Establece el nombre de usuario utilizado para la aplicación.</param>
        /// <param name="FechaRegistro">Establece la fecha de registro de dicho usuario dentro de la lógica.</param>
        /// <param name="NroIdentificacion">Establece el número de identificación legal para el usuario dentro de la aplicación</param>
        /// <param name="Email">Establece el correo electrónico relacionado con el usuario.</param>
        /// <param name="Telefono">Establece el número telefónico usado por el usuario.</param>
        /// <param name="Direccion">Establece la dirección de ubicación o localización del usuario.</param>
        /// <param name="Estatus">Estatus de uso dentro de la aplicación por parte del usuario</param>
        /// <param name="Contrasena">Establece la contraseña (Hash) del usuario dentro de la aplicación</param>
        public ComUsuario(ComComercio Comercio, ComPersona Persona, ComTipoIdentificacion TipoIdentificacion, int IdUsuario, string IdEntity, string Usuario,
                            NpgsqlDate FechaRegistro, int NroIdentificacion, string Email, string Telefono, string Direccion, int Estatus, string Contrasena)
        {
            this.comercio = Comercio;
            this.persona = Persona;
            this.idUsuario = IdUsuario;
            this.idEntity = IdEntity;
            this.usuario = Usuario;
            this.fechaRegistro = FechaRegistro;
            this.nroIdentificacion = NroIdentificacion;
            this.email = Email;
            this.telefono = Telefono;
            this.direccion = Direccion;
            this.estatus = 1;
            this.tipoIdentificacion = TipoIdentificacion;
            this.idTipoUsuario = 1;
            this.contrasena = Contrasena;
        }

        public void LlenadoDataFormPersona(NpgsqlCommand ComandoSQL)
        {
            //ComandoSQL.Parameters.Add(new NpgsqlParameter("EntityId", this._idEntity));
            ComandoSQL.Parameters.Add(new NpgsqlParameter("TipoUsuarioId", this.idTipoUsuario));
            ComandoSQL.Parameters.Add(new NpgsqlParameter("TipoIdentificacionId", this.tipoIdentificacion.idTipoIdentificacion));
            ComandoSQL.Parameters.Add(new NpgsqlParameter("Usuario", this.usuario));
            ComandoSQL.Parameters.Add(new NpgsqlParameter("FechaRegistro", this.fechaRegistro));
            ComandoSQL.Parameters.Add(new NpgsqlParameter("NroIdentificacion", this.nroIdentificacion));
            ComandoSQL.Parameters.Add(new NpgsqlParameter("Email", this.email));
            ComandoSQL.Parameters.Add(new NpgsqlParameter("Telefono", this.telefono));
            ComandoSQL.Parameters.Add(new NpgsqlParameter("Direccion", this.direccion));
            ComandoSQL.Parameters.Add(new NpgsqlParameter("TipoSol", 'P'));
            ComandoSQL.Parameters.Add(new NpgsqlParameter("Contrasena", this.contrasena));
            ComandoSQL.Parameters.Add(new NpgsqlParameter("Estatus", this.estatus));
            this.persona.LlenadoDataFormPersona(ComandoSQL);
        }

        public void LlenadoDataFormComercio(NpgsqlCommand ComandoSQL)
        {
            //ComandoSQL.Parameters.Add(new NpgsqlParameter("EntityId", this._idEntity));
            ComandoSQL.Parameters.Add(new NpgsqlParameter("TipoUsuarioId", this.idTipoUsuario));
            ComandoSQL.Parameters.Add(new NpgsqlParameter("TipoIdentificacionId", this.tipoIdentificacion.idTipoIdentificacion));
            ComandoSQL.Parameters.Add(new NpgsqlParameter("Usuario", this.usuario));
            ComandoSQL.Parameters.Add(new NpgsqlParameter("FechaRegistro", this.fechaRegistro));
            ComandoSQL.Parameters.Add(new NpgsqlParameter("NroIdentificacion", this.nroIdentificacion));
            ComandoSQL.Parameters.Add(new NpgsqlParameter("Email", this.email));
            ComandoSQL.Parameters.Add(new NpgsqlParameter("Telefono", this.telefono));
            ComandoSQL.Parameters.Add(new NpgsqlParameter("Direccion", this.direccion));
            ComandoSQL.Parameters.Add(new NpgsqlParameter("Estatus", this.estatus));
            ComandoSQL.Parameters.Add(new NpgsqlParameter("TipoSol", 'C'));
            ComandoSQL.Parameters.Add(new NpgsqlParameter("Contrasena", this.contrasena));
            this.comercio.LlenadoDataFormComercio(ComandoSQL);
        }

        public void LlenadoDataNpgsql(NpgsqlDataReader Data)
        {
            this.comercio.offset = 17;
            this.comercio.LlenadoDataNpgsql(Data);
            this.persona.offset = 13;
            this.persona.LlenadoDataNpgsql(Data);
            this.idUsuario = Data.GetInt32(0 + offset);
            this.idEntity = Data.GetString(3 + offset);
            this.usuario = Data.GetString(4 + offset);
            this.fechaRegistro = Data.GetDate(5 + offset);
            this.nroIdentificacion = Data.GetInt32(6 + offset);
            this.email = Data.GetString(7 + offset);
            this.telefono = Data.GetString(8 + offset);
            this.direccion = Data.GetString(9 + offset);
            this.estatus = Data.GetInt32(10 + offset);
            this.tipoIdentificacion.offset = 20;
            this.tipoIdentificacion.LlenadoDataNpgsql(Data);
        }
    }
}
