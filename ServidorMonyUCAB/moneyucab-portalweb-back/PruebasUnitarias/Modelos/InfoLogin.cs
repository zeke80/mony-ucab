using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebasUnitarias.Modelos
{
    class InfoLogin
    {
        string userName;
        string email;
        string password;
        bool comercio;

        public string UserName { get => userName; set => userName = value; }
        public string Email { get => email; set => email = value; }
        public string Password { get => password; set => password = value; }
        public bool Comercio { get => comercio; set => comercio = value; }
    }
}
