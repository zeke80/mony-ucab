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
            dynamic infoCobro = new
            {
                idUsuarioSolicitante = 1,
                emailPagador = "testuser2@gmail.com",
                monto = 100
            };
            Task<HttpResponseMessage> res = null;
            res = APITest.RealizarCobro(infoCobro);
            var status = res.Result.StatusCode;
            Assert.IsTrue(status == HttpStatusCode.OK);
        }

        [TestMethod]
        public void realizarCobro_userInvalido()
        {
            dynamic infoCobro = new
            {
                idUsuarioSolicitante = -1,
                emailPagador = "testuser2@gmail.com",
                monto = 100
            };
            Task<HttpResponseMessage> res = null;
            res = APITest.RealizarCobro(infoCobro);
            var status = res.Result.StatusCode;
            Assert.IsTrue(status == HttpStatusCode.BadRequest);
        }

        [TestMethod]
        public void realizarCobro_emailInvalido()
        {
            dynamic infoCobro = new
            {
                idUsuarioSolicitante = 1,
                emailPagador = "",
                monto = 100
            };
            Task<HttpResponseMessage> res = null;
            res = APITest.RealizarCobro(infoCobro);
            var status = res.Result.StatusCode;
            Assert.IsTrue(status == HttpStatusCode.BadRequest);
        }
    }
}
