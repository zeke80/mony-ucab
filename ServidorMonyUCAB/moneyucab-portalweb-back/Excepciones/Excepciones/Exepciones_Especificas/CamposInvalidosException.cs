namespace Excepciones.Excepciones_Especificas
{
    /// <summary>
    /// Especificación de los errores que puedan surgir por un formato inválido en uno de los campos en el formulario.
    /// </summary>
    public class CamposInvalidosException : MoneyUcabException
    {
        /// <summary>
        /// Establece el error, pudiendo controlando la forma en que se expresa.
        /// </summary>
        /// <param name="Campo">Establece el campo el cual ocurrió el error.</param>
        public static void CamposInvalidos(string Campo)
        {
            CamposInvalidosException exception = new CamposInvalidosException();
            exception.codigo = 8;
            exception.error = "Campo invalido en el formulario: " + Campo + ".";
            throw exception;
        }
    }
}
