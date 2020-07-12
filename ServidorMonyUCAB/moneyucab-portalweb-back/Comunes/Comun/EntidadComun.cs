namespace Comunes.Comun
{
    /// <summary>
    /// Clase abstracta de Entidad Común, sirve como medio por el cual se controla la información sobre esta entidad en toda la aplicación.
    /// Esto permite además servir como un formulario de datos para la ejecución de diferntes métodos DAO, 
    /// definiendo de forma estandarizada los atributos que deberían tener todas las entidades para un funcionamiento lógico.
    /// </summary>
    public abstract class EntidadComun
    {
        /// <summary>
        /// Átributo que tiene como función definir un puntero virtual en la posición de la cual la entidad puede extraer los datos de un orden específico sobre un método del DAO.
        /// </summary>
        public int offset = 0;

        public EntidadComun()
        {

        }

    }
}
