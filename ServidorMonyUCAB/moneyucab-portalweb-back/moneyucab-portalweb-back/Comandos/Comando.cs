using moneyucab_portalweb_back.Comandos;
using System.Threading.Tasks;

namespace Comandos
{
    public abstract class Comando<TSalida> : IComando<TSalida>
    {
        /// <summary>
        /// Metood que ejecuta la accion del comando
        /// </summary>
        /// <returns></returns>
        public Task<TSalida> Ejecutar()
        {
            throw new System.NotImplementedException();
        }
    }
}
