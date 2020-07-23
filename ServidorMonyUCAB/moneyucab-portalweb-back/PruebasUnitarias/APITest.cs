using Newtonsoft.Json;
using PruebasUnitarias.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PruebasUnitarias
{
    static class APITest
    {
        static HttpClient client = new HttpClient();
        static string url = "http://monyucab.somee.com";
        static string token;

        public static async Task<HttpResponseMessage> register(Persona persona)
        {
            var json = JsonConvert.SerializeObject(persona);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            return await client.PostAsync(url + "/api/authentication/register", data);
        }
    }
}
