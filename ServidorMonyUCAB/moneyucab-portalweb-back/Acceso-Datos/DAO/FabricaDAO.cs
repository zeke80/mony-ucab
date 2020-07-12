namespace DAO
{
    /// <summary>
    /// Class <c>FabricaDAO</c>
    /// Establece el medio de acción para realizar una creación específica de la implementación de acceso a datos sea por distintos sistemas.
    /// La aplicación del patrón Fábrica nos permita asegurarnos crear una instancia únicamente para una ejecución determinada o para la realización de determinadas tareas únicamente en un scope determinado.
    /// </summary>
    public class FabricaDAO
    {

        /// <summary>
        /// Establece la creación y la fabricación de la instanciación de un acceso a datos por la base de datos, siendo el DAOPsql de acceso a PostgreSQL.
        /// </summary>
        /// <returns>Retorna una instanciación de la clase DAOPsql</returns>
        public static DAOPsql CrearDaoPsql()
        {
            return new DAOPsql();
        }

        /// <summary>
        /// Establece la creación y la fabricación de la instanciación de un acceso a datos por la base de datos, siendo el DAOBase de acceso a PostgreSQL que herda directamente de DAOPsql.
        /// </summary>
        /// <returns>Retorna una instanciación de la clase DAOBase</returns>
        public static DAOBase CrearDaoBase()
        {
            return new DAOBase();
        }
    }
}
