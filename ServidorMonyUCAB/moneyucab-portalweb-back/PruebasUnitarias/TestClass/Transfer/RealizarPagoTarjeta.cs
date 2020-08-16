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
    public class RealizarPagoTarjeta
    {
        [TestMethod]
        public void realizarPagoTarjeta()
        {
            dynamic infoPagoTarjeta = new
            {
                idUsuarioReceptor = 1,
                idMedioPaga = 1,
                monto = 100,
                idOperacion = 1
            };
            Task<HttpResponseMessage> res = null;
            res = APITest.RealizarPagoTarjeta(infoPagoTarjeta);
            var status = res.Result.StatusCode;
            Assert.IsTrue(status == HttpStatusCode.OK);
        }

        [TestMethod]
        public void realizarPagoTarjeta_idUsuarioInvalido()
        {
            dynamic infoPagoTarjeta = new
            {
                idUsuarioReceptor = -1,
                idMedioPaga = 1,
                monto = 100,
                idOperacion = 1
            };
            Task<HttpResponseMessage> res = null;
            res = APITest.RealizarPagoTarjeta(infoPagoTarjeta);
            var status = res.Result.StatusCode;
            Assert.IsTrue(status == HttpStatusCode.BadRequest);
        }

        [TestMethod]
        public void realizarPagoTarjeta_idMedioPagaInvalido()
        {
            dynamic infoPagoTarjeta = new
            {
                idUsuarioReceptor = 1,
                idMedioPaga = -1,
                monto = 100,
                idOperacion = 1
            };
            Task<HttpResponseMessage> res = null;
            res = APITest.RealizarPagoTarjeta(infoPagoTarjeta);
            var status = res.Result.StatusCode;
            Assert.IsTrue(status == HttpStatusCode.BadRequest);
        }

        [TestMethod]
        public void realizarPagoTarjeta_montoInvalido()
        {
            dynamic infoPagoTarjeta = new
            {
                idUsuarioReceptor = 1,
                idMedioPaga = 1,
                monto = 10000000000,
                idOperacion = 1
            };
            Task<HttpResponseMessage> res = null;
            res = APITest.RealizarPagoTarjeta(infoPagoTarjeta);
            var status = res.Result.StatusCode;
            Assert.IsTrue(status == HttpStatusCode.OK);
        }
    }
}
