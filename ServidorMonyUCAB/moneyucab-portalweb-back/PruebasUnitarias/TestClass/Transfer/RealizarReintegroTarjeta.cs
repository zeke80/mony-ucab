using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using PruebasUnitarias.Modelos;

namespace PruebasUnitarias.TestClass.Transfer
{
    [TestClass]
    public class RealizarReintegroTarjeta
    {
        [TestMethod]
        public void realizarReintegroTarjeta()
        {
            Task<HttpResponseMessage> res = APITest.RealizarReintegroTarjeta(new
            {
                idUsuarioReceptor = 2,
                idMedioPaga = 1,
                monto = 100,
                idOperacion = 1
            });
            var s = res.Result.StatusCode;
            Assert.IsTrue(res.Result.StatusCode == HttpStatusCode.OK);
        }

        [TestMethod]
        public void realizarReintegroTarjeta_idUsuarioInvalido()
        {
            Task<HttpResponseMessage> res = APITest.RealizarReintegroTarjeta(new
            {
                idUsuarioReceptor = "",
                idMedioPaga = 1,
                monto = 100,
                idOperacion = 1
            });
            var s = res.Result.StatusCode;
            Assert.IsTrue(res.Result.StatusCode == HttpStatusCode.BadRequest);
        }

        [TestMethod]
        public void realizarReintegroTarjeta_idMedioPagaInvalido()
        {
            Task<HttpResponseMessage> res = APITest.RealizarReintegroTarjeta(new
            {
                idUsuarioReceptor = 2,
                idMedioPaga = "",
                monto = 100,
                idOperacion = 1
            });
            var s = res.Result.StatusCode;
            Assert.IsTrue(res.Result.StatusCode == HttpStatusCode.BadRequest);
        }

        [TestMethod]
        public void realizarReintegroTarjeta_montoInvalido()
        {
            Task<HttpResponseMessage> res = APITest.RealizarReintegroTarjeta(new
            {
                idUsuarioReceptor = 2,
                idMedioPaga = 1,
                monto = "",
                idOperacion = 1
            });
            var s = res.Result.StatusCode;
            Assert.IsTrue(res.Result.StatusCode == HttpStatusCode.BadRequest);
        }

        [TestMethod]
        public void realizarReintegroTarjeta_idOperacionInvalido()
        {
            Task<HttpResponseMessage> res = APITest.RealizarReintegroTarjeta(new
            {
                idUsuarioReceptor = 2,
                idMedioPaga = 1,
                monto = 100,
                idOperacion = ""
            });
            var s = res.Result.StatusCode;
            Assert.IsTrue(res.Result.StatusCode == HttpStatusCode.BadRequest);
        }
    }
}
