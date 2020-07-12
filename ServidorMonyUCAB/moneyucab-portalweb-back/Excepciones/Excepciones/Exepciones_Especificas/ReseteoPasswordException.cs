namespace Excepciones.Excepciones_Especificas
{
    /// <summary>
    /// Excepción personalizada para capturar cualquier problemática que tenga que ver con la lógica del reseteo de contraseña.
    /// </summary>
    public class ReseteoPasswordException : MoneyUcabException
    {
        /// <summary>
        /// Establece el método para formatear el error de Reseteo de Password Fallido arrojando la excepción personalizada.
        /// </summary>
        public static void ReseteoPasswordFallido()
        {
            ReseteoPasswordException exception = new ReseteoPasswordException();
            exception.codigo = 14;
            exception.error = "El password no se logró realizar el reseteo.";
            throw exception;
        }
    }
}
