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
        static InfoLogin loginTestUser = new InfoLogin
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

        ///////////////////////////////////////////////////Admin/////////////////////////////////////

        public static async Task<HttpResponseMessage> ConsultaUsuarios(string query)
        {
            return await client.PostAsync(url + "/api/Admin/ConsultaUsuarios?query=" + query, null);
        }

        public static async Task<HttpResponseMessage> EliminarUsuario(int idUsuario)
        {
            return await client.PostAsync(url + "/api/Admin/EliminarUsuario?idUsuario=" + idUsuario, null);
        }

        public static async Task<HttpResponseMessage> EstablecerLimiteParametro(dynamic infoParametro)
        {
            var data = serializarObjetoJson(infoParametro);
            return await client.PostAsync(url + "/api/Admin/EstablecerLimiteParametro", data);
        }

        public static async Task<HttpResponseMessage> EstablecerComision(dynamic infoComision)
        {
            var data = serializarObjetoJson(infoComision);
            return await client.PostAsync(url + "/api/Admin/EstablecerComision", data);
        }

        ////////////////////////////////////////////////////////////Authentication////////////////////////////////////////////////////////////

        public static async Task<HttpResponseMessage> register(Persona persona)
        {
            var data = serializarObjetoJson(persona);
            return await client.PostAsync(url + "/api/authentication/register", data);
        }

        public static async Task<HttpResponseMessage> RegisterComercio(dynamic comercio)
        {
            var data = serializarObjetoJson(comercio);
            return await client.PostAsync(url + "/api/authentication/RegisterComercio", data);
        }

        public static async Task<HttpResponseMessage> RegisterFamiliar(Persona persona)
        {
            var data = serializarObjetoJson(persona);
            return await client.PostAsync(url + "/api/authentication/RegisterFamiliar", data);
        }

        public static async Task<HttpResponseMessage> login(InfoLogin login)
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

        public static async Task<HttpResponseMessage> ConfirmedEmail(dynamic infoConfirmacionCorreo)
        {
            var data = serializarObjetoJson(infoConfirmacionCorreo);
            return await client.PostAsync(url + "/api/authentication/ConfirmedEmail", data);
        }

        public static async Task<HttpResponseMessage> ForgotPasswordEmail(string correo)
        {
            var data = serializarObjetoJson(correo);
            return await client.PostAsync(url + "/api/authentication/ForgotPasswordEmail", data);
        }

        public static async Task<HttpResponseMessage> ResetPassword(dynamic infoRestablecerContrasena)
        {
            var data = serializarObjetoJson(infoRestablecerContrasena);
            return await client.PostAsync(url + "/api/authentication/ResetPassword", data);
        }

        public static async Task<HttpResponseMessage> ChangePassword(dynamic infoCambiarContrasena)
        {
            var data = serializarObjetoJson(infoCambiarContrasena);
            return await client.PostAsync(url + "/api/authentication/ChangePassword", data);
        }

        public static async Task<HttpResponseMessage> modification(dynamic infoModificacionUsuario)
        {
            var data = serializarObjetoJson(infoModificacionUsuario);
            return await client.PostAsync(url + "/api/authentication/modification", data);
        }

        //////////////////////////////////////////////////////////////Billetera/////////////////////////////////////////////////////////////

        public static async Task<HttpResponseMessage> Cuenta(dynamic cuenta)
        {
            var data = serializarObjetoJson(cuenta);
            return await client.PostAsync(url + "/api/Billetera/Cuenta", data);
        }

        public static async Task<HttpResponseMessage> tarjeta(dynamic tarjeta)
        {
            var data = serializarObjetoJson(tarjeta);
            return await client.PostAsync(url + "/api/Billetera/tarjeta", data);
        }

        public static async Task<HttpResponseMessage> EliminarCuenta(int CuentaId)
        {
            var data = serializarObjetoJson(CuentaId);
            return await client.DeleteAsync(url + "/api/Billetera/EliminarCuenta?CuentaId=" + CuentaId);
        }

        public static async Task<HttpResponseMessage> EliminarTarjeta(int TarjetaId)
        {
            var data = serializarObjetoJson(TarjetaId);
            return await client.DeleteAsync(url + "/api/Billetera/EliminarTarjeta?TarjetaId=" + TarjetaId);
        }

        //////////////////////////////////////////////////////////////Dashboard/////////////////////////////////////////////////////////////

        ///ConsultasBase///

        public static async Task<HttpResponseMessage> EstadosCiviles(InfoLogin loginAdmin1)
        {
            await login(loginAdmin1);
            return await client.GetAsync(url + "/api/dashboard/EstadosCiviles");
        }

        public static async Task<HttpResponseMessage> TiposTarjetas(InfoLogin loginAdmin1)
        {
            await login(loginAdmin1);
            return await client.GetAsync(url + "/api/dashboard/TiposTarjetas");
        }

        public static async Task<HttpResponseMessage> Bancos(InfoLogin loginAdmin1)
        {
            await login(loginAdmin1);
            return await client.GetAsync(url + "/api/dashboard/Bancos");
        }

        public static async Task<HttpResponseMessage> TiposCuentas(InfoLogin loginAdmin1)
        {
            await login(loginAdmin1);
            return await client.GetAsync(url + "/api/dashboard/TiposCuentas");
        }

        public static async Task<HttpResponseMessage> TiposParametros(InfoLogin loginAdmin1)
        {
            await login(loginAdmin1);
            return await client.GetAsync(url + "/api/dashboard/TiposParametros");
        }
        
        public static async Task<HttpResponseMessage> Frecuencias(InfoLogin loginAdmin1)
        {
            await login(loginAdmin1);
            return await client.GetAsync(url + "/api/dashboard/Frecuencias");
        }

        // error desonocido en peticion de parametros
        public static async Task<HttpResponseMessage> Parametros(InfoLogin loginAdmin1)
        {
            await login(loginAdmin1);
            return await client.GetAsync(url + "/api/dashboard/Parametros");
        }
        public static async Task<HttpResponseMessage> TiposOperaciones(InfoLogin loginAdmin1)
        {
            await login(loginAdmin1);
            return await client.GetAsync(url + "/api/dashboard/TiposOperaciones");
        }

        public static async Task<HttpResponseMessage> TiposIdentificaciones(InfoLogin loginAdmin1)
        {
            await login(loginAdmin1);
            return await client.GetAsync(url + "/api/dashboard/TiposIdentificaciones");
        }

        ///ConsultasUsuario///

        public static async Task<HttpResponseMessage> Tarjetas(int id, InfoLogin loginAdmin1)
        {
            await login(loginAdmin1);
            return await client.GetAsync(url + "/api/dashboard/Tarjetas?IdUsuario=" + id);
        }
        public static async Task<HttpResponseMessage> Cuentas(int id, InfoLogin loginAdmin1)
        {
            await login(loginAdmin1);
            return await client.GetAsync(url + "/api/dashboard/Cuentas?IdUsuario=" + id);
        }

        public static async Task<HttpResponseMessage> ReintegrosActivos(int idUsuario, InfoLogin loginAdmin1)
        {
            await login(loginAdmin1);
            return await client.GetAsync(url + "/api/dashboard/ReintegrosActivos?IdUsuario="+ idUsuario +"&solicitante=0");
        }

        public static async Task<HttpResponseMessage> ReintegrosCancelados(int idUsuario, InfoLogin loginAdmin1)
        {
            await login(loginAdmin1);
            return await client.GetAsync(url + "/api/dashboard/ReintegrosCancelados?UsuarioId="+ idUsuario +"&solicitante=0");
        }

        public static async Task<HttpResponseMessage> ReintegrosExitosos(int idUsuario, InfoLogin loginAdmin1)
        {
            await login(loginAdmin1);
            return await client.GetAsync(url + "/api/dashboard/ReintegrosExitosos?UsuarioId=" + idUsuario + "&solicitante=0" );
        }

        public static async Task<HttpResponseMessage> CobrosActivos(int idUsuario, InfoLogin loginAdmin1)
        {
            await login(loginAdmin1);
            return await client.GetAsync(url + "/api/dashboard/CobrosActivos?IdUsuario=" + idUsuario + "&solicitante=0");
        }

        public static async Task<HttpResponseMessage> CobrosCancelados(int idUsuario, InfoLogin loginAdmin1)
        {
            await login(loginAdmin1);
            return await client.GetAsync(url + "/api/dashboard/CobrosCancelados?UsuarioId=" + idUsuario + "&solicitante=0");
        }

        public static async Task<HttpResponseMessage> CobrosExitosos(int idUsuario, InfoLogin loginAdmin1)
        {
            await login(loginAdmin1);
            return await client.GetAsync(url + "/api/dashboard/CobrosExitosos?UsuarioId=" + idUsuario + "&solicitante=0");
        }

        public static async Task<HttpResponseMessage> ParametrosUsuario(string user, InfoLogin loginAdmin1)
        {
            await login(loginAdmin1);
            return await client.GetAsync(url + "/api/dashboard/ParametrosUsuario?UsuarioId=" + user);
        }

        public static async Task<HttpResponseMessage> InformacionPersona(string user, InfoLogin loginAdmin1)
        {
            await login(loginAdmin1);
            return await client.GetAsync(url + "/api/dashboard/InformacionPersona?Usuario=" + user);
        }

        public static async Task<HttpResponseMessage> ConsultaUsuariosF(int idUsuario)
        {
            var data = serializarObjetoJson(idUsuario);
            HttpResponseMessage res = await client.PostAsync(url + "/api/dashboard/ConsultaUsuariosF", data);

            return res;
        }

        //////////////////////////////Historial Operaciones//////////////////////

        public static async Task<HttpResponseMessage> HistorialOperacionesTarjeta(int id)
        {
            return await client.GetAsync(url + "/api/HistorialOperaciones/HistorialOperacionesTarjeta?TarjetaId=" + id);
        }

        public static async Task<HttpResponseMessage> HistorialOperacionesCuenta(int id)
        {
            return await client.GetAsync(url + "/api/HistorialOperaciones/HistorialOperacionesCuenta?CuentaId=" + id);
        }

        public static async Task<HttpResponseMessage> HistorialOperacionesMonedero(int id)
        {
            return await client.GetAsync(url + "/api/HistorialOperaciones/HistorialOperacionesMonedero?UsuarioId=" + id);
        }

        public static async Task<HttpResponseMessage> EjecutarCierre(int id)
        {
            return await client.GetAsync(url + "/api/HistorialOperaciones/EjecutarCierre?IdUsuario=" + id);
        }

        //////////////////////////////////////////////////////////////Monedero/////////////////////////////////////////////////////////////

        public static async Task<HttpResponseMessage> Consultar(int id, InfoLogin loginAdmin1)
        {
            await login(loginAdmin1);
            return await client.GetAsync(url + "/api/monedero/Consultar?idusuario=" + id);
        }

        public static async Task<HttpResponseMessage> RecargaMonederoTarjeta(RecargaSaldoUsuario recarga, InfoLogin loginAdmin1)
        {
            await login(loginAdmin1);
            var data = serializarObjetoJson(recarga);
            return await client.PostAsync(url + "/api/monedero/RecargaMonederoTarjeta", data);
        }

        public static async Task<HttpResponseMessage> RecargaMonederoCuenta(RecargaSaldoUsuario recarga, InfoLogin loginAdmin1)
        {
            await login(loginAdmin1);
            var data = serializarObjetoJson(recarga);
            return await client.PostAsync(url + "/api/monedero/RecargaMonederoCuenta", data);
        }

        public static async Task<HttpResponseMessage> Retiro(RecargaSaldoUsuario recarga, InfoLogin loginAdmin1)
        {
            await login(loginAdmin1);
            var data = serializarObjetoJson(recarga);
            return await client.PostAsync(url + "/api/monedero/Retiro", data);
        }

        //////////////////////////////////////////////Transfer//////////////////////////////////

        public static async Task<HttpResponseMessage> RealizarCobro(dynamic infoCobro)
        {
            var data = serializarObjetoJson(infoCobro);
            return await client.PostAsync(url + "/api/Transfer/RealizarCobro", data);
        }

        public static async Task<HttpResponseMessage> SolicitarReintegro(dynamic infoReintegro)
        {
            var data = serializarObjetoJson(infoReintegro);
            return await client.PostAsync(url + "/api/Transfer/SolicitarReintegro", data);
        }

        public static async Task<HttpResponseMessage> CancelarCobro(int IdCobro)
        {
            var data = serializarObjetoJson(IdCobro);
            return await client.PostAsync(url + "/api/Transfer/CancelarCobro", data);
        }

        public static async Task<HttpResponseMessage> CancelarReintegro(int IdReintegro)
        {
            var data = serializarObjetoJson(IdReintegro);
            return await client.PostAsync(url + "/api/Transfer/CancelarReintegro", data);
        }

        public static async Task<HttpResponseMessage> RealizarPagoCuenta(dynamic infoPagoCuenta)
        {
            var data = serializarObjetoJson(infoPagoCuenta);
            return await client.PostAsync(url + "/api/Transfer/RealizarPagoCuenta", data);
        }

        public static async Task<HttpResponseMessage> RealizarPagoTarjeta(dynamic infoPagoTarjeta)
        {
            var data = serializarObjetoJson(infoPagoTarjeta);
            return await client.PostAsync(url + "/api/Transfer/RealizarPagoTarjeta", data);
        }

        public static async Task<HttpResponseMessage> RealizarPagoMonedero(dynamic infoPagoMonedero)
        {
            var data = serializarObjetoJson(infoPagoMonedero);
            return await client.PostAsync(url + "/api/Transfer/RealizarPagoMonedero", data);
        }

        public static async Task<HttpResponseMessage> RealizarReintegroCuenta(dynamic infoReintegroCuenta)
        {
            var data = serializarObjetoJson(infoReintegroCuenta);
            return await client.PostAsync(url + "/api/Transfer/RealizarReintegroCuenta", data);
        }

        public static async Task<HttpResponseMessage> RealizarReintegroTarjeta(dynamic infoReintegroTarjeta)
        {
            var data = serializarObjetoJson(infoReintegroTarjeta);
            return await client.PostAsync(url + "/api/Transfer/RealizarReintegroTarjeta", data);
        }

        public static async Task<HttpResponseMessage> RealizarReintegroMonedero(dynamic infoReintegroMonedero)
        {
            var data = serializarObjetoJson(infoReintegroMonedero);
            return await client.PostAsync(url + "/api/Transfer/RealizarReintegroMonedero", data);
        }

        public static async Task<HttpResponseMessage> EstablecerParametro(dynamic infoParametro)
        {
            var data = serializarObjetoJson(infoParametro);
            return await client.PostAsync(url + "/api/Transfer/EstablecerParametro", data);
        }

        public static async Task<HttpResponseMessage> BotonPagoTarjeta(dynamic infoPagoTarjeta)
        {
            var data = serializarObjetoJson(infoPagoTarjeta);
            return await client.PostAsync(url + "/api/Transfer/BotonPagoTarjeta", data);
        }

        public static async Task<HttpResponseMessage> BotonPagoCuenta(dynamic infoPagoCuenta)
        {
            var data = serializarObjetoJson(infoPagoCuenta);
            return await client.PostAsync(url + "/api/Transfer/BotonPagoCuenta", data);
        }

        public static async Task<HttpResponseMessage> BotonPagoMonedero(dynamic infoPagoMonedero)
        {
            var data = serializarObjetoJson(infoPagoMonedero);
            return await client.PostAsync(url + "/api/Transfer/BotonPagoMonedero", data);
        }

    }
}
