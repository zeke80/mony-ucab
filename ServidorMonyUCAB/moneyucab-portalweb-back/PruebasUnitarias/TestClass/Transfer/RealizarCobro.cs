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
    public class RealizarCobro
    {

        [TestMethod]
        public void realizarCobro()
        {
            Task<HttpResponseMessage> res = APITest.RecargaMonederoCuenta(new
            {
                idUsuarioSolicitante = 2,
                emailPagador = "testuser@gmail.com",
                monto = 100,
            });
            var s = res.Result.StatusCode;
            Assert.IsTrue(res.Result.StatusCode == HttpStatusCode.OK);
        }

        [TestMethod]
        public void realizarCobro_userInvalido()
        {
            Task<HttpResponseMessage> res = APITest.RecargaMonederoCuenta(new
            {
                idUsuarioSolicitante = "edwqd",
                emailPagador = "testuser@gmail.com",
                monto = 100,
            });
            var s = res.Result.StatusCode;
            Assert.IsTrue(res.Result.StatusCode == HttpStatusCode.BadRequest);
        }

        [TestMethod]
        public void realizarCobro_emailInvalido()
        {
            Task<HttpResponseMessage> res = APITest.RecargaMonederoCuenta(new
            {
                idUsuarioSolicitante = 2,
                emailPagador = "",
                monto = 100,
            });
            var s = res.Result.StatusCode;
            Assert.IsTrue(res.Result.StatusCode == HttpStatusCode.BadRequest);
        }

        [TestMethod]
        public void realizarCobro_montoInvalido()
        {
            Task<HttpResponseMessage> res = APITest.RecargaMonederoCuenta(new
            {
                idUsuarioSolicitante = 2,
                emailPagador = "testuser@gmail.com",
                monto = "",
            });
            var s = res.Result.StatusCode;
            Assert.IsTrue(res.Result.StatusCode == HttpStatusCode.BadRequest);
        }
    }
}
