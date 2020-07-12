using Npgsql;

namespace Excepciones.Excepciones_Especificas
{
    /// <summary>
    /// Excepción de control semi-personalizada para definir los errores de base de datos como parte de la lógica de negocio. Aunque puede capturar errores técnicos de construcción BDD se incluyen en la lógica.
    /// </summary>
    public class PGSQLException : MoneyUcabException
    {
        /// <summary>
        /// Se procesa la excepción desconocida por parte de la Base de datos para traducirla en la lógica de negocio y dar una respuesta a la falla.
        /// </summary>
        /// <param name="Ex">Establece la excepción de captura sobre los posibles errores que se capturen de PostgreSQL</param>
        public static void ProcesamientoException(NpgsqlException ex)
        {
            PGSQLException exception = new PGSQLException();
            exception.codigo = ex.ErrorCode;
            exception.error = ex.Message;
            exception.excepcionOrigen = ex;
            throw exception;
        }
    }
}
