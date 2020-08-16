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

        /*public static Task<string> getToken()
        {
            var data = serializarObjetoJson(loginTestUser1);
            HttpResponseMessage res = client.PostAsync(url + "/api/authentication/login", data); }).Wait(); return res;

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

        public static Task<HttpResponseMessage> ConsultaUsuarios(string query)
        {
            login(loginTestUser1);
            Task<HttpResponseMessage> res = null; Task.Run(() => { res = client.GetAsync(url + "/api/Admin/ConsultaUsuarios?query=" + query); }).Wait(); return res;
        }

        public static Task<HttpResponseMessage> EliminarUsuario(int idUsuario)
        {
            login(loginTestUser1);
            Task<HttpResponseMessage> res = null; Task.Run(() => { res = client.DeleteAsync(url + "/api/Admin/EliminarUsuario?idUsuario=" + idUsuario); }).Wait(); return res;
        }

        public static Task<HttpResponseMessage> EstablecerLimiteParametro(dynamic infoParametro)
        {
            login(loginTestUser1);
            var data = serializarObjetoJson(infoParametro);
            Task<HttpResponseMessage> res = null; Task.Run(() => { res = client.PostAsync(url + "/api/Admin/EstablecerLimiteParametro", data); }).Wait(); return res;
        }

        public static Task<HttpResponseMessage> EstablecerComision(int idComercio, int comision)
        {
            login(loginTestUser1);
            Task<HttpResponseMessage> res = null; Task.Run(() => { res = client.PostAsync(url + "/api/Admin/EstablecerComision?idComercio=" + idComercio + "&comision=" + comision, null); }).Wait(); return res;
        }

        ////////////////////////////////////////////////////////////Authentication////////////////////////////////////////////////////////////

        public static Task<HttpResponseMessage> register(dynamic persona)
        {
            login(loginTestUser1);
            var data = serializarObjetoJson(persona);
            Task<HttpResponseMessage> res = null; Task.Run(() => { res = client.PostAsync(url + "/api/authentication/register", data); }).Wait(); return res;
        }

        public static Task<HttpResponseMessage> RegisterComercio(dynamic comercio)
        {
            login(loginTestUser1);
            var data = serializarObjetoJson(comercio);
            Task<HttpResponseMessage> res = null; Task.Run(() => { res = client.PostAsync(url + "/api/authentication/RegisterComercio", data); }).Wait(); return res;
        }

        public static Task<HttpResponseMessage> RegisterFamiliar(dynamic persona)
        {
            login(loginTestUser1);
            var data = serializarObjetoJson(persona);
            Task<HttpResponseMessage> res = null; Task.Run(() => { res = client.PostAsync(url + "/api/authentication/RegisterFamiliar", data); }).Wait(); return res;
        }

        public static Task<HttpResponseMessage> login(dynamic infoLogin)
        {
            var data = serializarObjetoJson(infoLogin);
            Task<HttpResponseMessage> res = null; Task.Run(() => { res = client.PostAsync(url + "/api/authentication/login", data); }).Wait();

            if (res.Result.StatusCode == HttpStatusCode.OK)
            {
                dynamic respuesta = JsonConvert.DeserializeObject(res.Result.Content.ReadAsStringAsync().Result);
                token = respuesta.result.token;
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }
            return res;
        }

        public static Task<HttpResponseMessage> ConfirmedEmail(dynamic infoConfirmacionCorreo)
        {
            login(loginTestUser1);
            var data = serializarObjetoJson(infoConfirmacionCorreo);
            Task<HttpResponseMessage> res = null; Task.Run(() => { res = client.PostAsync(url + "/api/authentication/ConfirmedEmail", data); }).Wait(); return res;
        }

        public static Task<HttpResponseMessage> ForgotPasswordEmail(dynamic correo)
        {
            login(loginTestUser1);
            var data = serializarObjetoJson(correo);
            Task<HttpResponseMessage> res = null; Task.Run(() => { res = client.PostAsync(url + "/api/authentication/ForgotPasswordEmail", data); }).Wait(); return res;
        }

        public static Task<HttpResponseMessage> ResetPassword(dynamic infoRestablecerContrasena)
        {
            login(loginTestUser1);
            var data = serializarObjetoJson(infoRestablecerContrasena);
            Task<HttpResponseMessage> res = null; Task.Run(() => { res = client.PostAsync(url + "/api/authentication/ResetPassword", data); }).Wait(); return res;
        }

        public static Task<HttpResponseMessage> ChangePassword(dynamic infoCambiarContrasena)
        {
            login(loginTestUser1);
            var data = serializarObjetoJson(infoCambiarContrasena);
            Task<HttpResponseMessage> res = null; Task.Run(() => { res = client.PostAsync(url + "/api/authentication/ChangePassword", data); }).Wait(); return res;
        }

        public static Task<HttpResponseMessage> modification(dynamic infoModificacionUsuario)
        {
            login(loginTestUser1);
            var data = serializarObjetoJson(infoModificacionUsuario);
            Task<HttpResponseMessage> res = null; Task.Run(() => { res = client.PostAsync(url + "/api/authentication/modification", data); }).Wait(); return res;
        }

        //////////////////////////////////////////////////////////////Billetera/////////////////////////////////////////////////////////////

        public static Task<HttpResponseMessage> Cuenta(dynamic cuenta)
        {
            login(loginTestUser1);
            var data = serializarObjetoJson(cuenta);
            Task<HttpResponseMessage> res = null; Task.Run(() => { res = client.PostAsync(url + "/api/Billetera/Cuenta", data); }).Wait(); return res;
        }

        public static Task<HttpResponseMessage> tarjeta(dynamic tarjeta)
        {
            login(loginTestUser1);
            var data = serializarObjetoJson(tarjeta);
            Task<HttpResponseMessage> res = null; Task.Run(() => { res = client.PostAsync(url + "/api/Billetera/tarjeta", data); }).Wait(); return res;
        }

        public static Task<HttpResponseMessage> EliminarCuenta(int CuentaId)
        {
            login(loginTestUser1);
            Task<HttpResponseMessage> res = null; Task.Run(() => { res = client.DeleteAsync(url + "/api/Billetera/EliminarCuenta?CuentaId=" + CuentaId); }).Wait(); return res;
        }

        public static Task<HttpResponseMessage> EliminarTarjeta(int TarjetaId)
        {
            login(loginTestUser1);
            Task<HttpResponseMessage> res = null; Task.Run(() => { res = client.DeleteAsync(url + "/api/Billetera/EliminarTarjeta?TarjetaId=" + TarjetaId); }).Wait(); return res;
        }

        //////////////////////////////////////////////////////////////Dashboard/////////////////////////////////////////////////////////////

        ///ConsultasBase///

        public static Task<HttpResponseMessage> EstadosCiviles()
        {
            login(loginTestUser1);
            Task<HttpResponseMessage> res = null; Task.Run(() => { res = client.GetAsync(url + "/api/dashboard/EstadosCiviles"); }).Wait(); return res;
        }

        public static Task<HttpResponseMessage> TiposTarjetas()
        {
            login(loginTestUser1);
            Task<HttpResponseMessage> res = null; Task.Run(() => { res = client.GetAsync(url + "/api/dashboard/TiposTarjetas"); }).Wait(); return res;
        }

        public static Task<HttpResponseMessage> Bancos()
        {
            login(loginTestUser1);
            Task<HttpResponseMessage> res = null; Task.Run(() => { res = client.GetAsync(url + "/api/dashboard/Bancos"); }).Wait(); return res;
        }

        public static Task<HttpResponseMessage> TiposCuentas()
        {
            login(loginTestUser1);
            Task<HttpResponseMessage> res = null; Task.Run(() => { res = client.GetAsync(url + "/api/dashboard/TiposCuentas"); }).Wait(); return res;
        }

        public static Task<HttpResponseMessage> TiposParametros()
        {
            login(loginTestUser1);
            Task<HttpResponseMessage> res = null; Task.Run(() => { res = client.GetAsync(url + "/api/dashboard/TiposParametros"); }).Wait(); return res;
        }
        
        public static Task<HttpResponseMessage> Frecuencias()
        {
            login(loginTestUser1);
            Task<HttpResponseMessage> res = null; Task.Run(() => { res = client.GetAsync(url + "/api/dashboard/Frecuencias"); }).Wait(); return res;
        }

        // error desonocido en peticion de parametros
        public static Task<HttpResponseMessage> Parametros()
        {
            login(loginTestUser1);
            Task<HttpResponseMessage> res = null; Task.Run(() => { res = client.GetAsync(url + "/api/dashboard/Parametros"); }).Wait(); return res;
        }
        public static Task<HttpResponseMessage> TiposOperaciones()
        {
            login(loginTestUser1);
            Task<HttpResponseMessage> res = null; Task.Run(() => { res = client.GetAsync(url + "/api/dashboard/TiposOperaciones"); }).Wait(); return res;
        }

        public static Task<HttpResponseMessage> TiposIdentificaciones()
        {
            login(loginTestUser1);
            Task<HttpResponseMessage> res = null; Task.Run(() => { res = client.GetAsync(url + "/api/dashboard/TiposIdentificaciones"); }).Wait(); return res;
        }

        ///ConsultasUsuario///

        public static Task<HttpResponseMessage> Tarjetas(int idUsuario)
        {
            login(loginTestUser1);
            Task<HttpResponseMessage> res = null; Task.Run(() => { res = client.GetAsync(url + "/api/dashboard/Tarjetas?idUsuario=" + idUsuario); }).Wait(); return res;
        }
        public static Task<HttpResponseMessage> Cuentas(int idUsuario)
        {
            login(loginTestUser1);
            Task<HttpResponseMessage> res = null; Task.Run(() => { res = client.GetAsync(url + "/api/dashboard/Cuentas?idUsuario=" + idUsuario); }).Wait(); return res;
        }

        public static Task<HttpResponseMessage> ReintegrosActivos(int idUsuario)
        {
            login(loginTestUser1);
            Task<HttpResponseMessage> res = null; Task.Run(() => { res = client.GetAsync(url + "/api/dashboard/ReintegrosActivos?idUsuario="+ idUsuario + "&solicitante=0"); }).Wait(); return res;
        }

        public static Task<HttpResponseMessage> ReintegrosCancelados(int idUsuario)
        {
            login(loginTestUser1);
            Task<HttpResponseMessage> res = null; Task.Run(() => { res = client.GetAsync(url + "/api/dashboard/ReintegrosCancelados?UsuarioId="+ idUsuario +"&solicitante=0"); }).Wait(); return res;
        }

        public static Task<HttpResponseMessage> ReintegrosExitosos(int idUsuario)
        {
            login(loginTestUser1);
            Task<HttpResponseMessage> res = null; Task.Run(() => { res = client.GetAsync(url + "/api/dashboard/ReintegrosExitosos?UsuarioId=" + idUsuario + "&solicitante=0" ); }).Wait(); return res;
        }

        public static Task<HttpResponseMessage> CobrosActivos(int idUsuario, int solicitante)
        {
            login(loginTestUser1);
            Task<HttpResponseMessage> res = null; Task.Run(() => { res = client.GetAsync(url + "/api/dashboard/CobrosActivos?idUsuario=" + idUsuario + "&solicitante=" + solicitante); }).Wait(); return res;
        }

        public static Task<HttpResponseMessage> CobrosCancelados(int idUsuario, int solicitante)
        {
            login(loginTestUser1);
            Task<HttpResponseMessage> res = null; Task.Run(() => { res = client.GetAsync(url + "/api/dashboard/CobrosCancelados?UsuarioId=" + idUsuario + "&solicitante=" + solicitante); }).Wait(); return res;
        }

        public static Task<HttpResponseMessage> CobrosExitosos(int idUsuario, int solicitante)
        {
            login(loginTestUser1);
            Task<HttpResponseMessage> res = null; Task.Run(() => { res = client.GetAsync(url + "/api/dashboard/CobrosExitosos?UsuarioId=" + idUsuario + "&solicitante=" + solicitante); }).Wait(); return res;
        }

        public static Task<HttpResponseMessage> ParametrosUsuario(int idUsuario)
        {
            login(loginTestUser1);
            Task<HttpResponseMessage> res = null; Task.Run(() => { res = client.GetAsync(url + "/api/dashboard/ParametrosUsuario?idUsuario=" + idUsuario); }).Wait(); return res;
        }

        public static Task<HttpResponseMessage> InformacionPersona(string user)
        {
            login(loginTestUser1);
            Task<HttpResponseMessage> res = null; Task.Run(() => { res = client.GetAsync(url + "/api/dashboard/InformacionPersona?Usuario=" + user); }).Wait(); return res;
        }

        public static Task<HttpResponseMessage> ConsultaUsuariosF(int idUsuario)
        {
            login(loginTestUser1);
            var data = serializarObjetoJson(idUsuario);
            Task<HttpResponseMessage> res = null; Task.Run(() => { res = client.GetAsync(url + "/api/dashboard/ConsultaUsuariosF"); }).Wait();
            return res;
        }

        //////////////////////////////Historial Operaciones//////////////////////

        public static Task<HttpResponseMessage> HistorialOperacionesTarjeta(int TarjetaId)
        {
            login(loginTestUser1);
            Task<HttpResponseMessage> res = null; Task.Run(() => { res = client.GetAsync(url + "/api/HistorialOperaciones/HistorialOperacionesTarjeta?TarjetaId=" + TarjetaId); }).Wait(); return res;
        }

        public static Task<HttpResponseMessage> HistorialOperacionesCuenta(int CuentaId)
        {
            login(loginTestUser1);
            Task<HttpResponseMessage> res = null; Task.Run(() => { res = client.GetAsync(url + "/api/HistorialOperaciones/HistorialOperacionesCuenta?CuentaId=" + CuentaId); }).Wait(); return res;
        }

        public static Task<HttpResponseMessage> HistorialOperacionesMonedero(int UsuarioId)
        {
            login(loginTestUser1);
            Task<HttpResponseMessage> res = null; Task.Run(() => { res = client.GetAsync(url + "/api/HistorialOperaciones/HistorialOperacionesMonedero?UsuarioId=" + UsuarioId); }).Wait(); return res;
        }

        public static Task<HttpResponseMessage> EjecutarCierre(int IdUsuario)
        {
            login(loginTestUser1);
            Task<HttpResponseMessage> res = null; Task.Run(() => { res = client.GetAsync(url + "/api/HistorialOperaciones/EjecutarCierre?idUsuario=" + IdUsuario); }).Wait(); return res;
        }

        //////////////////////////////////////////////////////////////Monedero/////////////////////////////////////////////////////////////

        public static Task<HttpResponseMessage> Consultar(int idusuario)
        {
            login(loginTestUser1);
            Task<HttpResponseMessage> res = null; Task.Run(() => { res = client.GetAsync(url + "/api/monedero/Consultar?idUsuario=" + idusuario); }).Wait(); return res;
        }

        public static Task<HttpResponseMessage> RecargaMonederoTarjeta(dynamic info)
        {
            login(loginTestUser1);
            var data = serializarObjetoJson(info);
            Task<HttpResponseMessage> res = null; Task.Run(() => { res = client.PostAsync(url + "/api/monedero/RecargaMonederoTarjeta", data); }).Wait(); return res;
        }

        public static Task<HttpResponseMessage> RecargaMonederoCuenta(dynamic info)
        {
            login(loginTestUser1);
            var data = serializarObjetoJson(info);
            Task<HttpResponseMessage> res = null; Task.Run(() => { res = client.PostAsync(url + "/api/monedero/RecargaMonederoCuenta", data); }).Wait(); return res;
        }

        public static Task<HttpResponseMessage> Retiro(dynamic recarga, InfoLogin loginTestUser1)
        {
            login(loginTestUser1);
            var data = serializarObjetoJson(recarga);
            Task<HttpResponseMessage> res = null; Task.Run(() => { res = client.PostAsync(url + "/api/monedero/Retiro", data); }).Wait(); return res;
        }

        //////////////////////////////////////////////Transfer//////////////////////////////////

        public static Task<HttpResponseMessage> RealizarCobro(dynamic infoCobro)
        {
            login(loginTestUser1);
            var data = serializarObjetoJson(infoCobro);
            Task<HttpResponseMessage> res = null; Task.Run(() => { res = client.PostAsync(url + "/api/Transfer/RealizarCobro", data); }).Wait(); return res;
        }

        public static Task<HttpResponseMessage> SolicitarReintegro(dynamic infoReintegro)
        {
            login(loginTestUser1);
            var data = serializarObjetoJson(infoReintegro);
            Task<HttpResponseMessage> res = null; Task.Run(() => { res = client.PostAsync(url + "/api/Transfer/SolicitarReintegro", data); }).Wait(); return res;
        }
        // por hacer 
        public static Task<HttpResponseMessage> CancelarCobro(int IdCobro)
        {
            login(loginTestUser1);
            var data = serializarObjetoJson(IdCobro);
            Task<HttpResponseMessage> res = null; Task.Run(() => { res = client.PostAsync(url + "/api/Transfer/CancelarCobro?idCobro=" + IdCobro, data); }).Wait(); return res;
        }
        // por hacer 
        public static Task<HttpResponseMessage> CancelarReintegro(int IdReintegro)
        {
            login(loginTestUser1);
            var data = serializarObjetoJson(IdReintegro);
            Task<HttpResponseMessage> res = null; Task.Run(() => { res = client.PostAsync(url + "/api/Transfer/CancelarReintegro?idreintegro=" + IdReintegro, data); }).Wait(); return res;
        }

        public static Task<HttpResponseMessage> RealizarPagoCuenta(dynamic infoPagoCuenta)
        {
            login(loginTestUser1);
            var data = serializarObjetoJson(infoPagoCuenta);
            Task<HttpResponseMessage> res = null; Task.Run(() => { res = client.PostAsync(url + "/api/Transfer/RealizarPagoCuenta", data); }).Wait(); return res;
        }

        public static Task<HttpResponseMessage> RealizarPagoTarjeta(dynamic infoPagoTarjeta)
        {
            login(loginTestUser1);
            var data = serializarObjetoJson(infoPagoTarjeta);
            Task<HttpResponseMessage> res = null; Task.Run(() => { res = client.PostAsync(url + "/api/Transfer/RealizarPagoTarjeta", data); }).Wait(); return res;
        }

        public static Task<HttpResponseMessage> RealizarPagoMonedero(dynamic infoPagoMonedero)
        {
            login(loginTestUser1);
            var data = serializarObjetoJson(infoPagoMonedero);
            Task<HttpResponseMessage> res = null; Task.Run(() => { res = client.PostAsync(url + "/api/Transfer/RealizarPagoMonedero", data); }).Wait(); return res;
        }

        public static Task<HttpResponseMessage> RealizarReintegroCuenta(dynamic infoReintegroCuenta)
        {
            login(loginTestUser1);
            var data = serializarObjetoJson(infoReintegroCuenta);
            Task<HttpResponseMessage> res = null; Task.Run(() => { res = client.PostAsync(url + "/api/Transfer/RealizarReintegroCuenta", data); }).Wait(); return res;
        }

        public static Task<HttpResponseMessage> RealizarReintegroTarjeta(dynamic infoReintegroTarjeta)
        {
            login(loginTestUser1);
            var data = serializarObjetoJson(infoReintegroTarjeta);
            Task<HttpResponseMessage> res = null; Task.Run(() => { res = client.PostAsync(url + "/api/Transfer/RealizarReintegroTarjeta", data); }).Wait(); return res;
        }

        public static Task<HttpResponseMessage> RealizarReintegroMonedero(dynamic infoReintegroMonedero)
        {
            login(loginTestUser1);
            var data = serializarObjetoJson(infoReintegroMonedero);
            Task<HttpResponseMessage> res = null; Task.Run(() => { res = client.PostAsync(url + "/api/Transfer/RealizarReintegroMonedero", data); }).Wait(); return res;
        }

        public static Task<HttpResponseMessage> EstablecerParametro(dynamic infoParametro)
        {
            login(loginTestUser1);
            var data = serializarObjetoJson(infoParametro);
            Task<HttpResponseMessage> res = null; Task.Run(() => { res = client.PostAsync(url + "/api/Transfer/EstablecerParametro", data); }).Wait(); return res;
        }

        public static Task<HttpResponseMessage> BotonPagoTarjeta(dynamic infoPagoTarjeta)
        {
            login(loginTestUser1);
            var data = serializarObjetoJson(infoPagoTarjeta);
            Task<HttpResponseMessage> res = null; Task.Run(() => { res = client.PostAsync(url + "/api/Transfer/BotonPagoTarjeta", data); }).Wait(); return res;
        }

        public static Task<HttpResponseMessage> BotonPagoCuenta(dynamic infoPagoCuenta)
        {
            login(loginTestUser1);
            var data = serializarObjetoJson(infoPagoCuenta);
            Task<HttpResponseMessage> res = null; Task.Run(() => { res = client.PostAsync(url + "/api/Transfer/BotonPagoCuenta", data); }).Wait(); return res;
        }

        public static Task<HttpResponseMessage> BotonPagoMonedero(dynamic infoPagoMonedero)
        {
            login(loginTestUser1);
            var data = serializarObjetoJson(infoPagoMonedero);
            Task<HttpResponseMessage> res = null; Task.Run(() => { res = client.PostAsync(url + "/api/Transfer/BotonPagoMonedero", data); }).Wait(); return res;
        }

    }
}
