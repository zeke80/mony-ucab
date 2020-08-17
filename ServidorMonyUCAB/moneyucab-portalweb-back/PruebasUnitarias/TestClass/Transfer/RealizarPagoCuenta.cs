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
    public class RealizarPagoCuenta
    {
        [TestMethod]
        public void realizarPagoCuenta()
        {
            dynamic infoPagoCuenta = new
            {
                idUsuarioReceptor = 13,
                idMedioPaga = 1,
                monto = 1,
                idOperacion = 1
            };
            Task<HttpResponseMessage> res = null;
            res = APITest.RealizarPagoCuenta(infoPagoCuenta);
            var status = res.Result.StatusCode;
            Assert.IsTrue(status == HttpStatusCode.OK);
        }

        [TestMethod]
        public void realizarPagoCuenta_idUsuarioInvalido()
        {
            dynamic infoPagoCuenta = new
            {
                idUsuarioReceptor = -1,
                idMedioPaga = 1,
                monto = 1,
                idOperacion = 1
            };
            Task<HttpResponseMessage> res = null;
            res = APITest.RealizarPagoCuenta(infoPagoCuenta);
            var status = res.Result.StatusCode;
            Assert.IsTrue(status == HttpStatusCode.BadRequest);
        }

        [TestMethod]
        public void realizarPagoCuenta_idMedioPagaInvalido()
        {
            dynamic infoPagoCuenta = new
            {
                idUsuarioReceptor = 13,
                idMedioPaga = -1,
                monto = 1,
                idOperacion = 1
            };
            Task<HttpResponseMessage> res = null;
            res = APITest.RealizarPagoCuenta(infoPagoCuenta);
            var status = res.Result.StatusCode;
            Assert.IsTrue(status == HttpStatusCode.BadRequest);
        }

        [TestMethod]
        public void realizarPagoCuenta_MontoExcediendoSaldo()
        {
            dynamic infoPagoCuenta = new
            {
                idUsuarioReceptor = 13,
                idMedioPaga = 1,
                monto = 100000000,
                idOperacion = 1
            };
            Task<HttpResponseMessage> res = null;
            res = APITest.RealizarPagoCuenta(infoPagoCuenta);
            var status = res.Result.StatusCode;
            Assert.IsTrue(status == HttpStatusCode.BadRequest);
        }
    }
}
