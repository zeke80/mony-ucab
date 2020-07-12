using System;

namespace Excepciones.Excepciones_Especificas
{
    /// <summary>
    /// Excepción personalizada indicando la falla de bloqueo de usuario dentro de la aplicación, relacionada directamente con Entity.
    /// </summary>
    public class UsuarioBloqueadoException : MoneyUcabException
    {
        /// <summary>
        /// Arroja la excepción estableciendo que el usuario fue bloqueado dentro de la aplicación.
        /// </summary>
        /// <param name="Date">Establece la fecha desde la cual fue bloqueado.</param>
        public static void UsuarioBloqueado(DateTimeOffset Date)
        {
            UsuarioBloqueadoException exception = new UsuarioBloqueadoException();
            exception.codigo = 12;
            exception.error = "El usuario se encuentra bloqueado desde la fecha: " + Date.ToString();
            throw exception;
        }

        /// <summary>
        /// Arroja la excepción estableciendo que fue intento fallido al intentar realizar la autenticación.
        /// </summary>
        /// <param name="IntentosRestantes">Establece el número de intentos restantes que tiene el usuario para intentar autenticarse.</param>
        public static void IntentoFallido(int IntentosRestantes)
        {
            UsuarioBloqueadoException exception = new UsuarioBloqueadoException();
            exception.codigo = 13;
            exception.error = "El usuario falló en el intento de realizar login, tiene " + IntentosRestantes + " intentos restantes.";
            throw exception;
        }
    }
}
