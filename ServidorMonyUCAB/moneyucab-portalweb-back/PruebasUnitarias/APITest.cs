using Newtonsoft.Json;
using PruebasUnitarias.Modelos;
using System;
using System.Collections.Generic;
using System.Dynamic;
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
        static Login loginTestUser = new Login
        {
            UserName = "TestUser",
            Email = "testuser@gmail.com",
            Password = "passtestuser",
            Comercio = false,
        };
        static Task<string> token = getToken();

        public async static Task<string> getToken()
        {
            var data = serializarObjetoJson(loginTestUser);
            HttpResponseMessage res = await client.PostAsync(url + "/api/authentication/login", data);

            dynamic respuesta = JsonConvert.DeserializeObject(res.Content.ReadAsStringAsync().Result);
            string token = respuesta.result.token;
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            return token;
        }

        public static StringContent serializarObjetoJson(object objeto)
        {
            var json = JsonConvert.SerializeObject(objeto);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            return data;
        }

        //Admin//

        /*public static async Task<HttpResponseMessage> ConsultaUsuarios(Persona persona, Login loginAdmin1)
        {
            await login(loginAdmin1);
            var data = serializarObjetoJson(persona);
            return await client.PostAsync(url + "/api/Admin/ConsultaUsuarios", data);
        }*/

        public static async Task<HttpResponseMessage> EliminarUsuario(int idUsuario)
        {
            return await client.PostAsync(url + "/api/Admin/EliminarUsuario?idUsuario=" + idUsuario, null);
        }

        ////////////////////////////////////////////////////////////Authentication////////////////////////////////////////////////////////////

        public static async Task<HttpResponseMessage> register(Persona persona)
        {
            var data = serializarObjetoJson(persona);
            return await client.PostAsync(url + "/api/authentication/register", data);
        }

        public static async Task<HttpResponseMessage> login(Login login)
        {
            var data = serializarObjetoJson(login);
            HttpResponseMessage res = await client.PostAsync(url + "/api/authentication/login", data);
            /*
            dynamic respuesta = JsonConvert.DeserializeObject(res.Content.ReadAsStringAsync().Result);
            token = respuesta.result.token;
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            */
            return res;
        }

        ////////////////////////////////////////////////////////////Authentication///////////////////////////////////////////////////////////

        //////////////////////////////////////////////////////////////Billetera/////////////////////////////////////////////////////////////


        //////////////////////////////////////////////////////////////Billetera/////////////////////////////////////////////////////////////

        //////////////////////////////////////////////////////////////Dashboard/////////////////////////////////////////////////////////////

        // Consultas basicas //

        public static async Task<HttpResponseMessage> estados_civilies(Login loginAdmin1)
        {
            await login(loginAdmin1);
            return await client.GetAsync(url + "/api/dashboard/EstadosCiviles");
        }

        public static async Task<HttpResponseMessage> tipos_tarjetas(Login loginAdmin1)
        {
            await login(loginAdmin1);
            return await client.GetAsync(url + "/api/dashboard/TiposTarjetas");
        }

        public static async Task<HttpResponseMessage> bancos(Login loginAdmin1)
        {
            await login(loginAdmin1);
            return await client.GetAsync(url + "/api/dashboard/Bancos");
        }

        public static async Task<HttpResponseMessage> tipos_cuentas(Login loginAdmin1)
        {
            await login(loginAdmin1);
            return await client.GetAsync(url + "/api/dashboard/TiposCuentas");
        }

        public static async Task<HttpResponseMessage> tipos_parametros(Login loginAdmin1)
        {
            await login(loginAdmin1);
            return await client.GetAsync(url + "/api/dashboard/TiposParametros");
        }
        
        public static async Task<HttpResponseMessage> frecuencia(Login loginAdmin1)
        {
            await login(loginAdmin1);
            return await client.GetAsync(url + "/api/dashboard/Frecuencias");
        }

        // error desonocido en peticion de parametros
        public static async Task<HttpResponseMessage> parametros(Login loginAdmin1)
        {
            await login(loginAdmin1);
            return await client.GetAsync(url + "/api/dashboard/Parametros");
        }
        public static async Task<HttpResponseMessage> tipos_operaciones(Login loginAdmin1)
        {
            await login(loginAdmin1);
            return await client.GetAsync(url + "/api/dashboard/TiposOperaciones");
        }

        public static async Task<HttpResponseMessage> tipos_identificacion(Login loginAdmin1)
        {
            await login(loginAdmin1);
            return await client.GetAsync(url + "/api/dashboard/TiposIdentificaciones");
        }

        // Fin consultas basicas // 

        // Consultas de usuario //

        public static async Task<HttpResponseMessage> tarjetas(int id, Login loginAdmin1)
        {
            await login(loginAdmin1);
            return await client.GetAsync(url + "/api/dashboard/Tarjetas?IdUsuario=" + id);
        }
        public static async Task<HttpResponseMessage> cuentas(int id, Login loginAdmin1)
        {
            await login(loginAdmin1);
            return await client.GetAsync(url + "/api/dashboard/Cuentas?IdUsuario=" + id);
        }

        public static async Task<HttpResponseMessage> reintegros_activos(int idUsuario, Login loginAdmin1)
        {
            await login(loginAdmin1);
            return await client.GetAsync(url + "/api/dashboard/ReintegrosActivos?IdUsuario="+ idUsuario +"&solicitante=0");
        }

        public static async Task<HttpResponseMessage> reintegros_cancelados(int idUsuario, Login loginAdmin1)
        {
            await login(loginAdmin1);
            return await client.GetAsync(url + "/api/dashboard/ReintegrosCancelados?UsuarioId="+ idUsuario +"&solicitante=0");
        }

        public static async Task<HttpResponseMessage> reintegros_exitosos(int idUsuario, Login loginAdmin1)
        {
            await login(loginAdmin1);
            return await client.GetAsync(url + "/api/dashboard/ReintegrosExitosos?UsuarioId=" + idUsuario + "&solicitante=0" );
        }

        public static async Task<HttpResponseMessage> cobros_activos(int idUsuario, Login loginAdmin1)
        {
            await login(loginAdmin1);
            return await client.GetAsync(url + "/api/dashboard/CobrosActivos?IdUsuario=" + idUsuario + "&solicitante=0");
        }

        public static async Task<HttpResponseMessage> cobros_cancelados(int idUsuario, Login loginAdmin1)
        {
            await login(loginAdmin1);
            return await client.GetAsync(url + "/api/dashboard/CobrosCancelados?UsuarioId=" + idUsuario + "&solicitante=0");
        }

        public static async Task<HttpResponseMessage> cobros_exitosos(int idUsuario, Login loginAdmin1)
        {
            await login(loginAdmin1);
            return await client.GetAsync(url + "/api/dashboard/CobrosExitosos?UsuarioId=" + idUsuario + "&solicitante=0");
        }

        /*error en peticion ParametrosUsuarios*/

        public static async Task<HttpResponseMessage> informacion_persona(string user, Login loginAdmin1)
        {
            await login(loginAdmin1);
            return await client.GetAsync(url + "/api/dashboard/InformacionPersona?Usuario=" + user);
        }

        public static async Task<HttpResponseMessage> consulta_usuarios_familiares(ConsultaUsuariosFamiliares idUsuario)
        {
            var data = serializarObjetoJson(idUsuario);
            HttpResponseMessage res = await client.PostAsync(url + "/api/dashboard/ConsultaUsuariosF", data);

            return res;
        }


        // Fin Consultas de usuario // 

        //////////////////////////////////////////////////////////////Dashboard/////////////////////////////////////////////////////////////

        //Historial Operaciones//

        public static async Task<HttpResponseMessage> historial_operacion_targeta(int id)
        {
            return await client.GetAsync(url + "/api/HistorialOperaciones/HistorialOperacionesTarjeta?TarjetaId=" + id);
        }

        public static async Task<HttpResponseMessage> historial_operacion_cuenta(int id)
        {
            return await client.GetAsync(url + "/api/HistorialOperaciones/HistorialOperacionesCuenta?CuentaId=" + id);
        }

        public static async Task<HttpResponseMessage> historial_operacion_monedero(int id)
        {
            return await client.GetAsync(url + "/api/HistorialOperaciones/HistorialOperacionesMonedero?UsuarioId=" + id);
        }

        public static async Task<HttpResponseMessage> ejecutar_cierre(int id)
        {
            return await client.GetAsync(url + "/api/HistorialOperaciones/EjecutarCierre?IdUsuario=" + id);
        }

        //////////////////////////////////////////////////////////////Monedero/////////////////////////////////////////////////////////////

        public static async Task<HttpResponseMessage> saldo(int id, Login loginAdmin1)
        {
            await login(loginAdmin1);
            return await client.GetAsync(url + "/api/monedero/Consultar?idusuario=" + id);
        }

        public static async Task<HttpResponseMessage> recargar_saldo_tarjeta(RecargaSaldoUsuario recarga, Login loginAdmin1)
        {
            await login(loginAdmin1);
            var data = serializarObjetoJson(recarga);
            return await client.PostAsync(url + "/api/monedero/RecargaMonederoTarjeta", data);
        }

        public static async Task<HttpResponseMessage> recargar_saldo_cuenta(RecargaSaldoUsuario recarga, Login loginAdmin1)
        {
            await login(loginAdmin1);
            var data = serializarObjetoJson(recarga);
            return await client.PostAsync(url + "/api/monedero/RecargaMonederoCuenta", data);
        }

        public static async Task<HttpResponseMessage> retiro(RecargaSaldoUsuario recarga, Login loginAdmin1)
        {
            await login(loginAdmin1);
            var data = serializarObjetoJson(recarga);
            return await client.PostAsync(url + "/api/monedero/Retiro", data);
        }

        //////////////////////////////////////////////////////////////Monedero/////////////////////////////////////////////////////////////

        //Transfer//



    }
}
