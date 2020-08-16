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
    public class SolicitarReintegro
    {
        [TestMethod]
        public void solicitarReintegro()
        {
            Task<HttpResponseMessage> res = APITest.SolicitarReintegro(new
            {
                idUsuarioSolicitante = 2,
                emailPagador = "testuser@gmail.com",
                referencia = "",
            });
            var s = res.Result.StatusCode;
            Assert.IsTrue(res.Result.StatusCode == HttpStatusCode.OK);
        }

        [TestMethod]
        public void solicitarReintegro_userInvalido()
        {
            Task<HttpResponseMessage> res = APITest.SolicitarReintegro(new
            {
                idUsuarioSolicitante = "",
                emailPagador = "testuser@gmail.com",
                referencia = "",
            });
            var s = res.Result.StatusCode;
            Assert.IsTrue(res.Result.StatusCode == HttpStatusCode.BadRequest);
        }

        [TestMethod]
        public void solicitarReintegro_emailInvalido()
        {
            Task<HttpResponseMessage> res = APITest.SolicitarReintegro(new
            {
                idUsuarioSolicitante = 2,
                emailPagador = "",
                referencia = "",
            });
            var s = res.Result.StatusCode;
            Assert.IsTrue(res.Result.StatusCode == HttpStatusCode.BadRequest);
        }

        [TestMethod]
        public void solicitarReintegro_referenciaInvalida()
        {
            Task<HttpResponseMessage> res = APITest.SolicitarReintegro(new
            {
                idUsuarioSolicitante = 2,
                emailPagador = "testuser@gmail.com",
                referencia = 1,
            });
            var s = res.Result.StatusCode;
            Assert.IsTrue(res.Result.StatusCode == HttpStatusCode.BadRequest);
        }
    }
}
