using Npgsql;

namespace Comunes.Comun
{
    /// <summary>
    /// Interfaz que establece el llenado de datos comunes para las entidades dentro de la aplicación.
    /// </summary>
    public interface IEntidadComun
    {
        /// <summary>
        /// Establece el llenado de datos a un entidad a partir de un reader.
        /// </summary>
        /// <param name="Data">Especifica el nombre del medio por el cual se realizará la extracción de datos, especificado como un Reader</param>
        /// <exception cref="PGSQLException">Tira excepción relacionado a la base de datos.</exception>
        /// <exception cref="MoneyUcabException">Tira excepción relacionado a lógica de negocio que se esté manejando en este punto.</exception>
        /// <exception cref="Exception">Exception para controlar cualquier error inesperado y no controlado por el backend.</exception>
        void LlenadoDataNpgsql(NpgsqlDataReader Data);

    }
}
