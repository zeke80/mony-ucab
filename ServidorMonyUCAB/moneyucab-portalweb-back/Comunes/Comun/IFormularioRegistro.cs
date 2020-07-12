using Npgsql;

namespace Comunes.Comun
{
    /// <summary>
    /// Interfaz únicamente con implementación para los registros de usuario, definiéndola según su condición de registro: comercio o persona.
    /// </summary>
    public interface IFormularioRegistro
    {
        /// <summary>
        /// Se realiza un llenado de los parámetros para la petición de base de datos según una entidad específica en este caso sobre registro de un usuario comercio.
        /// </summary>
        /// <param name="ComandoSQL">Establece el medio por el cual se ejecutará una petición a base de datos.</param>
        /// <exception cref="PGSQLException">Tira excepción relacionado a la base de datos.</exception>
        /// <exception cref="MoneyUcabException">Tira excepción relacionado a lógica de negocio que se esté manejando en este punto.</exception>
        /// <exception cref="Exception">Exception para controlar cualquier error inesperado y no controlado por el backend.</exception>
        void LlenadoDataFormPersona(NpgsqlCommand ComandoSQL);
        /// <summary>
        /// Se realiza un llenado de los parámetros para la petición de base de datos según una entidad específica en este caso sobre registro de un usuario comercio.
        /// </summary>
        /// <param name="ComandoSQL">Establece el medio por el cual se ejecutará una petición a base de datos.</param>
        /// <exception cref="PGSQLException">Tira excepción relacionado a la base de datos.</exception>
        /// <exception cref="MoneyUcabException">Tira excepción relacionado a lógica de negocio que se esté manejando en este punto.</exception>
        /// <exception cref="Exception">Exception para controlar cualquier error inesperado y no controlado por el backend.</exception>
        void LlenadoDataFormComercio(NpgsqlCommand ComandoSQL);

    }
}
