using Npgsql;

namespace Comunes.Comun
{
    /// <summary>
    /// Interfaz que define el llenado de formulario para ejecutarse en el método de petición a base de datos.
    /// </summary>
    public interface IFormularioInsert
    {
        /// <summary>
        /// Se realiza un llenado de los parámetros para la petición de base de datos según una entidad específica.
        /// </summary>
        /// <param name="ComandoSQL">Establece el medio por el cual se ejecutará una petición a base de datos.</param>
        /// <exception cref="PGSQLException">Tira excepción relacionado a la base de datos.</exception>
        /// <exception cref="MoneyUcabException">Tira excepción relacionado a lógica de negocio que se esté manejando en este punto.</exception>
        /// <exception cref="Exception">Exception para controlar cualquier error inesperado y no controlado por el backend.</exception>
        void LlenadoDataForm(NpgsqlCommand ComandoSQL);

    }
}
