namespace Excepciones.Excepciones_Especificas
{
    /// <summary>
    /// Establece la excepción personalizada que establece la lógica de la existencia del usuario dentro de la aplicación.
    /// </summary>
    public class UsuarioExistenteException : MoneyUcabException
    {
        /// <summary>
        /// Arroja la excepción de la inexistencia del usuario en base de datos como un formato predeterminado.
        /// </summary>
        public static void UsuarioNoExistente()
        {
            UsuarioExistenteException exception = new UsuarioExistenteException();
            exception.codigo = 11;
            exception.error = "El usuario no existe en el sistema";
            throw exception;
        }

        /// <summary>
        /// Arroja la excepción de la inexistencia del usuario en base de datos como un formato predeterminado.
        /// </summary>
        public static void UsuarioExistente()
        {
            UsuarioExistenteException exception = new UsuarioExistenteException();
            exception.codigo = 17;
            exception.error = "El usuario existe en el sistema";
            throw exception;
        }
    }
}
