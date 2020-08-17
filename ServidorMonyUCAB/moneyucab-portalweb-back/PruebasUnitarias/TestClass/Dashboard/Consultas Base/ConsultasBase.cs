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
            
            res = APITest.EstadosCiviles();
            
            var status = res.Result.StatusCode;
            Assert.IsTrue(status == HttpStatusCode.OK);
        }
        
        [TestMethod]
        public void tipos_tarjetas()
        {
            Task<HttpResponseMessage> res = null;
            
            res = APITest.TiposTarjetas();
            
            var status = res.Result.StatusCode;
            Assert.IsTrue(status == HttpStatusCode.OK);
        }
        
        [TestMethod]
        public void bancos()
        {
            Task<HttpResponseMessage> res = null;
            
            res = APITest.Bancos();
            
            var status = res.Result.StatusCode;
            Assert.IsTrue(status == HttpStatusCode.OK);
        }
        
        [TestMethod]
        public void tipos_cuentas()
        {
            Task<HttpResponseMessage> res = null;
            
            res = APITest.TiposCuentas();
            
            var status = res.Result.StatusCode;
            Assert.IsTrue(status == HttpStatusCode.OK);
        }
        
        [TestMethod]
        public void tipos_parametros()
        {
            Task<HttpResponseMessage> res = null;
            
            res = APITest.TiposParametros();
            
            var status = res.Result.StatusCode;
            Assert.IsTrue(status == HttpStatusCode.OK);
        }

        [TestMethod]
        public void frecuencia()
        {
            Task<HttpResponseMessage> res = null;
            
            res = APITest.Frecuencias();
            
            var status = res.Result.StatusCode;
            Assert.IsTrue(status == HttpStatusCode.OK);
        }

        [TestMethod]
        public void parametros()
        {
            Task<HttpResponseMessage> res = null;
            
            res = APITest.Parametros();
            
            var status = res.Result.StatusCode;
            Assert.IsTrue(status == HttpStatusCode.OK);
        }

        [TestMethod]
        public void tipos_operaciones()
        {
            Task<HttpResponseMessage> res = null;
            
            res = APITest.TiposOperaciones();
            
            var status = res.Result.StatusCode;
            Assert.IsTrue(status == HttpStatusCode.OK);
        }
        
        [TestMethod]
        public void tipos_identificacion()
        {
            Task<HttpResponseMessage> res = null;
            
            res = APITest.TiposIdentificaciones();
            
            var status = res.Result.StatusCode;
            Assert.IsTrue(status == HttpStatusCode.OK);
        }
    }
}
