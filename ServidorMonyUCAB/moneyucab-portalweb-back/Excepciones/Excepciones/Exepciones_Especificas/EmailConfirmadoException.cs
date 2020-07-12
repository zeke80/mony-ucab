namespace Excepciones.Excepciones_Especificas
{
    /// <summary>
    /// Exepción personalizada que captura los posibles errores que tengan que ver con la lógica de confirmación de un email.
    /// </summary>
    public class EmailConfirmadoException : MoneyUcabException
    {
        /// <summary>
        /// Arroja una excepción cuando el email está confirmado por parte del usuario.
        /// </summary>
        public static void EmailConfirmado()
        {
            EmailConfirmadoException exception = new EmailConfirmadoException();
            exception.codigo = 9;
            exception.error = "El usuario especificado ya tiene el email confirmado.";
            throw exception;
        }

        /// <summary>
        /// Arroja una excepción cuando ocurrió un fallo al enviar el correo electrónico de confirmación.
        /// </summary>
        public static void EmailFalloEnvioConfirmacion()
        {
            EmailConfirmadoException exception = new EmailConfirmadoException();
            exception.codigo = 10;
            exception.error = "Ocurrió un problema al intentar enviar el correo de confirmación.";
            throw exception;
        }

        /// <summary>
        /// Arroja una excepción cuando el correo electrónico no está confirmado.
        /// </summary>
        public static void EmailNoConfirmado()
        {
            EmailConfirmadoException exception = new EmailConfirmadoException();
            exception.codigo = 16;
            exception.error = "El usuario no tiene el email confirmado.";
            throw exception;
        }
    }
}
