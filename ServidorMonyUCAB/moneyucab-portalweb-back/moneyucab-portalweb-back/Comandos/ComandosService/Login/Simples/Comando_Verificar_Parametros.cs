using Comandos;
using Excepciones.Excepciones_Especificas;
using System;
using System.Threading.Tasks;

namespace moneyucab_portalweb_back.Comandos.ComandosService.Login.Simples
{
    public class Comando_Verificar_Parametros : Comando<Object>
    {

        private string[] _parametros;

        public Comando_Verificar_Parametros(params string[] Parametros)
        {
            this._parametros = Parametros;
        }


        async public Task<Object> Ejecutar()
        {
            for (int i = 0; i < _parametros.Length; i++)
            {
                if (string.IsNullOrWhiteSpace(_parametros[i]))
                {
                    CamposInvalidosException.CamposInvalidos(_parametros[i]);
                }
            }
            return null;
        }

    }
}
