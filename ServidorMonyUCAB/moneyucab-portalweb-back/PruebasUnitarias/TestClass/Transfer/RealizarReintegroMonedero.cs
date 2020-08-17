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
    public class RealizarReintegroMonedero
    {
        [TestMethod]
        public void realizarReintegroMonedero()
        {
            dynamic info = new
            {
                idUsuarioReceptor = 13,
                idMedioPaga = 1,
                monto = 1,
                idOperacion = 1
            };
            Task<HttpResponseMessage> res = null;
            res = APITest.RealizarReintegroMonedero(info);
            var status = res.Result.StatusCode;
            Assert.IsTrue(status == HttpStatusCode.OK);
        }

        [TestMethod]
        public void realizarReintegroMonedero_idUsuarioInvalido()
        {
            dynamic info = new
            {
                idUsuarioReceptor = -1,
                idMedioPaga = 1,
                monto = 1,
                idOperacion = 1
            };
            Task<HttpResponseMessage> res = null;
            res = APITest.RealizarReintegroMonedero(info);
            var status = res.Result.StatusCode;
            Assert.IsTrue(status == HttpStatusCode.BadRequest);
        }

        [TestMethod]
        public void realizarReintegroMonedero_idMedioPagaInvalido()
        {
            dynamic info = new
            {
                idUsuarioReceptor = 13,
                idMedioPaga = -1,
                monto = 1,
                idOperacion = 1
            };
            Task<HttpResponseMessage> res = null;
            res = APITest.RealizarReintegroMonedero(info);
            var status = res.Result.StatusCode;
            Assert.IsTrue(status == HttpStatusCode.BadRequest);
        }

        [TestMethod]
        public void realizarReintegroMonedero_MontoExcediendoSaldo()
        {
            dynamic info = new
            {
                idUsuarioReceptor = 13,
                idMedioPaga = 1,
                monto = 1000000000,
                idOperacion = 1
            };
            Task<HttpResponseMessage> res = null;
            res = APITest.RealizarReintegroMonedero(info);
            var status = res.Result.StatusCode;
            Assert.IsTrue(status == HttpStatusCode.BadRequest);
        }
    }
}
