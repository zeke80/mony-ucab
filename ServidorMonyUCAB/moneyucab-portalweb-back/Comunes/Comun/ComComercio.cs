using Excepciones;
using Npgsql;
using System;

namespace Comunes.Comun
{
    /// <summary>
    /// Entidad común Comercio vinculado directamente a la entidad de base de datos para manipulación de formularios y acciones particulares del mismo.
    /// </summary>
    public class ComComercio : EntidadComun, IEntidadComun, IFormularioRegistro
    {
        /// <summary>
        /// Nombre del comercio al cual se está vinculando al usuario.
        /// </summary>
        public string razonSocial { get; set; }
        /// <summary>
        /// Nombre del representante del comercio vinculado al usuario.
        /// </summary>
        public string nombreRepresentante { get; set; }
        /// <summary>
        /// Apellido del representante del comercio vinculado al usuario.
        /// </summary>
        public string apellidoRepresentante { get; set; }

        public ComComercio()
        {

        }

        /// <summary>
        /// Constructor con objetivo de simplificar el llenado para la asignación de un banco a traés de un método específico.
        /// </summary>
        /// <param name="RazonSocial">Nombre del comercio al cual se está vinculando al usuario.</param>
        /// <param name="NombreRepresentante">Nombre del representante del comercio vinculado al usuario.</param>
        /// <param name="ApellidoRepresentante">Apellido del representante del comercio vinculado al usuario.</param>
        public ComComercio(string RazonSocial, string NombreRepresentante, string ApellidoRepresentante)
        {
            this.razonSocial = RazonSocial;
            this.nombreRepresentante = NombreRepresentante;
            this.apellidoRepresentante = ApellidoRepresentante;
        }

        public void LlenadoDataFormComercio(NpgsqlCommand ComandoSQL)
        {
            ComandoSQL.Parameters.Add(new NpgsqlParameter("RazonSocial", this.razonSocial));
            ComandoSQL.Parameters.Add(new NpgsqlParameter("Nombre", this.nombreRepresentante));
            ComandoSQL.Parameters.Add(new NpgsqlParameter("Apellido", this.apellidoRepresentante));
            ComandoSQL.Parameters.Add(new NpgsqlParameter("FechaNacimiento", new NpgsqlTypes.NpgsqlDate(2020, 5, 30)));
            ComandoSQL.Parameters.Add(new NpgsqlParameter("IdEstadoCivil", 1));
        }

        public void LlenadoDataFormComercioReg(NpgsqlCommand ComandoSQL)
        {
            ComandoSQL.Parameters.Add(new NpgsqlParameter("RazonSocial", this.razonSocial));
            ComandoSQL.Parameters.Add(new NpgsqlParameter("Nombre", this.nombreRepresentante));
            ComandoSQL.Parameters.Add(new NpgsqlParameter("Apellido", this.apellidoRepresentante));
        }

        public void LlenadoDataFormPersona(NpgsqlCommand ComandoSQL)
        {
            throw new MoneyUcabException(null, "Llenado de información inválido", 100);
        }

        public void LlenadoDataNpgsql(NpgsqlDataReader Data)
        {
            try
            {
                this.razonSocial = Data.GetString(0 + offset);
            }
            catch (InvalidCastException ex) 
            {
                this.razonSocial = "";
            }
            try 
            {
                this.nombreRepresentante = Data.GetString(1 + offset);
            }
            catch (InvalidCastException ex)
            {
                this.nombreRepresentante = "";
            }
            try
            {
                this.apellidoRepresentante = Data.GetString(2 + offset);
            }
            catch (InvalidCastException ex)
            {
                this.apellidoRepresentante = "";
            }
        }
    }
}
