using Newtonsoft.Json;
using PruebasUnitarias.Modelos;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net;
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
        static dynamic loginTestUser1 = new
        {
            username = "TestUser1",
            email = "testuser1@gmail.com",
            password = "PassTestUser1",
            comercio = false,
        };
        /*static InfoLogin loginTestUser2 = new InfoLogin
        {
            UserName = "TestUser2",
            Email = "TestUser2@gmail.com",
            Password = "PassTestUser2",
            Comercio = false,
        };
        static InfoLogin loginTestUser3 = new InfoLogin
        {
            UserName = "TestUser3",
            Email = "TestUser3@gmail.com",
            Password = "PassTestUser3",
            Comercio = false,
        };*/
        static string token;

        /*public async static Task<string> getToken()
        {
            var data = serializarObjetoJson(loginTestUser1);
            HttpResponseMessage res = await client.PostAsync(url + "/api/authentication/login", data);

            dynamic respuesta = JsonConvert.DeserializeObject(res.Content.ReadAsStringAsync().Result);
            string token = respuesta.result.token;
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            return token;
        }*/

        public static StringContent serializarObjetoJson(object objeto)
        {
            var json = JsonConvert.SerializeObject(objeto);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            return data;
        }

        ///////////////////////////////////////////////////Admin/////////////////////////////////////

        public static async Task<HttpResponseMessage> ConsultaUsuarios(string query)
        {
            await login(loginTestUser1);
            return await client.GetAsync(url + "/api/Admin/ConsultaUsuarios?query=" + query);
        }

        public static async Task<HttpResponseMessage> EliminarUsuario(int idUsuario)
        {
            await login(loginTestUser1);
            return await client.DeleteAsync(url + "/api/Admin/EliminarUsuario?idUsuario=" + idUsuario);
        }

        public static async Task<HttpResponseMessage> EstablecerLimiteParametro(dynamic infoParametro)
        {
            await login(loginTestUser1);
            var data = serializarObjetoJson(infoParametro);
            return await client.PostAsync(url + "/api/Admin/EstablecerLimiteParametro", data);
        }

        public static async Task<HttpResponseMessage> EstablecerComision(dynamic infoComision)
        {
            await login(loginTestUser1);
            var data = serializarObjetoJson(infoComision);
            return await client.PostAsync(url + "/api/Admin/EstablecerComision", data);
        }

        ////////////////////////////////////////////////////////////Authentication////////////////////////////////////////////////////////////

        public static async Task<HttpResponseMessage> register(Persona persona)
        {
            await login(loginTestUser1);
            var data = serializarObjetoJson(persona);
            return await client.PostAsync(url + "/api/authentication/register", data);
        }

        public static async Task<HttpResponseMessage> RegisterComercio(dynamic comercio)
        {
            await login(loginTestUser1);
            var data = serializarObjetoJson(comercio);
            return await client.PostAsync(url + "/api/authentication/RegisterComercio", data);
        }

        public static async Task<HttpResponseMessage> RegisterFamiliar(Persona persona)
        {
            await login(loginTestUser1);
            var data = serializarObjetoJson(persona);
            return await client.PostAsync(url + "/api/authentication/RegisterFamiliar", data);
        }

        public static async Task<HttpResponseMessage> login(dynamic infoLogin)
        {
            var data = serializarObjetoJson(infoLogin);
            HttpResponseMessage res = await client.PostAsync(url + "/api/authentication/login", data);

            if (res.StatusCode == HttpStatusCode.OK)
            {
                dynamic respuesta = JsonConvert.DeserializeObject(res.Content.ReadAsStringAsync().Result);
                token = respuesta.result.token;
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }
            return res;
        }

        public static async Task<HttpResponseMessage> ConfirmedEmail(dynamic infoConfirmacionCorreo)
        {
            await login(loginTestUser1);
            var data = serializarObjetoJson(infoConfirmacionCorreo);
            return await client.PostAsync(url + "/api/authentication/ConfirmedEmail", data);
        }

        public static async Task<HttpResponseMessage> ForgotPasswordEmail(string correo)
        {
            await login(loginTestUser1);
            var data = serializarObjetoJson(correo);
            return await client.PostAsync(url + "/api/authentication/ForgotPasswordEmail", data);
        }

        public static async Task<HttpResponseMessage> ResetPassword(dynamic infoRestablecerContrasena)
        {
            await login(loginTestUser1);
            var data = serializarObjetoJson(infoRestablecerContrasena);
            return await client.PostAsync(url + "/api/authentication/ResetPassword", data);
        }

        public static async Task<HttpResponseMessage> ChangePassword(dynamic infoCambiarContrasena)
        {
            await login(loginTestUser1);
            var data = serializarObjetoJson(infoCambiarContrasena);
            return await client.PostAsync(url + "/api/authentication/ChangePassword", data);
        }

        public static async Task<HttpResponseMessage> modification(dynamic infoModificacionUsuario)
        {
            await login(loginTestUser1);
            var data = serializarObjetoJson(infoModificacionUsuario);
            return await client.PostAsync(url + "/api/authentication/modification", data);
        }

        //////////////////////////////////////////////////////////////Billetera/////////////////////////////////////////////////////////////

        public static async Task<HttpResponseMessage> Cuenta(dynamic cuenta)
        {
            await login(loginTestUser1);
            var data = serializarObjetoJson(cuenta);
            return await client.PostAsync(url + "/api/Billetera/Cuenta", data);
        }

        public static async Task<HttpResponseMessage> tarjeta(dynamic tarjeta)
        {
            await login(loginTestUser1);
            var data = serializarObjetoJson(tarjeta);
            return await client.PostAsync(url + "/api/Billetera/tarjeta", data);
        }

        public static async Task<HttpResponseMessage> EliminarCuenta(int CuentaId)
        {
            await login(loginTestUser1);
            var data = serializarObjetoJson(CuentaId);
            return await client.DeleteAsync(url + "/api/Billetera/EliminarCuenta?CuentaId=" + CuentaId);
        }

        public static async Task<HttpResponseMessage> EliminarTarjeta(int TarjetaId)
        {
            await login(loginTestUser1);
            var data = serializarObjetoJson(TarjetaId);
            return await client.DeleteAsync(url + "/api/Billetera/EliminarTarjeta?TarjetaId=" + TarjetaId);
        }

        //////////////////////////////////////////////////////////////Dashboard/////////////////////////////////////////////////////////////

        ///ConsultasBase///

        public static async Task<HttpResponseMessage> EstadosCiviles()
        {
            await login(loginTestUser1);
            return await client.GetAsync(url + "/api/dashboard/EstadosCiviles");
        }

        public static async Task<HttpResponseMessage> TiposTarjetas()
        {
            await login(loginTestUser1);
            return await client.GetAsync(url + "/api/dashboard/TiposTarjetas");
        }

        public static async Task<HttpResponseMessage> Bancos()
        {
            await login(loginTestUser1);
            return await client.GetAsync(url + "/api/dashboard/Bancos");
        }

        public static async Task<HttpResponseMessage> TiposCuentas()
        {
            await login(loginTestUser1);
            return await client.GetAsync(url + "/api/dashboard/TiposCuentas");
        }

        public static async Task<HttpResponseMessage> TiposParametros()
        {
            await login(loginTestUser1);
            return await client.GetAsync(url + "/api/dashboard/TiposParametros");
        }
        
        public static async Task<HttpResponseMessage> Frecuencias()
        {
            await login(loginTestUser1);
            return await client.GetAsync(url + "/api/dashboard/Frecuencias");
        }

        // error desonocido en peticion de parametros
        public static async Task<HttpResponseMessage> Parametros()
        {
            await login(loginTestUser1);
            return await client.GetAsync(url + "/api/dashboard/Parametros");
        }
        public static async Task<HttpResponseMessage> TiposOperaciones()
        {
            await login(loginTestUser1);
            return await client.GetAsync(url + "/api/dashboard/TiposOperaciones");
        }

        public static async Task<HttpResponseMessage> TiposIdentificaciones()
        {
            await login(loginTestUser1);
            return await client.GetAsync(url + "/api/dashboard/TiposIdentificaciones");
        }

        ///ConsultasUsuario///

        public static async Task<HttpResponseMessage> Tarjetas(int idUsuario)
        {
            await login(loginTestUser1);
            return await client.GetAsync(url + "/api/dashboard/Tarjetas?idUsuario=" + idUsuario);
        }
        public static async Task<HttpResponseMessage> Cuentas(int idUsuario)
        {
            await login(loginTestUser1);
            return await client.GetAsync(url + "/api/dashboard/Cuentas?idUsuario=" + idUsuario);
        }

        public static async Task<HttpResponseMessage> ReintegrosActivos(int idUsuario)
        {
            await login(loginTestUser1);
            return await client.GetAsync(url + "/api/dashboard/ReintegrosActivos?idUsuario="+ idUsuario + "&solicitante=0");
        }

        public static async Task<HttpResponseMessage> ReintegrosCancelados(int idUsuario)
        {
            await login(loginTestUser1);
            return await client.GetAsync(url + "/api/dashboard/ReintegrosCancelados?UsuarioId="+ idUsuario +"&solicitante=0");
        }

        public static async Task<HttpResponseMessage> ReintegrosExitosos(int idUsuario)
        {
            await login(loginTestUser1);
            return await client.GetAsync(url + "/api/dashboard/ReintegrosExitosos?UsuarioId=" + idUsuario + "&solicitante=0" );
        }

        public static async Task<HttpResponseMessage> CobrosActivos(int idUsuario, int solicitante)
        {
            await login(loginTestUser1);
            return await client.GetAsync(url + "/api/dashboard/CobrosActivos?idUsuario=" + idUsuario + "&solicitante=" + solicitante);
        }

        public static async Task<HttpResponseMessage> CobrosCancelados(int idUsuario, int solicitante)
        {
            await login(loginTestUser1);
            return await client.GetAsync(url + "/api/dashboard/CobrosCancelados?UsuarioId=" + idUsuario + "&solicitante=" + solicitante);
        }

        public static async Task<HttpResponseMessage> CobrosExitosos(int idUsuario, int solicitante)
        {
            await login(loginTestUser1);
            return await client.GetAsync(url + "/api/dashboard/CobrosExitosos?UsuarioId=" + idUsuario + "&solicitante=" + solicitante);
        }

        public static async Task<HttpResponseMessage> ParametrosUsuario(int idUsuario)
        {
            await login(loginTestUser1);
            return await client.GetAsync(url + "/api/dashboard/ParametrosUsuario?idUsuario=" + idUsuario);
        }

        public static async Task<HttpResponseMessage> InformacionPersona(string user)
        {
            await login(loginTestUser1);
            return await client.GetAsync(url + "/api/dashboard/InformacionPersona?Usuario=" + user);
        }

        public static async Task<HttpResponseMessage> ConsultaUsuariosF(int idUsuario)
        {
            await login(loginTestUser1);
            var data = serializarObjetoJson(idUsuario);
            HttpResponseMessage res = await client.PostAsync(url + "/api/dashboard/ConsultaUsuariosF", data);
            return res;
        }

        //////////////////////////////Historial Operaciones//////////////////////

        public static async Task<HttpResponseMessage> HistorialOperacionesTarjeta(dynamic id)
        {
            await login(loginTestUser1);
            return await client.GetAsync(url + "/api/HistorialOperaciones/HistorialOperacionesTarjeta?TarjetaId=" + id);
        }

        public static async Task<HttpResponseMessage> HistorialOperacionesCuenta(int id)
        {
            await login(loginTestUser1);
            return await client.GetAsync(url + "/api/HistorialOperaciones/HistorialOperacionesCuenta?CuentaId=" + id);
        }

        public static async Task<HttpResponseMessage> HistorialOperacionesMonedero(int id)
        {
            await login(loginTestUser1);
            return await client.GetAsync(url + "/api/HistorialOperaciones/HistorialOperacionesMonedero?UsuarioId=" + id);
        }

        public static async Task<HttpResponseMessage> EjecutarCierre(dynamic id)
        {
            await login(loginTestUser1);
            return await client.GetAsync(url + "/api/HistorialOperaciones/EjecutarCierre?idUsuario=" + id);
        }

        //////////////////////////////////////////////////////////////Monedero/////////////////////////////////////////////////////////////

        public static async Task<HttpResponseMessage> Consultar(dynamic id)
        {
            await login(loginTestUser1);
            return await client.GetAsync(url + "/api/monedero/Consultar?idUsuario=" + id);
        }

        public static async Task<HttpResponseMessage> RecargaMonederoTarjeta(dynamic info)
        {
            await login(loginTestUser1);
            var data = serializarObjetoJson(info);
            return await client.PostAsync(url + "/api/monedero/RecargaMonederoTarjeta", data);
        }

        public static async Task<HttpResponseMessage> RecargaMonederoCuenta(dynamic info)
        {
            await login(loginTestUser1);
            var data = serializarObjetoJson(info);
            return await client.PostAsync(url + "/api/monedero/RecargaMonederoCuenta", data);
        }

        public static async Task<HttpResponseMessage> Retiro(dynamic recarga, InfoLogin loginTestUser1)
        {
            await login(loginTestUser1);
            var data = serializarObjetoJson(recarga);
            return await client.PostAsync(url + "/api/monedero/Retiro", data);
        }

        //////////////////////////////////////////////Transfer//////////////////////////////////

        public static async Task<HttpResponseMessage> RealizarCobro(dynamic infoCobro)
        {
            await login(loginTestUser1);
            var data = serializarObjetoJson(infoCobro);
            return await client.PostAsync(url + "/api/Transfer/RealizarCobro", data);
        }

        public static async Task<HttpResponseMessage> SolicitarReintegro(dynamic infoReintegro)
        {
            await login(loginTestUser1);
            var data = serializarObjetoJson(infoReintegro);
            return await client.PostAsync(url + "/api/Transfer/SolicitarReintegro", data);
        }
        // por hacer 
        public static async Task<HttpResponseMessage> CancelarCobro(int IdCobro)
        {
            await login(loginTestUser1);
            var data = serializarObjetoJson(IdCobro);
            return await client.PostAsync(url + "/api/Transfer/CancelarCobro?idCobro=" + IdCobro, data);
        }
        // por hacer 
        public static async Task<HttpResponseMessage> CancelarReintegro(int IdReintegro)
        {
            await login(loginTestUser1);
            var data = serializarObjetoJson(IdReintegro);
            return await client.PostAsync(url + "/api/Transfer/CancelarReintegro?idreintegro=" + IdReintegro, data);
        }

        public static async Task<HttpResponseMessage> RealizarPagoCuenta(dynamic infoPagoCuenta)
        {
            await login(loginTestUser1);
            var data = serializarObjetoJson(infoPagoCuenta);
            return await client.PostAsync(url + "/api/Transfer/RealizarPagoCuenta", data);
        }

        public static async Task<HttpResponseMessage> RealizarPagoTarjeta(dynamic infoPagoTarjeta)
        {
            await login(loginTestUser1);
            var data = serializarObjetoJson(infoPagoTarjeta);
            return await client.PostAsync(url + "/api/Transfer/RealizarPagoTarjeta", data);
        }

        public static async Task<HttpResponseMessage> RealizarPagoMonedero(dynamic infoPagoMonedero)
        {
            await login(loginTestUser1);
            var data = serializarObjetoJson(infoPagoMonedero);
            return await client.PostAsync(url + "/api/Transfer/RealizarPagoMonedero", data);
        }

        public static async Task<HttpResponseMessage> RealizarReintegroCuenta(dynamic infoReintegroCuenta)
        {
            await login(loginTestUser1);
            var data = serializarObjetoJson(infoReintegroCuenta);
            return await client.PostAsync(url + "/api/Transfer/RealizarReintegroCuenta", data);
        }

        public static async Task<HttpResponseMessage> RealizarReintegroTarjeta(dynamic infoReintegroTarjeta)
        {
            await login(loginTestUser1);
            var data = serializarObjetoJson(infoReintegroTarjeta);
            return await client.PostAsync(url + "/api/Transfer/RealizarReintegroTarjeta", data);
        }

        public static async Task<HttpResponseMessage> RealizarReintegroMonedero(dynamic infoReintegroMonedero)
        {
            await login(loginTestUser1);
            var data = serializarObjetoJson(infoReintegroMonedero);
            return await client.PostAsync(url + "/api/Transfer/RealizarReintegroMonedero", data);
        }

        public static async Task<HttpResponseMessage> EstablecerParametro(dynamic infoParametro)
        {
            await login(loginTestUser1);
            var data = serializarObjetoJson(infoParametro);
            return await client.PostAsync(url + "/api/Transfer/EstablecerParametro", data);
        }

        public static async Task<HttpResponseMessage> BotonPagoTarjeta(dynamic infoPagoTarjeta)
        {
            await login(loginTestUser1);
            var data = serializarObjetoJson(infoPagoTarjeta);
            return await client.PostAsync(url + "/api/Transfer/BotonPagoTarjeta", data);
        }

        public static async Task<HttpResponseMessage> BotonPagoCuenta(dynamic infoPagoCuenta)
        {
            await login(loginTestUser1);
            var data = serializarObjetoJson(infoPagoCuenta);
            return await client.PostAsync(url + "/api/Transfer/BotonPagoCuenta", data);
        }

        public static async Task<HttpResponseMessage> BotonPagoMonedero(dynamic infoPagoMonedero)
        {
            await login(loginTestUser1);
            var data = serializarObjetoJson(infoPagoMonedero);
            return await client.PostAsync(url + "/api/Transfer/BotonPagoMonedero", data);
        }

    }
}
