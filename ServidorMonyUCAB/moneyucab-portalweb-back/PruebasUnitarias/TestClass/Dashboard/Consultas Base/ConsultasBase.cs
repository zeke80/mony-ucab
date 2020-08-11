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
        [TestInitialize]
        public void TestInitialize()
        {           
        }

        [TestCleanup]
        public void TestCleanup()
        {
        }

        [TestMethod]
        public void estados_civiles()
        {
            Task<HttpResponseMessage> res = null;
            Task.Run(() => {
                res = APITest.EstadosCiviles();
            }).Wait();
            var status = res.Result.StatusCode;
            Assert.IsTrue(status == HttpStatusCode.OK);
        }
        
        [TestMethod]
        public void tipos_tarjetas()
        {
            Task<HttpResponseMessage> res = null;
            Task.Run(() => {
                res = APITest.TiposTarjetas();
            }).Wait();
            var status = res.Result.StatusCode;
            Assert.IsTrue(status == HttpStatusCode.OK);
        }
        
        [TestMethod]
        public void bancos()
        {
            Task<HttpResponseMessage> res = null;
            Task.Run(() => {
                res = APITest.Bancos();
            }).Wait();
            var status = res.Result.StatusCode;
            Assert.IsTrue(status == HttpStatusCode.OK);
        }
        
        [TestMethod]
        public void tipos_cuentas()
        {
            Task<HttpResponseMessage> res = null;
            Task.Run(() => {
                res = APITest.TiposCuentas();
            }).Wait();
            var status = res.Result.StatusCode;
            Assert.IsTrue(status == HttpStatusCode.OK);
        }
        
        [TestMethod]
        public void tipos_parametros()
        {
            Task<HttpResponseMessage> res = null;
            Task.Run(() => {
                res = APITest.TiposParametros();
            }).Wait();
            var status = res.Result.StatusCode;
            Assert.IsTrue(status == HttpStatusCode.OK);
        }

        [TestMethod]
        public void frecuencia()
        {
            Task<HttpResponseMessage> res = null;
            Task.Run(() => {
                res = APITest.Frecuencias();
            }).Wait();
            var status = res.Result.StatusCode;
            Assert.IsTrue(status == HttpStatusCode.OK);
        }

        [TestMethod]
        public void parametros()
        {
            Task<HttpResponseMessage> res = null;
            Task.Run(() => {
                res = APITest.Parametros();
            }).Wait();
            var status = res.Result.StatusCode;
            Assert.IsTrue(status == HttpStatusCode.OK);
        }

        [TestMethod]
        public void tipos_operaciones()
        {
            Task<HttpResponseMessage> res = null;
            Task.Run(() => {
                res = APITest.TiposOperaciones();
            }).Wait();
            var status = res.Result.StatusCode;
            Assert.IsTrue(status == HttpStatusCode.OK);
        }
        
        [TestMethod]
        public void tipos_identificacion()
        {
            Task<HttpResponseMessage> res = null;
            Task.Run(() => {
                res = APITest.TiposIdentificaciones();
            }).Wait();
            var status = res.Result.StatusCode;
            Assert.IsTrue(status == HttpStatusCode.OK);
        }
    }
}
