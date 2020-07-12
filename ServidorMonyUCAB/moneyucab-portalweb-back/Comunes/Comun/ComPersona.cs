using Excepciones;
using Npgsql;
using NpgsqlTypes;

namespace Comunes.Comun
{
    /// <summary>
    /// Entidad común que establece la identificación e información de una persona dentro de la aplicación.
    /// </summary>
    public class ComPersona : EntidadComun, IEntidadComun, IFormularioRegistro
    {
        /// <summary>
        /// Establece el estado civil de la persona.
        /// </summary>
        public ComEstadoCivil estadoCivil = new ComEstadoCivil();
        /// <summary>
        /// Establece el nombre de la persona como identificación dentro de la aplicación.
        /// </summary>
        public string nombre { get; set; }
        /// <summary>
        /// Entidad común Estado civil que establece el apellido de identificación para la persona.
        /// </summary>
        public string apellido { get; set; }
        /// <summary>
        /// Establece la fecha de nacimiento de dicha persona.
        /// </summary>
        public NpgsqlDate fechaNacimiento { get; set; }

        public ComPersona()
        {

        }

        /// <summary>
        /// Constructor con objetivo de simplificar el llenado para la asignación de un banco a través de un método específico.
        /// </summary>
        /// <param name="EstadoCivil">Establece el estado civil de la persona.</param>
        /// <param name="Nombre">Establece el nombre de la persona como identificación.</param>
        /// <param name="Apellido">Establece el apellido de la persona como identificación.</param>
        /// <param name="FechaNacimiento">Establece la fecha de nacimiento de dicha persona</param>
        public ComPersona(ComEstadoCivil EstadoCivil, string Nombre, string Apellido, NpgsqlDate FechaNacimiento)
        {
            this.estadoCivil = EstadoCivil;
            this.nombre = Nombre;
            this.apellido = Apellido;
            this.fechaNacimiento = FechaNacimiento;
        }

        public void LlenadoDataFormComercio(NpgsqlCommand ComandoSQL)
        {
            throw new MoneyUcabException(null, "Llenado de información inválido", 100);
        }

        public void LlenadoDataFormPersona(NpgsqlCommand ComandoSQL)
        {
            ComandoSQL.Parameters.Add(new NpgsqlParameter("Nombre", this.nombre));
            ComandoSQL.Parameters.Add(new NpgsqlParameter("Apellido", this.apellido));
            ComandoSQL.Parameters.Add(new NpgsqlParameter("FechaNacimiento", this.fechaNacimiento));
            ComandoSQL.Parameters.Add(new NpgsqlParameter("IdEstadoCivil", this.estadoCivil.idEstadoCivil));
            ComandoSQL.Parameters.Add(new NpgsqlParameter("RazonSocial", ""));
        }

        public void LlenadoDataNpgsql(NpgsqlDataReader Data)
        {
            this.nombre = Data.GetString(0 + offset);
            this.apellido = Data.GetString(1 + offset);
            this.fechaNacimiento = Data.GetDate(2 + offset);
            this.estadoCivil.offset = 24;
            this.estadoCivil.LlenadoDataNpgsql(Data);
        }
    }
}
