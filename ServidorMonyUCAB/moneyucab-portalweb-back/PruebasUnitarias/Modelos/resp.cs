using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebasUnitarias.Modelos
{
    class resp
    {
        string token;
        string userID;
        string username;
        string email;

        public string Token { get => token; set => token = value; }
        public string Userid { get => userID; set => userID = value; }
        public string Username { get => username; set => username = value; }
        public string Email { get => email; set => email = value; }
    }
}
