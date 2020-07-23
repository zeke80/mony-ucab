using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebasUnitarias.Modelos
{
    class RespuestaLogin
    {
        string key;
        string message;
        resp result;

        public string Key { get => key; set => key = value; }
        public string Message { get => message; set => message = value; }
        internal resp Result { get => result; set => result = value; }
    }
}
