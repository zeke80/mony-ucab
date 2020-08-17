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
    //[TestClass]
    public class BotonPagoTarjeta
    {
        [TestMethod]
        public void botonPagoTarjeta()
        {
            Task<HttpResponseMessage> res = APITest.BotonPagoTarjeta(new
            {
                idUsuario = 2,
                idMedioPaga = 1,
                monto = 100,
                usuarioDestino = 1
            });
            var s = res.Result.StatusCode;
            Assert.IsTrue(res.Result.StatusCode == HttpStatusCode.OK);
        }

        [TestMethod]
        public void botonPagoTarjeta_idUsuarioInvalido()
        {
            Task<HttpResponseMessage> res = APITest.BotonPagoTarjeta(new
            {
                idUsuario = 2,
                idMedioPaga = 1,
                monto = 100,
                usuarioDestino = 1
            });
            var s = res.Result.StatusCode;
            Assert.IsTrue(res.Result.StatusCode == HttpStatusCode.BadRequest);
        }

        [TestMethod]
        public void botonPagoTarjeta_idMedioPagaInvalido()
        {
            Task<HttpResponseMessage> res = APITest.BotonPagoTarjeta(new
            {
                idUsuario = 2,
                idMedioPaga = "",
                monto = 100,
                usuarioDestino = 1
            });
            var s = res.Result.StatusCode;
            Assert.IsTrue(res.Result.StatusCode == HttpStatusCode.BadRequest);
        }

        [TestMethod]
        public void botonPagoTarjeta_montoInvalido()
        {
            Task<HttpResponseMessage> res = APITest.BotonPagoTarjeta(new
            {
                idUsuario = 2,
                idMedioPaga = 1,
                monto = "",
                usuarioDestino = 1
            });
            var s = res.Result.StatusCode;
            Assert.IsTrue(res.Result.StatusCode == HttpStatusCode.BadRequest);
        }
    }
}
