using System;
using System.Runtime.CompilerServices;

namespace Excepciones
{
    /// <summary>
    /// Establece el medio por el cual se establecen todos los posibles errores de lógica dentro de la API.
    /// </summary>
    public class MoneyUcabException : Exception
    {
        /// <summary>
        /// Establece la descripción de dicho error identificado
        /// </summary>
        protected string _error;
        /// <summary>
        /// Código que identifica el error determinado según los estándares dentro de la lógica de negocio.
        /// </summary>
        protected int _codigo;
        /// <summary>
        /// Al ser este un medio personalizado de captura de errores, la excepción de origen define desde que punto se obtuve un error que representó una problemática para la lógica del negocio.
        /// </summary>
        protected Exception _excepcionOrigen;

        /// <summary>
        /// Constructor predeterminado para asignar el encuentro de una excepción y ser controlado como lógica de negocio.
        /// </summary>
        /// <param name="Ex">Establece la excepción desconocida dentro de la lógica y que representa una problemática a nivel del servidor.</param>
        public MoneyUcabException(Exception Ex)
        {
            this.excepcionOrigen = Ex;
            this.error = Ex.Message;
            this.codigo = 404;
        }

        /// <summary>
        /// Constructor predeterminado para asignar el encuentro de una excepción y ser controlado como lógica de negocio.
        /// </summary>
        /// <param name="Error">Establece la descripción del error para una construcción sencilla y rápida.</param>
        /// <param name="Codigo">Establece el código que identifica de forma única el error dentro de la lógica.</param>
        public MoneyUcabException(string Error, int Codigo)
        {
            this.error = Error;
            this.codigo = Codigo;
        }

        public MoneyUcabException(Exception Ex, string Error, int Codigo)
        {
            this.excepcionOrigen = Ex;
            this.error = Error;
            this.codigo = Codigo;
        }

        public string error
        {
            get { return _error; }
            set { _error = value; }
        }

        public int codigo
        {
            get { return _codigo; }
            set { _codigo = value; }
        }

        public MoneyUcabException() { }

        public Exception excepcionOrigen
        {
            get { return _excepcionOrigen; }
            set { _excepcionOrigen = value; }
        }

        /// <summary>
        /// Establece el método para realizar una construcción de un objeto como respuesta al obtener un error dentro de la aplicación.
        /// </summary>
        public Object Response()
        {
            return new { error = this.error, codigo = this.codigo };
        }

        /// <summary>
        /// Acción que determina un error desconocido dentro de la aplicación y por lo tanto no es controlado.
        /// </summary>
        /// <param name="Ex">Establece la excepción desconocida dentro de la lógica y que representa una problemática a nivel del servidor.</param>
        public static Object ResponseErrorDesconocido(Exception Ex)
        {
            var stackTrace = new { stackTrace = Ex.StackTrace };
            return new { error = "Error desconocido. Comunicarse con el administrador e informar.", codigo = 0 , stackTrace};
        }
    }
}
