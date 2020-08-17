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
    public class RealizarPagoMonedero
    {
        [TestMethod]
        public void realizarPagoMonedero()
        {
            dynamic infoPagoCuenta = new
            {
                idUsuarioReceptor = 13,
                idMedioPaga = 1,
                monto = 1,
                idOperacion = 1
            };
            Task<HttpResponseMessage> res = null;
            res = APITest.RealizarPagoMonedero(infoPagoCuenta);
            var status = res.Result.StatusCode;
            Assert.IsTrue(status == HttpStatusCode.OK);
        }

        [TestMethod]
        public void realizarPagoMonedero_idUsuarioInvalido()
        {
            dynamic infoPagoCuenta = new
            {
                idUsuarioReceptor = -1,
                idMedioPaga = 1,
                monto = 1,
                idOperacion = 1
            };
            Task<HttpResponseMessage> res = null;
            res = APITest.RealizarPagoMonedero(infoPagoCuenta);
            var status = res.Result.StatusCode;
            Assert.IsTrue(status == HttpStatusCode.BadRequest);
        }

        [TestMethod]
        public void realizarPagoMonedero_idMedioPagaInvalido()
        {
            dynamic infoPagoCuenta = new
            {
                idUsuarioReceptor = 13,
                idMedioPaga = -1,
                monto = 1,
                idOperacion = 1
            };
            Task<HttpResponseMessage> res = null;
            res = APITest.RealizarPagoMonedero(infoPagoCuenta);
            var status = res.Result.StatusCode;
            Assert.IsTrue(status == HttpStatusCode.BadRequest);
        }

        [TestMethod]
        public void realizarPagoMonedero_MontoExcediendoSaldo()
        {
            dynamic infoPagoCuenta = new
            {
                idUsuarioReceptor = 13,
                idMedioPaga = 1,
                monto = 100000000,
                idOperacion = 1
            };
            Task<HttpResponseMessage> res = null;
            res = APITest.RealizarPagoMonedero(infoPagoCuenta);
            var status = res.Result.StatusCode;
            Assert.IsTrue(status == HttpStatusCode.BadRequest);
        }
    }
}
