namespace Excepciones.Excepciones_Especificas
{
    /// <summary>
    /// Excepción personalizada respecto a la autenticación dentro de una app, establece la difernecia de login entre las aplicaciones y la categorización de usuario: comercio y persona.
    /// </summary>
    public class AutenticacionAppException : MoneyUcabException
    {
        /// <summary>
        /// Método predeterminado para arrojar una excepción definida de este tipo.
        /// </summary>
        public static void UsuarioInvalidoApp()
        {
            AutenticacionAppException exception = new AutenticacionAppException();
            exception.codigo = 50;
            exception.error = "El usuario no está autenticado en una aplicación la cual no tiene acceso";
            throw exception;
        }
    }
}
