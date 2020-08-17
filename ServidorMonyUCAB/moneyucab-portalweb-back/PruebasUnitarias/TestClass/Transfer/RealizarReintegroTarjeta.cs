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
                idUsuarioReceptor = 13,
                idMedioPaga = 1,
                monto = 1,
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
                idUsuarioReceptor = -1,
                idMedioPaga = 1,
                monto = 1,
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
                idUsuarioReceptor = 13,
                idMedioPaga = -1,
                monto = 1,
                idOperacion = 1
            });
            var s = res.Result.StatusCode;
            Assert.IsTrue(res.Result.StatusCode == HttpStatusCode.BadRequest);
        }

        /*[TestMethod]
        public void realizarReintegroTarjeta_montoInvalido()
        {
            Task<HttpResponseMessage> res = APITest.RealizarReintegroTarjeta(new
            {
                idUsuarioReceptor = 13,
                idMedioPaga = 1,
                monto = 10000000000000,
                idOperacion = 1
            });
            var s = res.Result.StatusCode;
            Assert.IsTrue(res.Result.StatusCode == HttpStatusCode.BadRequest);
        }*/
    }
}
