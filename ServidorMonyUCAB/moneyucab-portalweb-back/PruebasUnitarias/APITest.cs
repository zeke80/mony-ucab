using Newtonsoft.Json;
using PruebasUnitarias.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace PruebasUnitarias
{
    static class APITest
    {
        static HttpClient client = new HttpClient();
        static string url = "http://monyucab.somee.com";
        static string token;

        public static StringContent serializarObjetoJson(object objeto)
        {
            var json = JsonConvert.SerializeObject(objeto);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            return data;
        }

        //Admin//

        /*public static async Task<HttpResponseMessage> ConsultaUsuarios(Persona persona)
        {
            var data = serializarObjetoJson(persona);
            return await client.PostAsync(url + "/api/Admin/ConsultaUsuarios", data);
        }*/

        public static async Task<HttpResponseMessage> EliminarUsuario(int idUsuario)
        {
            return await client.PostAsync(url + "/api/Admin/EliminarUsuario?idUsuario=" + idUsuario, null);
        }

        //Authentication//

        public static async Task<HttpResponseMessage> register(Persona persona)
        {
            var data = serializarObjetoJson(persona);
            return await client.PostAsync(url + "/api/authentication/register", data);
        }

        /*public static async Task<HttpResponseMessage> login()
        {
            Login login = new Login() {
                UserName = "ezez8",
                Email = "ezequielmonteroz8@gmail.com",
                Password = "weawística",
                Comercio = false
            };
            var json = JsonConvert.SerializeObject(login);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage res = await client.PostAsync(url + "/api/authentication/login", data);
            var respuesta = JsonConvert.DeserializeObject<RespuestaLogin>(res.Content.ReadAsStringAsync().Result);
            token = respuesta.Key;
            return res;
        }*/

        //Billetera//

        //Dashboard//

        //Historial Operaciones//

        //Monedero//

        //Transfer//
















        /* Inicio de consultas get complejas  */
        /*public static async Task<HttpResponseMessage> getTarjetas(int id)
        {
            await login();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            return await client.GetAsync(url + "/api/dashboard/Tarjetas?IdUsuario=" + id);
        }

        public static async Task<HttpResponseMessage> getCuentas(int id)
        {
            return await client.GetAsync(url + "/api/dashboard/Cuentas?IdUsuario=" + id);
        }

        public static async Task<HttpResponseMessage> getReintegrosActivos(int idUsuario, int idSolicitante)
        {
            return await client.GetAsync(url + "/api/dashboard/ReintegrosActivos?IdUsuario="+ idUsuario +"&solicitante=" + idSolicitante);
        }

        public static async Task<HttpResponseMessage> getReintegrosCancelados(int idUsuario, int idSolicitante)
        {
            return await client.GetAsync(url + "/api/dashboard/ReintegrosCancelados?UsuarioId="+ idUsuario +"&solicitante="+ idSolicitante);
        }

        public static async Task<HttpResponseMessage> getReintegrosExitosos(int idUsuario, int idSolicitante)
        {
            return await client.GetAsync(url + "/api/dashboard/ReintegrosExitosos?UsuarioId=" + idUsuario + "&solicitante=" + idSolicitante);
        }

        public static async Task<HttpResponseMessage> getCobrosActivos(int idUsuario, int idSolicitante)
        {
            return await client.GetAsync(url + "/api/dashboard/CobrosActivos?IdUsuario=" + idUsuario + "&solicitante=" + idSolicitante);
        }

        public static async Task<HttpResponseMessage> getCobrosCancelados(int idUsuario, int idSolicitante)
        {
            return await client.GetAsync(url + "/api/dashboard/CobrosCancelados?UsuarioId=" + idUsuario + "&solicitante=" + idSolicitante);
        }

        public static async Task<HttpResponseMessage> getCobrosExitosos(int idUsuario, int idSolicitante)
        {
            return await client.GetAsync(url + "/api/dashboard/CobrosExitosos?UsuarioId=" + idUsuario + "&solicitante=" + idSolicitante);
        }*/

        /*error en peticion ParametrosUsuarios*/

        /*public static async Task<HttpResponseMessage> getInformacionPersona(string user)
        {
            return await client.GetAsync(url + "/api/dashboard/InformacionPersona?Usuario=" + user);
        }

        public static async Task<HttpResponseMessage> getHistorialOperacionTarjeta(int id)
        {
            return await client.GetAsync(url + "/api/HistorialOperaciones/HistorialOperacionesTarjeta?TarjetaId=" + id);
        }

        public static async Task<HttpResponseMessage> getHistorialOperacionCuenta(int id)
        {
            return await client.GetAsync(url + "/api/HistorialOperaciones/HistorialOperacionesCuenta?CuentaId=" + id);
        }

        public static async Task<HttpResponseMessage> getHistorialOperacionMonedero(int id)
        {
            return await client.GetAsync(url + "/api/HistorialOperaciones/HistorialOperacionesMonedero?UsuarioId=" + id);
        }

        public static async Task<HttpResponseMessage> getEjecutarCierre(int id)
        {
            return await client.GetAsync(url + "/api/HistorialOperaciones/EjecutarCierre?IdUsuario=" + id);
        }

        public static async Task<HttpResponseMessage> getSaldo(int id)
        {
            return await client.GetAsync(url + "/api/monedero/Consultar?idusuario=" + id);
        }*/
    }
}
