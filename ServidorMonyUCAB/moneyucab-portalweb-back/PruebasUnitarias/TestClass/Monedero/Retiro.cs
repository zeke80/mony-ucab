using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using PruebasUnitarias.Modelos;

namespace PruebasUnitarias.TestClass.Monedero
{
    [TestClass]
    public class Retiro
    {
        [TestMethod]
        public void retiro()
        {
            dynamic recarga = new
            {
                idUsuarioReceptor = 1,
                idMedioPaga = 1,
                monto = 1,
                idOperacion = 1
            };
            Task<HttpResponseMessage> res = null;
            res = APITest.Retiro(recarga);
            var status = res.Result.StatusCode;
            Assert.IsTrue(status == HttpStatusCode.OK);
        }

        [TestMethod]
        public void retiro_idUsuarioReceptorInvalido()
        {
            dynamic recarga = new
            {
                idUsuarioReceptor = -1,
                idMedioPaga = 1,
                monto = 1,
                idOperacion = 1
            };
            Task<HttpResponseMessage> res = null;
            res = APITest.Retiro(recarga);
            var status = res.Result.StatusCode;
            Assert.IsTrue(status == HttpStatusCode.BadRequest);
        }

        [TestMethod]
        public void retiro_idMedioPagaInvalido()
        {
            dynamic recarga = new
            {
                idUsuarioReceptor = 1,
                idMedioPaga = -1,
                monto = 1,
                idOperacion = 1
            };
            Task<HttpResponseMessage> res = null;
            res = APITest.Retiro(recarga);
            var status = res.Result.StatusCode;
            Assert.IsTrue(status == HttpStatusCode.BadRequest);
        }
    }
}
