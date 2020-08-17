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
    public class RealizarReintegroCuenta
    {
        [TestMethod]
        public void realizarReintegroCuenta()
        {
            dynamic info = new
            {
                idUsuarioReceptor = 13,
                idMedioPaga = 47,
                monto = 1,
                idOperacion = 1
            };
            Task<HttpResponseMessage> res = null;
            res = APITest.RealizarReintegroCuenta(info);
            var status = res.Result.StatusCode;
            Assert.IsTrue(status == HttpStatusCode.OK);
        }

        [TestMethod]
        public void realizarReintegroCuenta_idUsuarioInvalido()
        {
            dynamic info = new
            {
                idUsuarioReceptor = -1,
                idMedioPaga = 1,
                monto = 1,
                idOperacion = 1
            };
            Task<HttpResponseMessage> res = null;
            res = APITest.RealizarReintegroCuenta(info);
            var status = res.Result.StatusCode;
            Assert.IsTrue(status == HttpStatusCode.BadRequest);
        }

        [TestMethod]
        public void realizarReintegroCuenta_idMedioPagaInvalido()
        {
            dynamic info = new
            {
                idUsuarioReceptor = 13,
                idMedioPaga = -1,
                monto = 1,
                idOperacion = 1
            };
            Task<HttpResponseMessage> res = null;
            res = APITest.RealizarReintegroCuenta(info);
            var status = res.Result.StatusCode;
            Assert.IsTrue(status == HttpStatusCode.BadRequest);
        }

        [TestMethod]
        public void realizarPagoCuenta_MontoExcediendoSaldo()
        {
            dynamic info = new
            {
                idUsuarioReceptor = 13,
                idMedioPaga = 1,
                monto = 100000000,
                idOperacion = 1
            };
            Task<HttpResponseMessage> res = null;
            res = APITest.RealizarReintegroCuenta(info);
            var status = res.Result.StatusCode;
            Assert.IsTrue(status == HttpStatusCode.BadRequest);
        }
    }
}
