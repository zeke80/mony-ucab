using Excepciones;
using Npgsql;
using System;

namespace DAO
{
    /// <summary>
    /// Class <c>DAOPsql</c>
    /// Establece la estructura y el medio para poder actuar y conectarse con la base de datos para poder manejar información necesario para el sistema.
    /// Contiene todos los atributos necesarios para su buena operatividad.
    /// </summary>
    public class DAOPsql
    {
        /// <summary>
        /// Establece la conexión con la base de datos.
        /// </summary>
        private Npgsql.NpgsqlConnection _conector;

        /// <summary>
        /// Establece el dato y el medio por el cuaal se conforma la conexión de la base de datos.
        /// </summary>
        private string _stringConexion;

        /// <summary>
        /// Establece el medio de comandos query contra la base de datos.
        /// </summary>
        private NpgsqlCommand _comandoSQL;

        /// <summary>
        /// Establece el medio lector para todas las respuestas que de la base de datos dentro del sistema.
        /// </summary>
        private NpgsqlDataReader _lectorTablaSQL;

        public NpgsqlConnection conector
        {
            get { return _conector; }
            set { _conector = value; }
        }

        public string stringConexion
        {
            get { return _stringConexion; }
            set { _stringConexion = value; }
        }

        public NpgsqlCommand comandoSQL
        {
            get { return _comandoSQL; }
            set { _comandoSQL = value; }
        }

        public NpgsqlDataReader lectorTablaSQL
        {
            get { return _lectorTablaSQL; }
            set { _lectorTablaSQL = value; }
        }

        /// <summary>
        /// Establece el método para realizar la apertura de conexión contra la base de datos.
        /// </summary>
        public void Conectar()
        {

            try
            {
                conector = new NpgsqlConnection(stringConexion);
                conector.Open();
            }
            catch (NpgsqlException ex)
            {
                throw new Exception();
            }
            catch (Exception ex)
            {
                throw new MoneyUcabException(ex);
            }

        }

        /// <summary>
        /// Establece el método par realizar la clausura de conexión contra la base de datos.
        /// </summary>
        public void Desconectar()
        {
            if (conector != null)
            {
                conector.Close();
                conector.Dispose();
            }
        }


    }
}
