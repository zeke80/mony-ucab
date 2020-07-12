
using System.Threading.Tasks;

namespace moneyucab_portalweb_back.Comandos
{
    public interface IComando<TSalida>
    {
        /// <summary>
        /// Es el método que establece el comportamiento que se va a realizar dentro de la aplicación. De esta forma se encapsula la lógica de ciertas acciones en una sola ejecución de una sola clase.
        /// </summary>
        /// <returns>Retorna el valor especifico según la lógica del comando que se está ejecutando</returns>
        Task<TSalida> Ejecutar();
    }
}
