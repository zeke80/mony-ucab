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
    public class BotonPagoCuenta
    {
        [TestMethod]
        public void botonPagoCuenta()
        {
            int idusuario = 1;
            Task<HttpResponseMessage> res = null;
            res = APITest.BotonPagoCuenta(idusuario);
            var status = res.Result.StatusCode;
            Assert.IsTrue(status == HttpStatusCode.OK);
        }

        [TestMethod]
        public void botonPagoCuenta_idUsuarioInvalido()
        {
            Task<HttpResponseMessage> res = APITest.BotonPagoCuenta(new
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
        public void botonPagoCuenta_idMedioPagaInvalido()
        {
            Task<HttpResponseMessage> res = APITest.BotonPagoCuenta(new
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
        public void botonPagoCuenta_montoInvalido()
        {
            Task<HttpResponseMessage> res = APITest.BotonPagoCuenta(new
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
