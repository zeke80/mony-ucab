using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using PruebasUnitarias.Modelos;

namespace PruebasUnitarias
{
    [TestClass]
    public class ConsultasBase
    {
        Persona registroAdmin1;
        Login loginAdmin1;

        [TestInitialize]
        public void TestInitialize()
        {
            registroAdmin1 = new Persona
            {
                Usuario = "admin1",
                Email = "admin1@gmail.com",
                Password = "admin1",
                IdTipoUsuario = 3,
                IdTipoIdentificacion = 1,
                IdEstadoCivil = 1,
                AnoRegistro = DateTime.Now.Year,
                MesRegistro = DateTime.Now.Month,
                DiaRegistro = DateTime.Now.Day,
                NroIdentificacion = 1,
                Telefono = "admin1",
                Direccion = "admin1",
                Estatus = 1,
                Comercio = false,
                Nombre = "admin1",
                Apellido = "admin1",
                AnoNacimiento = 2000,
                MesNacimiento = 1,
                DiaNacimiento = 1,
                RazonSocial = "admin1",
            };

            loginAdmin1 = new Login()
            {
                UserName = registroAdmin1.Usuario,
                Email = registroAdmin1.Email,
                Password = registroAdmin1.Password,
                Comercio = registroAdmin1.Comercio
            };

        }

        [TestCleanup]
        public void TestCleanup()
        {
        }

        [TestMethod]
        public void estados_civiles()
        {
            Task<HttpResponseMessage> res = APITest.EstadosCiviles(loginAdmin1);
            var s = res.Result.StatusCode;
            Assert.IsTrue(res.Result.StatusCode == HttpStatusCode.OK);
        }
        
        [TestMethod]
        public void tipos_tarjetas()
        {
            Task<HttpResponseMessage> res = APITest.TiposTarjetas(loginAdmin1);
            var s = res.Result.StatusCode;
            Assert.IsTrue(res.Result.StatusCode == HttpStatusCode.OK);
        }
        
        [TestMethod]
        public void bancos()
        {
            Task<HttpResponseMessage> res = APITest.Bancos(loginAdmin1);
            var s = res.Result.StatusCode;
            Assert.IsTrue(res.Result.StatusCode == HttpStatusCode.OK);
        }
        
        [TestMethod]
        public void tipos_cuentas()
        {
            Task<HttpResponseMessage> res = APITest.TiposCuentas(loginAdmin1);
            var s = res.Result.StatusCode;
            Assert.IsTrue(res.Result.StatusCode == HttpStatusCode.OK);
        }
        
        [TestMethod]
        public void tipos_parametros()
        {
            Task<HttpResponseMessage> res = APITest.TiposParametros(loginAdmin1);
            var s = res.Result.StatusCode;
            Assert.IsTrue(res.Result.StatusCode == HttpStatusCode.OK);
        }

        [TestMethod]
        public void frecuencia()
        {
            Task<HttpResponseMessage> res = APITest.Frecuencias(loginAdmin1);
            var s = res.Result.StatusCode;
            Assert.IsTrue(res.Result.StatusCode == HttpStatusCode.OK);
        }

        [TestMethod]
        public void parametros()
        {
            Task<HttpResponseMessage> res = APITest.Parametros(loginAdmin1);
            var s = res.Result.StatusCode;
            Assert.IsTrue(res.Result.StatusCode == HttpStatusCode.OK);
        }

        [TestMethod]
        public void tipos_operaciones()
        {
            Task<HttpResponseMessage> res = APITest.TiposOperaciones(loginAdmin1);
            var s = res.Result.StatusCode;
            Assert.IsTrue(res.Result.StatusCode == HttpStatusCode.OK);
        }
        
        [TestMethod]
        public void tipos_identificacion()
        {
            Task<HttpResponseMessage> res = APITest.TiposIdentificaciones(loginAdmin1);
            var s = res.Result.StatusCode;
            Assert.IsTrue(res.Result.StatusCode == HttpStatusCode.OK);
        }


    }
}
